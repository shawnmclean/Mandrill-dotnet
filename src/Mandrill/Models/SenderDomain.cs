// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SenderDomain.cs" company="">
//   
// </copyright>
// <summary>
//   The sender domain.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill.Models
{
    /// <summary>
    ///     The sender domain.
    /// </summary>
    public class SenderDomain
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the created_at.
        /// </summary>
        public string created_at { get; set; }

        /// <summary>
        ///     Gets or sets the dkim.
        /// </summary>
        public Dkim dkim { get; set; }

        /// <summary>
        ///     Gets or sets the domain.
        /// </summary>
        public string domain { get; set; }

        /// <summary>
        ///     Gets or sets the last_tested_at.
        /// </summary>
        public string last_tested_at { get; set; }

        /// <summary>
        ///     Gets or sets the spf.
        /// </summary>
        public Spf spf { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether valid_signing.
        /// </summary>
        public bool valid_signing { get; set; }

        /// <summary>
        ///     Gets or sets the verified_at.
        /// </summary>
        public string verified_at { get; set; }

        #endregion
    }
}