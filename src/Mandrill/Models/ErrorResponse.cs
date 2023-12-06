// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorResponse.cs" company="">
//   
// </copyright>
// <summary>
//   The error response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Mandrill.Models
{
  /// <summary>
  ///   The error response.
  /// </summary>
  public class ErrorResponse
  {
    #region Fields

    /// <summary>
    ///   The code.
    /// </summary>
    [JsonPropertyName("code")]
    public int Code { get; set; }

    /// <summary>
    ///   The message.
    /// </summary>
    [JsonPropertyName("message")]
    public string Message { get; set; }

    /// <summary>
    ///   The name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///   The status.
    /// </summary>
    [JsonPropertyName("status")]
    public string Status { get; set; }

    #endregion
  }
}