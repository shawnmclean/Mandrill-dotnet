// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DynamicJsonDeserializer.cs" company="">
//   
// </copyright>
// <summary>
//   The dynamic json deserializer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Mandrill.Utilities
{
    using Newtonsoft.Json;

    using RestSharp;
    using RestSharp.Deserializers;

    /// <summary>
    ///     The dynamic json deserializer.
    /// </summary>
    internal class DynamicJsonDeserializer : IDeserializer
    {
        #region Public Properties

        /// <summary>
        ///     Gets or sets the date format.
        /// </summary>
        public string DateFormat { get; set; }

        /// <summary>
        ///     Gets or sets the namespace.
        /// </summary>
        public string Namespace { get; set; }

        /// <summary>
        ///     Gets or sets the root element.
        /// </summary>
        public string RootElement { get; set; }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        ///     The deserialize.
        /// </summary>
        /// <param name="response">
        ///     The response.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        ///     The <see cref="T" />.
        /// </returns>
        public T Deserialize<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<dynamic>(response.Content);
        }

        #endregion
    }
}