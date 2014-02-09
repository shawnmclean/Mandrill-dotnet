// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Search.cs" company="">
//   
// </copyright>
// <summary>
//   The search.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill
{
    /// <summary>
    ///     The search.
    /// </summary>
    public class Search
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the date_from.
        /// </summary>
        public string date_from { get; set; }

        /// <summary>
        ///     Gets or sets the date_to.
        /// </summary>
        public string date_to { get; set; }

        /// <summary>
        ///     Gets or sets the limit.
        /// </summary>
        public string limit { get; set; }

        /// <summary>
        ///     Gets or sets the query.
        /// </summary>
        public string query { get; set; }

        /// <summary>
        ///     Gets or sets the senders.
        /// </summary>
        public string[] senders { get; set; }

        /// <summary>
        ///     Gets or sets the tags.
        /// </summary>
        public string[] tags { get; set; }

        #endregion
    }
}