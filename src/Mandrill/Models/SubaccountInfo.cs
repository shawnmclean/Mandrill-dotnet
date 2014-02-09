namespace Mandrill
{
    using Newtonsoft.Json;

    public class SubaccountInfo
    {
        #region Public Properties

        /// <summary>
        ///     The date and time that the subaccount was created as a UTC string in YYYY-MM-DD HH:MM:SS format
        /// </summary>
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }

        /// <summary>
        ///     An optional manual hourly quota for the subaccount. If not specified, the hourly quota will be managed based on
        ///     reputation
        /// </summary>
        [JsonProperty("custom_quota", NullValueHandling = NullValueHandling.Ignore)]
        public int? CustomQuota { get; set; }

        /// <summary>
        ///     The date and time that the subaccount first sent as a UTC string in YYYY-MM-DD HH:MM:SS format
        /// </summary>
        [JsonProperty("first_sent_at")]
        public string FirstSentAt { get; set; }

        /// <summary>
        ///     A unique indentifier for the subaccount
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        ///     Stats for this subaccount in the last 30 days
        /// </summary>
        [JsonProperty("last_30_days")]
        public Last30Days Last30Days { get; set; }

        /// <summary>
        ///     An optional display name for the subaccount
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }

        /// <summary>
        ///     The subaccount's current reputation on a scale from 0 to 100
        /// </summary>
        [JsonProperty("reputation")]
        public int Reputation { get; set; }

        /// <summary>
        ///     The number of emails the subaccount has sent so far this month (months start on midnight of the 1st, UTC)
        /// </summary>
        [JsonProperty("sent_monthly")]
        public int SentMonthly { get; set; }

        /// <summary>
        ///     The number of emails the subaccount has sent since it was created
        /// </summary>
        [JsonProperty("sent_total")]
        public int SentTotal { get; set; }

        /// <summary>
        ///     The number of emails the subaccount has sent so far this week (weeks start on midnight Monday, UTC)
        /// </summary>
        [JsonProperty("sent_weekly")]
        public int SentWeekly { get; set; }

        /// <summary>
        ///     The current sending status of the subaccount, one of "active" or "paused"
        /// </summary>
        [JsonProperty("status")]
        public string Status { get; set; }

        #endregion
    }

    public class Last30Days
    {
        #region Public Properties

        /// <summary>
        ///     The number of URLs that have been clicked for this subaccount in the last 30 days
        /// </summary>
        [JsonProperty("clicks")]
        public int Clicks { get; set; }

        /// <summary>
        ///     The number of spam complaints for this subaccount in the last 30 days
        /// </summary>
        [JsonProperty("complaints")]
        public int Complaints { get; set; }

        /// <summary>
        ///     The number of emails hard bounced for this subaccount in the last 30 days
        /// </summary>
        [JsonProperty("hard_bounces")]
        public int HardBounces { get; set; }

        /// <summary>
        ///     The number of times emails have been opened for this subaccount in the last 30 days
        /// </summary>
        [JsonProperty("opens")]
        public int Opens { get; set; }

        /// <summary>
        ///     The number of emails rejected for sending this subaccount in the last 30 days
        /// </summary>
        [JsonProperty("rejects")]
        public int Rejects { get; set; }

        /// <summary>
        ///     The number of emails sent for this subaccount in the last 30 days
        /// </summary>
        [JsonProperty("sent")]
        public int Sent { get; set; }

        /// <summary>
        ///     The number of emails soft bounced for this subaccount in the last 30 days
        /// </summary>
        [JsonProperty("soft_bounces")]
        public int SoftBounces { get; set; }

        /// <summary>
        ///     The number of unique clicks for emails sent for this subaccount in the last 30 days
        /// </summary>
        [JsonProperty("unique_clicks")]
        public int UniqueClicks { get; set; }

        /// <summary>
        ///     The number of unique opens for emails sent for this subaccount in the last 30 days
        /// </summary>
        [JsonProperty("unique_opens")]
        public int UniqueOpens { get; set; }

        /// <summary>
        ///     The number of unsbuscribes for this subaccount in the last 30 days
        /// </summary>
        [JsonProperty("unsubs")]
        public int Unsubs { get; set; }

        #endregion
    }
}