// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Rejects.cs" company="">
//   
// </copyright>
// <summary>
//   The mandrill api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill
{
    using System;
    using System.Collections.Generic;
    using System.Dynamic;
    using System.Threading.Tasks;

    /// <summary>
    ///     The mandrill api.
    /// </summary>
    public partial class MandrillApi
    {
        #region Public Methods and Operators

        /// <summary>
        ///     The add reject.
        /// </summary>
        /// <param name="email">
        ///     The email address to block
        /// </param>
        /// <param name="comment">
        ///     An optional comment describing the rejection
        /// </param>
        /// <param name="subaccount">
        ///     An optional unique identifier for the subaccount to limit the blacklist entry
        /// </param>
        /// <returns>
        ///     The <see cref="RejectAddResult" />.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public RejectAddResult AddReject(string email, string comment = "", string subaccount = "")
        {
            try
            {
                return this.AddRejectAsync(email, comment, subaccount).Result;
            }
            catch (AggregateException aex)
            {
                // catch and throw the inner exception
                throw aex.Flatten().InnerException;
            }
        }

        /// <summary>
        ///     The add reject async.
        /// </summary>
        /// <param name="email">
        ///     The email address to block
        /// </param>
        /// <param name="comment">
        ///     An optional comment describing the rejection
        /// </param>
        /// <param name="subaccount">
        ///     An optional unique identifier for the subaccount to limit the blacklist entry
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<RejectAddResult> AddRejectAsync(string email, string comment = "", string subaccount = "")
        {
            string path = "/rejects/add.json";

            dynamic param = new ExpandoObject();
            param.email = email;
            if(!string.IsNullOrEmpty(comment))
                param.comment = comment;
            if(!string.IsNullOrEmpty(subaccount))               
                param.subaccount = subaccount;
            return this.PostAsync<RejectAddResult>(path, param);
        }

        /// <summary>
        ///     The delete reject.
        /// </summary>
        /// <param name="email">
        ///     The email.
        /// </param>
        /// <returns>
        ///     The <see cref="RejectDeleteResult" />.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public RejectDeleteResult DeleteReject(string email)
        {
            try
            {
                return this.DeleteRejectAsync(email).Result;
            }
            catch (AggregateException aex)
            {
                // catch and throw the inner exception
                throw aex.Flatten().InnerException;
            }
        }

        /// <summary>
        ///     The delete reject async.
        /// </summary>
        /// <param name="email">
        ///     The email.
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<RejectDeleteResult> DeleteRejectAsync(string email)
        {
            string path = "/rejects/delete.json";

            dynamic param = new ExpandoObject();
            param.email = email;
            return this.PostAsync<RejectDeleteResult>(path, param);
        }

        /// <summary>
        /// </summary>
        /// <param name="email">
        ///     email address to limit the results
        /// </param>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        public List<RejectInfo> ListRejects(string email = "")
        {
            try
            {
                return this.ListRejectsAsync(email).Result;
            }
            catch (AggregateException aex)
            {
                // catch and throw the inner exception
                throw aex.Flatten().InnerException;
            }
        }

        /// <summary>
        /// </summary>
        /// <param name="email">
        ///     email address to limit the results
        /// </param>
        /// <returns>
        ///     The <see cref="Task" />.
        /// </returns>
        public Task<List<RejectInfo>> ListRejectsAsync(string email = "")
        {
            string path = "/rejects/list.json";

            dynamic param = new ExpandoObject();
            param.email = email;
            return this.PostAsync<List<RejectInfo>>(path, param);
        }

        #endregion
    }
}