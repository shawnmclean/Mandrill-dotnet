// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Info.cs" company="">
//   
// </copyright>
// <summary>
//   The info.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill
{
    /// <summary>
    ///     The info.
    /// </summary>
    public class Info
    {
        #region Constructors and Destructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="Info" /> class.
        /// </summary>
        public Info()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="Info" /> class.
        /// </summary>
        /// <param name="id">
        ///     The id.
        /// </param>
        public Info(string id)
        {
            this.id = id;
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Gets or sets the id.
        /// </summary>
        public string id { get; set; }

        #endregion
    }
}