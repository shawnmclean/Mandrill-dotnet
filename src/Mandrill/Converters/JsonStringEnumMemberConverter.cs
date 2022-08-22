using System.Reflection;

namespace System.Text.Json.Serialization
{
  /// <summary>
  /// <see cref="JsonConverterFactory"/> to convert enums to and from strings, respecting <see cref="EnumMemberAttribute"/> decorations. Supports nullable enums.
  /// </summary>
  public class JsonStringEnumMemberConverter : JsonConverterFactory
  {
    private readonly JsonNamingPolicy? _NamingPolicy;
    private readonly bool _AllowIntegerValues;

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonStringEnumMemberConverter"/> class.
    /// </summary>
    public JsonStringEnumMemberConverter()
        : this(namingPolicy: null, allowIntegerValues: true)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonStringEnumMemberConverter"/> class.
    /// </summary>
    /// <param name="namingPolicy">
    /// Optional naming policy for writing enum values.
    /// </param>
    /// <param name="allowIntegerValues">
    /// True to allow undefined enum values. When true, if an enum value isn't
    /// defined it will output as a number rather than a string.
    /// </param>
    public JsonStringEnumMemberConverter(JsonNamingPolicy? namingPolicy = null, bool allowIntegerValues = true)
    {
      _NamingPolicy = namingPolicy;
      _AllowIntegerValues = allowIntegerValues;
    }

    /// <inheritdoc/>
    public override bool CanConvert(Type typeToConvert)
    {
      // Don't perform a typeToConvert == null check for performance. Trust our callers will be nice.
#pragma warning disable CA1062 // Validate arguments of public methods
      return typeToConvert.IsEnum
          || (typeToConvert.IsGenericType && TestNullableEnum(typeToConvert).IsNullableEnum);
#pragma warning restore CA1062 // Validate arguments of public methods
    }

    /// <inheritdoc/>
    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
      (var IsNullableEnum, var UnderlyingType) = TestNullableEnum(typeToConvert);

      return IsNullableEnum
          ? (JsonConverter)Activator.CreateInstance(
              typeof(NullableEnumMemberConverter<>).MakeGenericType(UnderlyingType),
              BindingFlags.Instance | BindingFlags.Public,
              binder: null,
              args: new object?[] { _NamingPolicy, _AllowIntegerValues },
              culture: null)
          : (JsonConverter)Activator.CreateInstance(
              typeof(EnumMemberConverter<>).MakeGenericType(typeToConvert),
              BindingFlags.Instance | BindingFlags.Public,
              binder: null,
              args: new object?[] { _NamingPolicy, _AllowIntegerValues },
              culture: null);
    }

    private static (bool IsNullableEnum, Type? UnderlyingType) TestNullableEnum(Type typeToConvert)
    {
      var UnderlyingType = Nullable.GetUnderlyingType(typeToConvert);

      return (UnderlyingType?.IsEnum ?? false, UnderlyingType);
    }

#pragma warning disable CA1812 // Remove class never instantiated
    private class EnumMemberConverter<TEnum> : JsonConverter<TEnum>
        where TEnum : struct, Enum
#pragma warning restore CA1812 // Remove class never instantiated
    {
      private readonly JsonStringEnumMemberConverterHelper<TEnum> _JsonStringEnumMemberConverterHelper;

      public EnumMemberConverter(JsonNamingPolicy? namingPolicy, bool allowIntegerValues)
      {
        _JsonStringEnumMemberConverterHelper = new JsonStringEnumMemberConverterHelper<TEnum>(namingPolicy, allowIntegerValues);
      }

      public override TEnum Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
          => _JsonStringEnumMemberConverterHelper.Read(ref reader);

      public override void Write(Utf8JsonWriter writer, TEnum value, JsonSerializerOptions options)
          => _JsonStringEnumMemberConverterHelper.Write(writer, value);
    }

#pragma warning disable CA1812 // Remove class never instantiated
    private class NullableEnumMemberConverter<TEnum> : JsonConverter<TEnum?>
        where TEnum : struct, Enum
#pragma warning restore CA1812 // Remove class never instantiated
    {
      private readonly JsonStringEnumMemberConverterHelper<TEnum> _JsonStringEnumMemberConverterHelper;

      public NullableEnumMemberConverter(JsonNamingPolicy? namingPolicy, bool allowIntegerValues)
      {
        _JsonStringEnumMemberConverterHelper = new JsonStringEnumMemberConverterHelper<TEnum>(namingPolicy, allowIntegerValues);
      }

      public override TEnum? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
          => _JsonStringEnumMemberConverterHelper.Read(ref reader);

      public override void Write(Utf8JsonWriter writer, TEnum? value, JsonSerializerOptions options)
          => _JsonStringEnumMemberConverterHelper.Write(writer, value!.Value);
    }
  }
}