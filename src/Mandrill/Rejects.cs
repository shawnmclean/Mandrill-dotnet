// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Rejects.cs" company="">
//   
// </copyright>
// <summary>
//   The mandrill api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests.Rejects;

namespace Mandrill
{
  /// <summary>
  ///   The mandrill api.
  /// </summary>
  public partial class MandrillApi
  {
    #region Public Methods and Operators

    /// <summary>
    ///   Adds the reject.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>Task&lt;RejectAddResult&gt;.</returns>
    public async Task<RejectAddResult> AddReject(AddRejectRequest request)
    {
      string path = "rejects/add.json";

      RejectAddResult response = await Post<RejectAddResult>(path, request);

      return response;
    }


    /// <summary>
    ///   The delete reject.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>The <see cref="RejectDeleteResult" />.</returns>
    /// <exception cref="Exception"></exception>
    public async Task<RejectDeleteResult> DeleteReject(DeleteRejectRequest request)
    {
      string path = "rejects/delete.json";

      RejectDeleteResult response = await Post<RejectDeleteResult>(path, request);

      return response;
    }


    /// <summary>
    ///   Lists the rejects.
    /// </summary>
    /// <param name="request">The request</param>
    /// <returns>The <see cref="List" />.</returns>
    public async Task<List<RejectInfo>> ListRejects(ListRejectsRequest request)
    {
      string path = "rejects/list.json";

      List<RejectInfo> response = await Post<List<RejectInfo>>(path, request);

      return response;
    }

    #endregion
  }
}