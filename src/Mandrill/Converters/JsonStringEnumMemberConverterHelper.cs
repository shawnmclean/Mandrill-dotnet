using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Runtime.Serialization;

namespace System.Text.Json.Serialization
{
  internal class JsonStringEnumMemberConverterHelper<TEnum>
      where TEnum : struct, Enum
  {
    private class EnumInfo
    {
#pragma warning disable SA1401 // Fields should be private
      public string Name;
      public TEnum EnumValue;
      public ulong RawValue;
#pragma warning restore SA1401 // Fields should be private

      public EnumInfo(string name, TEnum enumValue, ulong rawValue)
      {
        Name = name;
        EnumValue = enumValue;
        RawValue = rawValue;
      }
    }

    private const BindingFlags EnumBindings = BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static;

#if NETSTANDARD2_0
    private static readonly string[] s_Split = new string[] { ", " };
#endif

    private readonly bool _AllowIntegerValues;
    private readonly Type _EnumType;
    private readonly TypeCode _EnumTypeCode;
    private readonly bool _IsFlags;
    private readonly Dictionary<TEnum, EnumInfo> _RawToTransformed;
    private readonly Dictionary<string, EnumInfo> _TransformedToRaw;

    public JsonStringEnumMemberConverterHelper(JsonNamingPolicy? namingPolicy, bool allowIntegerValues)
    {
      _AllowIntegerValues = allowIntegerValues;
      _EnumType = typeof(TEnum);
      _EnumTypeCode = Type.GetTypeCode(_EnumType);
      _IsFlags = _EnumType.IsDefined(typeof(FlagsAttribute), true);

      var builtInNames = _EnumType.GetEnumNames();
      var builtInValues = _EnumType.GetEnumValues();

      _RawToTransformed = new Dictionary<TEnum, EnumInfo>();
      _TransformedToRaw = new Dictionary<string, EnumInfo>();

      for (var i = 0; i < builtInNames.Length; i++)
      {
        var enumValue = (Enum?)builtInValues.GetValue(i);
        if (enumValue == null)
          continue;
        var rawValue = GetEnumValue(enumValue);

        var name = builtInNames[i];
        var field = _EnumType.GetField(name, EnumBindings)!;
        var enumMemberAttribute = field.GetCustomAttribute<EnumMemberAttribute>(true);
        var transformedName = enumMemberAttribute?.Value ?? namingPolicy?.ConvertName(name) ?? name;

        if (enumValue is not TEnum typedValue)
          throw new NotSupportedException();

        _RawToTransformed[typedValue] = new EnumInfo(transformedName, typedValue, rawValue);
        _TransformedToRaw[transformedName] = new EnumInfo(name, typedValue, rawValue);
      }
    }

    public TEnum Read(ref Utf8JsonReader reader)
    {
      var token = reader.TokenType;

      if (token == JsonTokenType.String)
      {
        var enumString = reader.GetString()!;

        // Case sensitive search attempted first.
        if (_TransformedToRaw.TryGetValue(enumString, out var enumInfo))
          return enumInfo.EnumValue;

        if (_IsFlags)
        {
          ulong calculatedValue = 0;

#if NETSTANDARD2_0
          var flagValues = enumString.Split(s_Split, StringSplitOptions.None);
#else
					string[] flagValues = enumString.Split(", ");
#endif
          foreach (var flagValue in flagValues)
          {
            // Case sensitive search attempted first.
            if (_TransformedToRaw.TryGetValue(flagValue, out enumInfo))
            {
              calculatedValue |= enumInfo.RawValue;
            }
            else
            {
              // Case insensitive search attempted second.
              var matched = false;
              foreach (var enumItem in _TransformedToRaw)
              {
                if (string.Equals(enumItem.Key, flagValue, StringComparison.OrdinalIgnoreCase))
                {
                  calculatedValue |= enumItem.Value.RawValue;
                  matched = true;
                  break;
                }
              }

              if (!matched)
                throw new JsonException($"The JSON value '{flagValue}' could not be converted to {_EnumType}.");
            }
          }

          var enumValue = (TEnum)Enum.ToObject(_EnumType, calculatedValue);
          if (_TransformedToRaw.Count < 64)
          {
            _TransformedToRaw[enumString] = new EnumInfo(enumString, enumValue, calculatedValue);
          }
          return enumValue;
        }

        // Case insensitive search attempted second.
        foreach (var enumItem in _TransformedToRaw)
        {
          if (string.Equals(enumItem.Key, enumString, StringComparison.OrdinalIgnoreCase))
          {
            return enumItem.Value.EnumValue;
          }
        }

        throw new JsonException($"The JSON value '{enumString}' could not be converted to {_EnumType}.");
      }

      if (token != JsonTokenType.Number || !_AllowIntegerValues)
        throw new JsonException($"The JSON value could not be converted to {_EnumType}.");

      switch (_EnumTypeCode)
      {
        case TypeCode.Int32:
          if (reader.TryGetInt32(out var int32))
          {
            return (TEnum)Enum.ToObject(_EnumType, int32);
          }
          break;
        case TypeCode.Int64:
          if (reader.TryGetInt64(out var int64))
          {
            return (TEnum)Enum.ToObject(_EnumType, int64);
          }
          break;
        case TypeCode.Int16:
          if (reader.TryGetInt16(out var int16))
          {
            return (TEnum)Enum.ToObject(_EnumType, int16);
          }
          break;
        case TypeCode.Byte:
          if (reader.TryGetByte(out var ubyte8))
          {
            return (TEnum)Enum.ToObject(_EnumType, ubyte8);
          }
          break;
        case TypeCode.UInt32:
          if (reader.TryGetUInt32(out var uint32))
          {
            return (TEnum)Enum.ToObject(_EnumType, uint32);
          }
          break;
        case TypeCode.UInt64:
          if (reader.TryGetUInt64(out var uint64))
          {
            return (TEnum)Enum.ToObject(_EnumType, uint64);
          }
          break;
        case TypeCode.UInt16:
          if (reader.TryGetUInt16(out var uint16))
          {
            return (TEnum)Enum.ToObject(_EnumType, uint16);
          }
          break;
        case TypeCode.SByte:
          if (reader.TryGetSByte(out var byte8))
          {
            return (TEnum)Enum.ToObject(_EnumType, byte8);
          }
          break;
      }

      throw new JsonException($"The JSON value could not be converted to {_EnumType}.");
    }

    public void Write(Utf8JsonWriter writer, TEnum value)
    {
      if (_RawToTransformed.TryGetValue(value, out var enumInfo))
      {
        writer.WriteStringValue(enumInfo.Name);
        return;
      }

      var rawValue = GetEnumValue(value);

      if (_IsFlags)
      {
        ulong calculatedValue = 0;

        var Builder = new StringBuilder();
        foreach (var enumItem in _RawToTransformed)
        {
          enumInfo = enumItem.Value;
          if (!value.HasFlag(enumInfo.EnumValue)
              || enumInfo.RawValue == 0) // Definitions with 'None' should hit the cache case.
          {
            continue;
          }

          // Track the value to make sure all bits are represented.
          calculatedValue |= enumInfo.RawValue;

          if (Builder.Length > 0)
            Builder.Append(", ");
          Builder.Append(enumInfo.Name);
        }
        if (calculatedValue == rawValue)
        {
          var finalName = Builder.ToString();
          if (_RawToTransformed.Count < 64)
          {
            _RawToTransformed[value] = new EnumInfo(finalName, value, rawValue);
          }
          writer.WriteStringValue(finalName);
          return;
        }
      }

      if (!_AllowIntegerValues)
        throw new JsonException($"Enum type {_EnumType} does not have a mapping for integer value '{rawValue.ToString(CultureInfo.CurrentCulture)}'.");

      switch (_EnumTypeCode)
      {
        case TypeCode.Int32:
          writer.WriteNumberValue((int)rawValue);
          break;
        case TypeCode.Int64:
          writer.WriteNumberValue((long)rawValue);
          break;
        case TypeCode.Int16:
          writer.WriteNumberValue((short)rawValue);
          break;
        case TypeCode.Byte:
          writer.WriteNumberValue((byte)rawValue);
          break;
        case TypeCode.UInt32:
          writer.WriteNumberValue((uint)rawValue);
          break;
        case TypeCode.UInt64:
          writer.WriteNumberValue(rawValue);
          break;
        case TypeCode.UInt16:
          writer.WriteNumberValue((ushort)rawValue);
          break;
        case TypeCode.SByte:
          writer.WriteNumberValue((sbyte)rawValue);
          break;
        default:
          throw new JsonException(); // GetEnumValue should have already thrown.
      }
    }

    private ulong GetEnumValue(object value)
    {
      return _EnumTypeCode switch
      {
        TypeCode.Int32 => (ulong)(int)value,
        TypeCode.Int64 => (ulong)(long)value,
        TypeCode.Int16 => (ulong)(short)value,
        TypeCode.Byte => (byte)value,
        TypeCode.UInt32 => (uint)value,
        TypeCode.UInt64 => (ulong)value,
        TypeCode.UInt16 => (ushort)value,
        TypeCode.SByte => (ulong)(sbyte)value,
        _ => throw new NotSupportedException($"Enum '{value}' of {_EnumTypeCode} type is not supported."),
      };
    }
  }
}
