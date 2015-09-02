// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Senders.cs" company="">
//   
// </copyright>
// <summary>
//   The mandrill api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests;
using Mandrill.Requests.Senders;

namespace Mandrill
{
  /// <summary>
  ///   The mandrill api.
  /// </summary>
  public partial class MandrillApi
  {
    #region Public Methods and Operators

    /// <summary>
    ///   The list senders.
    /// </summary>
    /// <param name="request">The request.</param>
    /// <returns>
    ///   a <see cref="SenderDomain" />
    /// </returns>
    public async Task<SenderDomain> CheckSenderDomain(SenderCheckDomainRequest request)
    {
      string path = "senders/check-domain.json";

      SenderDomain response = await Post<SenderDomain>(path, request);

      return response;
    }

    /// <summary>
    ///   The list senders.
    /// </summary>
    /// <returns>
    ///   The <see cref="List" />.
    /// </returns>
    public async Task<List<Sender>> ListSenders()
    {
      const string path = "senders/list.json";

      List<Sender> response = await Post<List<Sender>>(path, new RequestBase());

      return response;
    }


    /// <summary>
    ///   The list senders.
    /// </summary>
    /// <returns>
    ///   The <see cref="List" />.
    /// </returns>
    public async Task<List<SenderDomain>> SenderDomains()
    {
      const string path = "senders/domains.json";

      List<SenderDomain> response = await Post<List<SenderDomain>>(path, new RequestBase());

      return response;
    }

    #endregion
  }
}