using System;
using System.Threading.Tasks;
using RestSharp;

namespace Mandrill
{
    public partial class MandrillApi
    {
        public UserInfo UserInfo()
        {
            return UserInfoAsync().Result;            
        }

        /// <summary>
        /// Return the information about the API-connected user
        /// </summary>
        /// <returns></returns>
        /// <see cref="https://mandrillapp.com/api/docs/users.html#method=info"/>
        public Task<UserInfo> UserInfoAsync()
        {
            var path = "/users/info.json";
            return PostAsync<UserInfo>(path, null);
        }

        /// <summary>
        /// Validate an API key and respond to a ping
        /// </summary>
        /// <returns></returns>
        public string Ping()
        {
            return PingAsync().Result;
        }

        /// <summary>
        /// Validate an API key and respond to a ping
        /// </summary>
        /// <returns></returns>
        public Task<string> PingAsync()
        {
            var path = "/users/ping.json";
            return PostAsync(path, null).ContinueWith(p =>
            {
                return p.Result.Content;
            });
        }
    }
}