// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserInfo.cs" company="">
//   
// </copyright>
// <summary>
//   The stats.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Newtonsoft.Json;

namespace Mandrill.Models
{
  /// <summary>
  ///   The stats.
  /// </summary>
  public class Stats
  {
    #region Fields

    /// <summary>
    ///   The all_time.
    /// </summary>
    public UserInfoStats AllTime { get; set; }

    /// <summary>
    ///   The last_30_days.
    /// </summary>
    public UserInfoStats Last30Days { get; set; }

    /// <summary>
    ///   The last_60_days.
    /// </summary>
    public UserInfoStats Last60Days { get; set; }

    /// <summary>
    ///   The last_7_days.
    /// </summary>
    public UserInfoStats Last7Days { get; set; }

    /// <summary>
    ///   The last_90_days.
    /// </summary>
    public UserInfoStats Last90Days { get; set; }

    /// <summary>
    ///   The today.
    /// </summary>
    public UserInfoStats Today { get; set; }

    #endregion
  }

  /// <summary>
  ///   The user info stats.
  /// </summary>
  public class UserInfoStats
  {
    #region Fields

    /// <summary>
    ///   The clicks.
    /// </summary>
    public int Clicks { get; set; }

    /// <summary>
    ///   The complaints.
    /// </summary>
    public int Complaints { get; set; }

    /// <summary>
    ///   The hard_bounces.
    /// </summary>
    public int HardBounces { get; set; }

    /// <summary>
    ///   The opens.
    /// </summary>
    public int Opens { get; set; }

    /// <summary>
    ///   The rejects.
    /// </summary>
    public int Rejects { get; set; }

    /// <summary>
    ///   The sent.
    /// </summary>
    public int Sent { get; set; }

    /// <summary>
    ///   The soft_bounces.
    /// </summary>
    public int SoftBounces { get; set; }

    /// <summary>
    ///   The unique_clicks.
    /// </summary>
    public int UniqueClicks { get; set; }

    /// <summary>
    ///   The unique_opens.
    /// </summary>
    public int UniqueOpens { get; set; }

    /// <summary>
    ///   The unsubs.
    /// </summary>
    public int Unsubs { get; set; }

    #endregion
  }

  /// <summary>
  ///   The user info.
  /// </summary>
  public class UserInfo
  {
    #region Public Properties

    /// <summary>
    ///   Gets or sets the backlog.
    /// </summary>
    public int Backlog { get; set; }

    /// <summary>
    ///   Gets or sets the created_at.
    /// </summary>
    public string CreatedAt { get; set; }

    /// <summary>
    ///   Gets or sets the hourly_quota.
    /// </summary>
    public int HourlyQuota { get; set; }

    /// <summary>
    ///   Gets or sets the public_id.
    /// </summary>
    public string PublicId { get; set; }

    /// <summary>
    ///   Gets or sets the reputation.
    /// </summary>
    public int Reputation { get; set; }

    /// <summary>
    ///   Gets or sets the stats.
    /// </summary>
    public Stats Stats { get; set; }

    /// <summary>
    ///   Gets or sets the username.
    /// </summary>
    public string Username { get; set; }

    #endregion
  }
}