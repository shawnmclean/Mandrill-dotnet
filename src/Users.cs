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
            try
            {
                return PingAsync().Result;
            }
            catch(AggregateException aex)
            {
                var ex = aex.Flatten();
                //catch and throw the inner exception
                throw aex.Flatten().InnerException;
            }
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