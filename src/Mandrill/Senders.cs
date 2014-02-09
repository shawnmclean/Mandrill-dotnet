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
    using System.Dynamic;
    using System.Threading.Tasks;

    using Mandrill.Models;

    using RestSharp;

    /// <summary>
    ///     The mandrill api.
    /// </summary>
    public partial class MandrillApi
    {
        #region Public Methods and Operators

        /// <summary>
        ///     The list senders.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <returns>
        ///     a <see cref="SenderDomain" />
        /// </returns>
        public SenderDomain CheckSenderDomain(string domain)
        {
            return this.CheckSenderDomainAsync(domain).Result;
        }

        /// <summary>
        ///     The list senders async.
        /// </summary>
        /// <param name="domain">The domain.</param>
        /// <returns>
        ///     The <see cref="Task{SenderDomain}" />.
        /// </returns>
        public Task<SenderDomain> CheckSenderDomainAsync(string domain)
        {
            const string path = "/senders/check-domain.json";

            dynamic payload = new ExpandoObject();
            payload.domain = domain;

            Task<IRestResponse> post = this.PostAsync(path, payload);

            return post.ContinueWith(
                p => JSON.Parse<SenderDomain>(p.Result.Content),
                TaskContinuationOptions.ExecuteSynchronously);
        }

        /// <summary>
        ///     The list senders.
        /// </summary>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        public List<Sender> ListSenders()
        {
            return this.ListSendersAsync().Result;
        }

        /// <summary>
        ///     The list senders async.
        /// </summary>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<List<Sender>> ListSendersAsync()
        {
            const string path = "/senders/list.json";

            return this.PostAsync(path, null)
                .ContinueWith(
                    p => JSON.Parse<List<Sender>>(p.Result.Content),
                    TaskContinuationOptions.ExecuteSynchronously);
        }

        /// <summary>
        ///     The list senders.
        /// </summary>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        public List<SenderDomain> SenderDomains()
        {
            return this.SenderDomainsAsync().Result;
        }

        /// <summary>
        ///     The list senders async.
        /// </summary>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<List<SenderDomain>> SenderDomainsAsync()
        {
            const string path = "/senders/domains.json";

            return this.PostAsync(path, null)
                .ContinueWith(
                    p => JSON.Parse<List<SenderDomain>>(p.Result.Content),
                    TaskContinuationOptions.ExecuteSynchronously);
        }

        #endregion
    }
}