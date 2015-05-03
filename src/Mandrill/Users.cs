// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Users.cs" company="">
//   
// </copyright>
// <summary>
//   The mandrill api.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Threading.Tasks;
using Mandrill.Models;
using Mandrill.Requests;

namespace Mandrill
{
  /// <summary>
  ///   The mandrill api.
  /// </summary>
  public partial class MandrillApi
  {
    #region Public Methods and Operators

    /// <summary>
    ///   Validate an API key and respond to a ping
    /// </summary>
    /// <returns>
    ///   The <see cref="string" />.
    /// </returns>
    public async Task<string> Ping()
    {
      string path = "/users/ping.json";

      string response = await Post<string>(path, new RequestBase());

      return response;
    }

    /// <summary>
    ///   Return the information about the API-connected user
    /// </summary>
    /// <returns>
    ///   The <see cref="Task" />.
    /// </returns>
    /// <see cref="https://mandrillapp.com/api/docs/users.html#method=info" />
    public Task<UserInfo> UserInfo()
    {
      string path = "/users/info.json";

      Task<UserInfo> response = Post<UserInfo>(path, new RequestBase());

      return response;
    }

    #endregion
  }
}