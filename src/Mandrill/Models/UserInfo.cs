using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandrill
{
    public struct stats
    {
        public UserInfoStats today;
        public UserInfoStats last_7_days;
        public UserInfoStats last_30_days;
        public UserInfoStats last_60_days;
        public UserInfoStats last_90_days;
        public UserInfoStats all_time;
    }

    public struct UserInfoStats
    {
        public int sent;
        public int hard_bounces;
        public int soft_bounces;
        public int rejects;
        public int complaints;
        public int unsubs;
        public int opens;
        public int unique_opens;
        public int clicks;
        public int unique_clicks;
    }

    public class UserInfo
    {
        public string username { get; set; }
        public string created_at { get; set; }
        public string public_id { get; set; }
        public int reputation { get; set; }
        public int hourly_quota { get; set; }
        public int backlog { get; set; }
        public stats stats { get; set; }
    }
}
