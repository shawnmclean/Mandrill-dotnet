using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace PostageApp
{
    public class Mandrill
    {
        #region Properties
        /// <summary>
        /// The Api Key for the project received from the PostageApp website
        /// </summary>
        public string ApiKey { get; set; }

        #endregion
        public Mandrill()
        {
        }

        public Mandrill(string apiKey)
        {
            ApiKey = apiKey;
        }

        public dynamic GetAccountInformation()
        {
            throw new NotImplementedException();
        }



    }
}
