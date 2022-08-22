// --------------------------------------------------------------------------------------------------------------------
// <copyright file="JSON.cs" company="">
//   
// </copyright>
// <summary>
//   The json.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Mandrill.Utilities
{
  /// <summary>
  ///   The json.
  /// </summary>
  public class JSON
  {
    #region Static Fields

    /// <summary>
    ///   The settings.
    /// </summary>
    public static readonly JsonSerializerOptions settings = new JsonSerializerOptions
    {
      DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
      PropertyNamingPolicy = new SnakeCaseNamingPolicy()
    };

    #endregion

    #region Public Methods and Operators

    /// <summary>
    ///   The parse.
    /// </summary>
    /// <param name="json">
    ///   The json.
    /// </param>
    /// <typeparam name="T">
    /// </typeparam>
    /// <returns>
    ///   The <see cref="T" />.
    /// </returns>
    public static T Parse<T>(string json)
    {
      if (json == null)
        return default(T);

      return JsonSerializer.Deserialize<T>(json, settings);
    }

    /// <summary>
    ///   The serialize.
    /// </summary>
    /// <param name="value">
    ///   The dyn.
    /// </param>
    /// <returns>
    ///   The <see cref="string" />.
    /// </returns>
    public static string Serialize(object value)
    {
      return JsonSerializer.Serialize(value, settings);
    }

    #endregion
  }
}