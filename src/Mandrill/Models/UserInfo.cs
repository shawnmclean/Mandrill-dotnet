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
    [JsonProperty("all_time")]
    public UserInfoStats AllTime { get; set; }

    /// <summary>
    ///   The last_30_days.
    /// </summary>
    [JsonProperty("last_30_days")]
    public UserInfoStats Last30Days { get; set; }

    /// <summary>
    ///   The last_60_days.
    /// </summary>
    [JsonProperty("last_60_days")]
    public UserInfoStats Last60Days { get; set; }

    /// <summary>
    ///   The last_7_days.
    /// </summary>
    [JsonProperty("last_7_days")]
    public UserInfoStats Last7Days { get; set; }

    /// <summary>
    ///   The last_90_days.
    /// </summary>
    [JsonProperty("last_90_days")]
    public UserInfoStats Last90Days { get; set; }

    /// <summary>
    ///   The today.
    /// </summary>
    [JsonProperty("today")]
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
    [JsonProperty("clicks")]
    public int Clicks { get; set; }

    /// <summary>
    ///   The complaints.
    /// </summary>
    [JsonProperty("complaints")]
    public int Complaints { get; set; }

    /// <summary>
    ///   The hard_bounces.
    /// </summary>
    [JsonProperty("hard_bounces")]
    public int HardBounces { get; set; }

    /// <summary>
    ///   The opens.
    /// </summary>
    [JsonProperty("opens")]
    public int Opens { get; set; }

    /// <summary>
    ///   The rejects.
    /// </summary>
    [JsonProperty("rejects")]
    public int Rejects { get; set; }

    /// <summary>
    ///   The sent.
    /// </summary>
    [JsonProperty("sent")]
    public int Sent { get; set; }

    /// <summary>
    ///   The soft_bounces.
    /// </summary>
    [JsonProperty("soft_bounces")]
    public int SoftBounces { get; set; }

    /// <summary>
    ///   The unique_clicks.
    /// </summary>
    [JsonProperty("unique_clicks")]
    public int UniqueClicks { get; set; }

    /// <summary>
    ///   The unique_opens.
    /// </summary>
    [JsonProperty("unique_opens")]
    public int UniqueOpens { get; set; }

    /// <summary>
    ///   The unsubs.
    /// </summary>
    [JsonProperty("unsubs")]
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
    [JsonProperty("backlog")]
    public int Backlog { get; set; }

    /// <summary>
    ///   Gets or sets the created_at.
    /// </summary>
    [JsonProperty("created_at")]
    public string CreatedAt { get; set; }

    /// <summary>
    ///   Gets or sets the hourly_quota.
    /// </summary>
    [JsonProperty("hourly_quota")]
    public int HourlyQuota { get; set; }

    /// <summary>
    ///   Gets or sets the public_id.
    /// </summary>
    [JsonProperty("public_id")]
    public string PublicId { get; set; }

    /// <summary>
    ///   Gets or sets the reputation.
    /// </summary>
    [JsonProperty("reputation")]
    public int Reputation { get; set; }

    /// <summary>
    ///   Gets or sets the stats.
    /// </summary>
    [JsonProperty("stats")]
    public Stats Stats { get; set; }

    /// <summary>
    ///   Gets or sets the username.
    /// </summary>
    [JsonProperty("username")]
    public string Username { get; set; }

    #endregion
  }
}