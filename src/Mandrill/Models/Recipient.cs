using Newtonsoft.Json;

namespace Mandrill.Models
{
  /// <summary>
  ///   Message recipient's information.
  /// </summary>
  public class Recipient
  {
    #region Public Properties

    /// <summary>
    ///   Email address of the recipient.
    /// </summary>
    public string Email { get; set; }

    /// <summary>
    ///   Alias of the recipient (if any).
    /// </summary>
    public string Name { get; set; }

    #endregion
  }
}