// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Dkim.cs" company="">
//   
// </copyright>
// <summary>
//   The dkim.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill.Models
{
    /// <summary>
    ///     The dkim.
    /// </summary>
    public class Dkim
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the error.
        /// </summary>
        public string error { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether valid.
        /// </summary>
        public bool valid { get; set; }

        /// <summary>
        ///     Gets or sets the valid_after.
        /// </summary>
        public string valid_after { get; set; }

        #endregion
    }
}