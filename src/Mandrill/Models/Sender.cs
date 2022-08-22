// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sender.cs" company="">
//   
// </copyright>
// <summary>
//   The sender.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

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
    [JsonPropertyName("address")]
    public string Address { get; set; }

    /// <summary>
    ///   Gets or sets the clicks.
    /// </summary>
    [JsonPropertyName("clicks")]
    public int Clicks { get; set; }

    /// <summary>
    ///   Gets or sets the complaints.
    /// </summary>
    [JsonPropertyName("complaints")]
    public int Complaints { get; set; }

    /// <summary>
    ///   Gets or sets the created_at.
    /// </summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    /// <summary>
    ///   Gets or sets the hard_bounces.
    /// </summary>
    [JsonPropertyName("hard_bounces")]
    public int HardBounces { get; set; }

    /// <summary>
    ///   Gets or sets the opens.
    /// </summary>
    [JsonPropertyName("opens")]
    public int Opens { get; set; }

    /// <summary>
    ///   Gets or sets the rejects.
    /// </summary>
    [JsonPropertyName("rejects")]
    public int Rejects { get; set; }

    /// <summary>
    ///   Gets or sets the sent.
    /// </summary>
    [JsonPropertyName("sent")]
    public int Sent { get; set; }

    /// <summary>
    ///   Gets or sets the soft_bounces.
    /// </summary>
    [JsonPropertyName("soft_bounces")]
    public int SoftBounces { get; set; }

    /// <summary>
    ///   Gets or sets the unsubs.
    /// </summary>
    [JsonPropertyName("unsubs")]
    public int Unsubs { get; set; }

    /// <summary>
    ///   Gets or sets the stats.
    /// </summary>
    [JsonPropertyName("stats")]
    public Stats Stats { get; set; }

    #endregion
  }
}