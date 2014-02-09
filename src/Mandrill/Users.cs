// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Users.cs" company="">
//   
// </copyright>
// <summary>
//   The mandrill api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill
{
    using System;
    using System.Threading.Tasks;

    /// <summary>
    ///     The mandrill api.
    /// </summary>
    public partial class MandrillApi
    {
        #region Public Methods and Operators

        /// <summary>
        ///     Validate an API key and respond to a ping
        /// </summary>
        /// <returns>
        ///     The <see cref="string" />.
        /// </returns>
        public string Ping()
        {
            try
            {
                return this.PingAsync().Result;
            }
            catch (AggregateException aex)
            {
                // catch and throw the inner exception
                throw aex.Flatten().InnerException;
            }
        }

        /// <summary>
        ///     Validate an API key and respond to a ping
        /// </summary>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<string> PingAsync()
        {
            string path = "/users/ping.json";
            return this.PostAsync(path, null).ContinueWith(p => { return p.Result.Content; });
        }

        /// <summary>
        ///     The user info.
        /// </summary>
        /// <returns>
        ///     The <see cref="UserInfo" />.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public UserInfo UserInfo()
        {
            try
            {
                return this.UserInfoAsync().Result;
            }
            catch (AggregateException aex)
            {
                // catch and throw the inner exception
                throw aex.Flatten().InnerException;
            }
        }

        /// <summary>
        ///     Return the information about the API-connected user
        /// </summary>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        /// <see cref="https://mandrillapp.com/api/docs/users.html#method=info" />
        public Task<UserInfo> UserInfoAsync()
        {
            string path = "/users/info.json";
            return this.PostAsync<UserInfo>(path, null);
        }

        #endregion
    }
}