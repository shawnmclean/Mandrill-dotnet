// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Spf.cs" company="">
//   
// </copyright>
// <summary>
//   The spf.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill.Models
{
    /// <summary>
    ///     The spf.
    /// </summary>
    public class Spf
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