// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailAddress.cs" company="">
//   
// </copyright>
// <summary>
//   The email address.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Text.Json.Serialization;

namespace Mandrill.Models
{
  /// <summary>
  ///   The email address.
  /// </summary>
  public class EmailAddress
  {
    #region Constructors and Destructors

    /// <summary>
    ///   Initializes a new instance of the <see cref="EmailAddress" /> class.
    /// </summary>
    public EmailAddress()
    {
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="EmailAddress" /> class.
    /// </summary>
    /// <param name="email">
    ///   The email.
    /// </param>
    public EmailAddress(string email)
    {
      Email = email;
      Name = string.Empty;
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="EmailAddress" /> class.
    /// </summary>
    /// <param name="email">
    ///   The email.
    /// </param>
    /// <param name="name">
    ///   The name.
    /// </param>
    public EmailAddress(string email, string name)
    {
      Email = email;
      Name = name;
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="EmailAddress" /> class.
    /// </summary>
    /// <param name="email">
    ///   The email.
    /// </param>
    /// <param name="name">
    ///   The name.
    /// </param>
    /// <param name="type">
    ///   The type.
    /// </param>
    public EmailAddress(string email, string name, string type)
    {
      Email = email;
      Name = name;
      Type = type;
    }

    #endregion

    #region Public Properties

    /// <summary>
    ///   Gets or sets the email.
    /// </summary>
    [JsonPropertyName("email")]
    public string Email { get; set; }

    /// <summary>
    ///   Gets or sets the name.
    /// </summary>
    [JsonPropertyName("name")]
    public string Name { get; set; }

    /// <summary>
    ///   The header type to use for the recipient, defaults to "to" if not provided
    ///   oneof(to, cc, bcc)
    /// </summary>
    [JsonPropertyName("type")]
    public string Type { get; set; }

    #endregion
  }
}