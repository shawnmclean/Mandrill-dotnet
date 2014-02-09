// --------------------------------------------------------------------------------------------------------------------
// <copyright file="UserInfo.cs" company="">
//   
// </copyright>
// <summary>
//   The stats.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill
{
    /// <summary>
    ///     The stats.
    /// </summary>
    public struct stats
    {
        #region Fields

        /// <summary>
        ///     The all_time.
        /// </summary>
        public UserInfoStats all_time;

        /// <summary>
        ///     The last_30_days.
        /// </summary>
        public UserInfoStats last_30_days;

        /// <summary>
        ///     The last_60_days.
        /// </summary>
        public UserInfoStats last_60_days;

        /// <summary>
        ///     The last_7_days.
        /// </summary>
        public UserInfoStats last_7_days;

        /// <summary>
        ///     The last_90_days.
        /// </summary>
        public UserInfoStats last_90_days;

        /// <summary>
        ///     The today.
        /// </summary>
        public UserInfoStats today;

        #endregion
    }

    /// <summary>
    ///     The user info stats.
    /// </summary>
    public struct UserInfoStats
    {
        #region Fields

        /// <summary>
        ///     The clicks.
        /// </summary>
        public int clicks;

        /// <summary>
        ///     The complaints.
        /// </summary>
        public int complaints;

        /// <summary>
        ///     The hard_bounces.
        /// </summary>
        public int hard_bounces;

        /// <summary>
        ///     The opens.
        /// </summary>
        public int opens;

        /// <summary>
        ///     The rejects.
        /// </summary>
        public int rejects;

        /// <summary>
        ///     The sent.
        /// </summary>
        public int sent;

        /// <summary>
        ///     The soft_bounces.
        /// </summary>
        public int soft_bounces;

        /// <summary>
        ///     The unique_clicks.
        /// </summary>
        public int unique_clicks;

        /// <summary>
        ///     The unique_opens.
        /// </summary>
        public int unique_opens;

        /// <summary>
        ///     The unsubs.
        /// </summary>
        public int unsubs;

        #endregion
    }

    /// <summary>
    ///     The user info.
    /// </summary>
    public class UserInfo
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the backlog.
        /// </summary>
        public int backlog { get; set; }

        /// <summary>
        ///     Gets or sets the created_at.
        /// </summary>
        public string created_at { get; set; }

        /// <summary>
        ///     Gets or sets the hourly_quota.
        /// </summary>
        public int hourly_quota { get; set; }

        /// <summary>
        ///     Gets or sets the public_id.
        /// </summary>
        public string public_id { get; set; }

        /// <summary>
        ///     Gets or sets the reputation.
        /// </summary>
        public int reputation { get; set; }

        /// <summary>
        ///     Gets or sets the stats.
        /// </summary>
        public stats stats { get; set; }

        /// <summary>
        ///     Gets or sets the username.
        /// </summary>
        public string username { get; set; }

        #endregion
    }
}