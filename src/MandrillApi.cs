using Mandrill.Utilities;
using RestSharp;

namespace Mandrill
{
    /// <summary>
    /// Core class for using the MandrillApp Api
    /// </summary>
    public partial class MandrillApi
    {
        #region Properties

        /// <summary>
        /// The Api Key for the project received from the MandrillApp website
        /// </summary>
        public string ApiKey { get; private set; }

        #endregion Properties

        #region Fields
        /// <summary>
        /// the main rest client for use throughout the whole app.
        /// </summary>
        private RestClient client;

        #endregion Fields

        /// <summary>
        ///
        /// </summary>
        /// <param name="apiKey">The API Key recieved from MandrillApp</param>
        public MandrillApi(string apiKey)
        {
            ApiKey = apiKey;

            client = new RestClient(Configuration.BASE_URL);
            //client.AddDefaultParameter("key", ApiKey);
            client.AddHandler("application/json", new DynamicJsonDeserializer());
        }
    }
}