// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorResponse.cs" company="">
//   
// </copyright>
// <summary>
//   The error response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

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
    [JsonProperty("code")]
    public int Code { get; set; }

    /// <summary>
    ///   The message.
    /// </summary>
    [JsonProperty("message")]
    public string Message { get; set; }

    /// <summary>
    ///   The name.
    /// </summary>
    [JsonProperty("name")]
    public string Name { get; set; }

    /// <summary>
    ///   The status.
    /// </summary>
    [JsonProperty("status")]
    public string Status { get; set; }

    #endregion
  }
}