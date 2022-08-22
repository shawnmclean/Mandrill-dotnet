// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SmtpEvent.cs" company="">
//   
// </copyright>
// <summary>
//   The smtp event.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Text.Json.Serialization;

namespace Mandrill.Models
{
  /// <summary>
  ///   The smtp event.
  /// </summary>
  public class SmtpEvent
  {
    #region Public Properties

    /// <summary>
    ///   Gets the time stamp.
    /// </summary>
    public DateTime TimeStamp
    {
      get { return WebHookEvent.FromUnixTime(Ts); }
    }

    /// <summary>
    ///   Gets or sets the destination_ip.
    /// </summary>
    [JsonPropertyName("destination_ip")]
    public string DestinationIp { get; set; }

    /// <summary>
    ///   Gets or sets the diag.
    /// </summary>
    [JsonPropertyName("diag")]
    public string Diag { get; set; }

    /// <summary>
    ///   Gets or sets the size.
    /// </summary>
    [JsonPropertyName("size")]
    public int Size { get; set; }

    /// <summary>
    ///   Gets or sets the source_ip.
    /// </summary>
    [JsonPropertyName("source_ip")]
    public string SourceIp { get; set; }

    /// <summary>
    ///   Gets or sets the ts.
    /// </summary>
    [JsonPropertyName("ts")]
    public int Ts { get; set; }

    /// <summary>
    ///   Gets or sets the type.
    /// </summary>
    [JsonPropertyName("type")]
    [JsonConverter(typeof(JsonStringEnumMemberConverter))]
    public SearchResultState Type { get; set; }

    #endregion
  }
}