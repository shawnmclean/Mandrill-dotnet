// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserInfo.cs" company="">
//   
// </copyright>
// <summary>
//   The stats.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

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
    [JsonPropertyName("all_time")]
    public UserInfoStats AllTime { get; set; }

    /// <summary>
    ///   The last_30_days.
    /// </summary>
    [JsonPropertyName("last_30_days")]
    public UserInfoStats Last30Days { get; set; }

    /// <summary>
    ///   The last_60_days.
    /// </summary>
    [JsonPropertyName("last_60_days")]
    public UserInfoStats Last60Days { get; set; }

    /// <summary>
    ///   The last_7_days.
    /// </summary>
    [JsonPropertyName("last_7_days")]
    public UserInfoStats Last7Days { get; set; }

    /// <summary>
    ///   The last_90_days.
    /// </summary>
    [JsonPropertyName("last_90_days")]
    public UserInfoStats Last90Days { get; set; }

    /// <summary>
    ///   The today.
    /// </summary>
    [JsonPropertyName("today")]
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
    [JsonPropertyName("clicks")]
    public int Clicks { get; set; }

    /// <summary>
    ///   The complaints.
    /// </summary>
    [JsonPropertyName("complaints")]
    public int Complaints { get; set; }

    /// <summary>
    ///   The hard_bounces.
    /// </summary>
    [JsonPropertyName("hard_bounces")]
    public int HardBounces { get; set; }

    /// <summary>
    ///   The opens.
    /// </summary>
    [JsonPropertyName("opens")]
    public int Opens { get; set; }

    /// <summary>
    ///   The rejects.
    /// </summary>
    [JsonPropertyName("rejects")]
    public int Rejects { get; set; }

    /// <summary>
    ///   The sent.
    /// </summary>
    [JsonPropertyName("sent")]
    public int Sent { get; set; }

    /// <summary>
    ///   The soft_bounces.
    /// </summary>
    [JsonPropertyName("soft_bounces")]
    public int SoftBounces { get; set; }

    /// <summary>
    ///   The unique_clicks.
    /// </summary>
    [JsonPropertyName("unique_clicks")]
    public int UniqueClicks { get; set; }

    /// <summary>
    ///   The unique_opens.
    /// </summary>
    [JsonPropertyName("unique_opens")]
    public int UniqueOpens { get; set; }

    /// <summary>
    ///   The unsubs.
    /// </summary>
    [JsonPropertyName("unsubs")]
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
    [JsonPropertyName("backlog")]
    public int Backlog { get; set; }

    /// <summary>
    ///   Gets or sets the created_at.
    /// </summary>
    [JsonPropertyName("created_at")]
    public string CreatedAt { get; set; }

    /// <summary>
    ///   Gets or sets the hourly_quota.
    /// </summary>
    [JsonPropertyName("hourly_quota")]
    public int HourlyQuota { get; set; }

    /// <summary>
    ///   Gets or sets the public_id.
    /// </summary>
    [JsonPropertyName("public_id")]
    public string PublicId { get; set; }

    /// <summary>
    ///   Gets or sets the reputation.
    /// </summary>
    [JsonPropertyName("reputation")]
    public int Reputation { get; set; }

    /// <summary>
    ///   Gets or sets the stats.
    /// </summary>
    [JsonPropertyName("stats")]
    public Stats Stats { get; set; }

    /// <summary>
    ///   Gets or sets the username.
    /// </summary>
    [JsonPropertyName("username")]
    public string Username { get; set; }

    #endregion
  }
}