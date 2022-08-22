using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mandrill.Converters
{
  public class DictionaryJsonConverter<TValue> : JsonConverter<Dictionary<string, TValue>>
  {
    private readonly JsonConverter<TValue> _valueConverter;
    private readonly Type _valueType;

    public DictionaryJsonConverter()
    {
      // Cache the key and value types.
      _valueType = typeof(TValue);
    }

    public DictionaryJsonConverter(JsonSerializerOptions options) : this()
    {
      // For performance, use the existing converter if available.
      _valueConverter = (JsonConverter<TValue>)options.GetConverter(typeof(TValue));
    }

    public override Dictionary<string, TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
      if (reader.TokenType != JsonTokenType.StartObject)
      {
        throw new JsonException();
      }

      var dictionary = new Dictionary<string, TValue>();

      while (reader.Read())
      {
        if (reader.TokenType == JsonTokenType.EndObject)
        {
          return dictionary;
        }

        // Get the key.
        if (reader.TokenType != JsonTokenType.PropertyName)
        {
          throw new JsonException();
        }

        var key = reader.GetString();

        // Get the value.
        TValue value;

        if (_valueConverter != null)
        {
          reader.Read();
          value = _valueConverter.Read(ref reader, _valueType, options)!;
        }
        else
        {
          value = JsonSerializer.Deserialize<TValue>(ref reader, options)!;
        }

        // Add to dictionary.
        dictionary.Add(key, value);
      }

      throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, Dictionary<string, TValue> dictionary, JsonSerializerOptions options)
    {
      writer.WriteStartObject();

      foreach (var item in dictionary)
      {
        var propertyName = item.Key.ToString();
        writer.WritePropertyName
            (options.PropertyNamingPolicy?.ConvertName(propertyName) ?? propertyName);

        if (_valueConverter != null)
        {
          _valueConverter.Write(writer, item.Value, options);
        }
        else
        {
          JsonSerializer.Serialize(writer, item.Value, options);
        }
      }

      writer.WriteEndObject();
    }
  }
}
