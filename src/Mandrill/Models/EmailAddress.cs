// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EmailAddress.cs" company="">
//   
// </copyright>
// <summary>
//   The email address.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill
{
    /// <summary>
    ///     The email address.
    /// </summary>
    public class EmailAddress
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailAddress" /> class.
        /// </summary>
        public EmailAddress()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailAddress" /> class.
        /// </summary>
        /// <param name="email">
        ///     The email.
        /// </param>
        public EmailAddress(string email)
        {
            this.email = email;
            this.name = string.Empty;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailAddress" /> class.
        /// </summary>
        /// <param name="email">
        ///     The email.
        /// </param>
        /// <param name="name">
        ///     The name.
        /// </param>
        public EmailAddress(string email, string name)
        {
            this.email = email;
            this.name = name;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="EmailAddress" /> class.
        /// </summary>
        /// <param name="email">
        ///     The email.
        /// </param>
        /// <param name="name">
        ///     The name.
        /// </param>
        /// <param name="type">
        ///     The type.
        /// </param>
        public EmailAddress(string email, string name, string type)
        {
            this.email = email;
            this.name = name;
            this.type = type;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the email.
        /// </summary>
        public string email { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string name { get; set; }

        /// <summary>
        ///     The header type to use for the recipient, defaults to "to" if not provided
        ///     oneof(to, cc, bcc)
        /// </summary>
        public string type { get; set; }

        #endregion
    }
}