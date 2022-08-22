// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Search.cs" company="">
//   
// </copyright>
// <summary>
//   The search.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Mandrill.Requests.Messages
{
  /// <summary>
  ///   Search Request.
  /// </summary>
  public class SearchRequest : RequestBase
  {
    #region Public Properties

    /// <summary>
    ///   Start date.
    /// </summary>
    [JsonPropertyName("date_from")]
    public DateTime? DateFrom { get; set; }

    /// <summary>
    ///   End date.
    /// </summary>
    [JsonPropertyName("date_to")]
    public DateTime? DateTo { get; set; }

    /// <summary>
    ///   The maximum number of results to return, defaults to 100, 1000 is the maximum.
    /// </summary>
    [JsonPropertyName("limit")]
    public int? Limit { get; set; }

    /// <summary>
    ///   Search terms to find matching messages
    /// </summary>
    [JsonPropertyName("query")]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
    public string Query { get; set; }

    /// <summary>
    ///   An array of sender addresses to narrow the search to, will return messages sent by ANY of the senders.
    /// </summary>
    [JsonPropertyName("senders")]
    public IEnumerable<string> Senders { get; set; }

    /// <summary>
    ///   An array of tag names to narrow the search to, will return messages that contain ANY of the tags.
    /// </summary>
    [JsonPropertyName("tags")]
    public IEnumerable<string> Tags { get; set; }

    /// <summary>
    /// An array of API keys to narrow the search to, will return messages sent by ANY of the keys.
    /// </summary>
    [JsonPropertyName("api_keys")]
    public IEnumerable<string> ApiKeys { get; set; }

    #endregion
  }
}