// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Rejects.cs" company="">
//   
// </copyright>
// <summary>
//   The mandrill api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using Mandrill.Models;
using Mandrill.Models.Requests;

namespace Mandrill
{
  using System;
  using System.Collections.Generic;
  using System.Dynamic;
  using System.Threading.Tasks;

  /// <summary>
  /// The mandrill api.
  /// </summary>
  public partial class MandrillApi
  {
    #region Public Methods and Operators


    /// <summary>
    /// Adds the reject.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>Task&lt;RejectAddResult&gt;.</returns>
    public async Task<RejectAddResult> AddReject(AddRejectRequest request) {
      var path = "/rejects/add.json";

      var response = await Post<RejectAddResult>(path, request);

      return response;
    }


    /// <summary>
    /// The delete reject.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The <see cref="RejectDeleteResult" />.</returns>
    /// <exception cref="Exception"></exception>
    public async Task<RejectDeleteResult> DeleteReject(DeleteRejectRequest request) {

      var path = "/rejects/delete.json";

      var response = await Post<RejectDeleteResult>(path, request);

      return response;
    }


    /// <summary>
    /// Lists the rejects.
    /// </summary>
    /// <param name="email">email address to limit the results</param>
    /// <returns>The <see cref="List" />.</returns>
    public List<RejectInfo> ListRejects(string email = "") {
      try {
        return this.ListRejectsAsync(email).Result;
      } catch (AggregateException aex) {
        // catch and throw the inner exception
        throw aex.Flatten().InnerException;
      }
    }

    /// <summary>
    /// Lists the rejects asynchronous.
    /// </summary>
    /// <param name="email">email address to limit the results</param>
    /// <returns>The <see cref="Task" />.</returns>
    public Task<List<RejectInfo>> ListRejectsAsync(string email = "") {
      string path = "/rejects/list.json";

      dynamic param = new ExpandoObject();
      param.email = email;
      return this.PostAsync<List<RejectInfo>>(path, param);
    }

    #endregion
  }
}