// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SmtpEvent.cs" company="">
//   
// </copyright>
// <summary>
//   The smtp event.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

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
    public string DestinationIp { get; set; }

    /// <summary>
    ///   Gets or sets the diag.
    /// </summary>
    public string Diag { get; set; }

    /// <summary>
    ///   Gets or sets the size.
    /// </summary>
    public int Size { get; set; }

    /// <summary>
    ///   Gets or sets the source_ip.
    /// </summary>
    public string SourceIp { get; set; }

    /// <summary>
    ///   Gets or sets the ts.
    /// </summary>
    public int Ts { get; set; }

    /// <summary>
    ///   Gets or sets the type.
    /// </summary>
    [JsonConverter(typeof (StringEnumConverter))]
    public SearchResultState Type { get; set; }

    #endregion
  }
}