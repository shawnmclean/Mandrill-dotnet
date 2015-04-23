// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sender.cs" company="">
//   
// </copyright>
// <summary>
//   The sender.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace Mandrill.Models
{
  /// <summary>
  ///   The sender.
  /// </summary>
  public class Sender
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets the address.
    /// </summary>
    [JsonProperty("address")]
    public string Address { get; set; }

    /// <summary>
    ///   Gets or sets the clicks.
    /// </summary>
    [JsonProperty("clicks")]
    public int Clicks { get; set; }

    /// <summary>
    ///   Gets or sets the complaints.
    /// </summary>
    [JsonProperty("complaints")]
    public int Complaints { get; set; }

    /// <summary>
    ///   Gets or sets the created_at.
    /// </summary>
    [JsonProperty("created_at")]
    public string CreatedAt { get; set; }

    /// <summary>
    ///   Gets or sets the hard_bounces.
    /// </summary>
    [JsonProperty("hard_bounces")]
    public int HardBounces { get; set; }

    /// <summary>
    ///   Gets or sets the opens.
    /// </summary>
    [JsonProperty("opens")]
    public int Opens { get; set; }

    /// <summary>
    ///   Gets or sets the rejects.
    /// </summary>
    [JsonProperty("rejects")]
    public int Rejects { get; set; }

    /// <summary>
    ///   Gets or sets the sent.
    /// </summary>
    [JsonProperty("sent")]
    public int Sent { get; set; }

    /// <summary>
    ///   Gets or sets the soft_bounces.
    /// </summary>
    [JsonProperty("soft_bounces")]
    public int SoftBounces { get; set; }

    /// <summary>
    ///   Gets or sets the unsubs.
    /// </summary>
    [JsonProperty("unsubs")]
    public int Unsubs { get; set; }

    #endregion
  }
}