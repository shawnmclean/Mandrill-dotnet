
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


namespace Mandrill.Models.Requests
{
  /// <summary>
  /// Class AddRejectRequest.
  /// </summary>
  public class AddRejectRequest : RequestBase
  {
    /// <summary>
    /// Gets or sets the email.
    /// </summary>
    /// <value>The email.</value>
    [JsonProperty("email")]
    public string Email { get; set; }
    /// <summary>
    /// Gets or sets the comment.
    /// </summary>
    /// <value>The comment.</value>
    [JsonProperty("comment")]
    public string Comment { get; set; }
    /// <summary>
    /// Gets or sets the subaccount.
    /// </summary>
    /// <value>The subaccount.</value>
    [JsonProperty("subaccount")]
    public string SubAccount { get; set; }
  }
}
