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
    public string Address { get; set; }

    /// <summary>
    ///   Gets or sets the clicks.
    /// </summary>
    public int Clicks { get; set; }

    /// <summary>
    ///   Gets or sets the complaints.
    /// </summary>
    public int Complaints { get; set; }

    /// <summary>
    ///   Gets or sets the created_at.
    /// </summary>
    public string CreatedAt { get; set; }

    /// <summary>
    ///   Gets or sets the hard_bounces.
    /// </summary>
    public int HardBounces { get; set; }

    /// <summary>
    ///   Gets or sets the opens.
    /// </summary>
    public int Opens { get; set; }

    /// <summary>
    ///   Gets or sets the rejects.
    /// </summary>
    public int Rejects { get; set; }

    /// <summary>
    ///   Gets or sets the sent.
    /// </summary>
    public int Sent { get; set; }

    /// <summary>
    ///   Gets or sets the soft_bounces.
    /// </summary>
    public int SoftBounces { get; set; }

    /// <summary>
    ///   Gets or sets the unsubs.
    /// </summary>
    public int Unsubs { get; set; }

    #endregion
  }
}