// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Search.cs" company="">
//   
// </copyright>
// <summary>
//   The search.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace Mandrill.Requests.Messages
{
  /// <summary>
  ///   The search.
  /// </summary>
  public class SearchRequest : RequestBase
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets the date_from.
    /// </summary>
    [JsonProperty("date_from")]
    public string DateFrom { get; set; }

    /// <summary>
    ///   Gets or sets the date_to.
    /// </summary>
    [JsonProperty("date_to")]
    public string DateTo { get; set; }

    /// <summary>
    ///   Gets or sets the limit.
    /// </summary>
    [JsonProperty("limit")]
    public string Limit { get; set; }

    /// <summary>
    ///   Gets or sets the query.
    /// </summary>
    [JsonProperty("query")]
    public string Query { get; set; }

    /// <summary>
    ///   Gets or sets the senders.
    /// </summary>
    [JsonProperty("senders")]
    public string[] Senders { get; set; }

    /// <summary>
    ///   Gets or sets the tags.
    /// </summary>
    [JsonProperty("tags")]
    public string[] Tags { get; set; }

    #endregion
  }
}