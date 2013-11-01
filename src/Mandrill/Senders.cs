// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Senders.cs" company="">
//   
// </copyright>
// <summary>
//   The mandrill api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Mandrill.Models;

    /// <summary>
    /// The mandrill api.
    /// </summary>
    public partial class MandrillApi
    {
        #region Public Methods and Operators

        /// <summary>
        /// The list senders.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Sender> ListSenders()
        {
            return this.ListSendersAsync().Result;
        }

        /// <summary>
        /// The list senders async.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public Task<List<Sender>> ListSendersAsync()
        {
            const string path = "/senders/list.json";

            return this.PostAsync(path, null)
                .ContinueWith(
                    p => JSON.Parse<List<Sender>>(p.Result.Content), 
                    TaskContinuationOptions.ExecuteSynchronously);
        }

        #endregion
    }
}