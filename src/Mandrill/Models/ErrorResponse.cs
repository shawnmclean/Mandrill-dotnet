// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ErrorResponse.cs" company="">
//   
// </copyright>
// <summary>
//   The error response.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill
{
    /// <summary>
    ///     The error response.
    /// </summary>
    public struct ErrorResponse
    {
        #region Fields

        /// <summary>
        ///     The code.
        /// </summary>
        public int code;

        /// <summary>
        ///     The message.
        /// </summary>
        public string message;

        /// <summary>
        ///     The name.
        /// </summary>
        public string name;

        /// <summary>
        ///     The status.
        /// </summary>
        public string status;

        #endregion
    }
}