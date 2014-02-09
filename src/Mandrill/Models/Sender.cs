// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Sender.cs" company="">
//   
// </copyright>
// <summary>
//   The sender.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill.Models
{
    /// <summary>
    ///     The sender.
    /// </summary>
    public class Sender
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the address.
        /// </summary>
        public string address { get; set; }

        /// <summary>
        ///     Gets or sets the clicks.
        /// </summary>
        public int clicks { get; set; }

        /// <summary>
        ///     Gets or sets the complaints.
        /// </summary>
        public int complaints { get; set; }

        /// <summary>
        ///     Gets or sets the created_at.
        /// </summary>
        public string created_at { get; set; }

        /// <summary>
        ///     Gets or sets the hard_bounces.
        /// </summary>
        public int hard_bounces { get; set; }

        /// <summary>
        ///     Gets or sets the opens.
        /// </summary>
        public int opens { get; set; }

        /// <summary>
        ///     Gets or sets the rejects.
        /// </summary>
        public int rejects { get; set; }

        /// <summary>
        ///     Gets or sets the sent.
        /// </summary>
        public int sent { get; set; }

        /// <summary>
        ///     Gets or sets the soft_bounces.
        /// </summary>
        public int soft_bounces { get; set; }

        /// <summary>
        ///     Gets or sets the unsubs.
        /// </summary>
        public int unsubs { get; set; }

        #endregion
    }
}