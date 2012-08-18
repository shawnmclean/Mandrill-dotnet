using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Mandrill.Utilities;
using Newtonsoft.Json;
using RestSharp;

namespace Mandrill
{
    public class MandrillApi
    {
        #region Properties
        /// <summary>
        /// The Api Key for the project received from the PostageApp website
        /// </summary>
        public string ApiKey { get; private set; }

        #endregion

        #region Fields

        private RestClient client;
        #endregion

        public MandrillApi(string apiKey)
        {
            ApiKey = apiKey;

            client = new RestClient(Configuration.BASE_URL);
            //client.AddDefaultParameter("key", ApiKey);
            client.AddHandler("application/json", new DynamicJsonDeserializer());
        }

        public dynamic Info()
        {
            var request = new RestRequest("/users/info.json", Method.POST);
            request.AddParameter("text/json", new {key = ApiKey}, ParameterType.RequestBody);
            var response = client.Execute<dynamic>(request);
            return response.Data;
        }

        public void Send(List<EmailAddress> recipients, string subject, string content, EmailAddress from)
        {
            var request = new RestRequest("/messages/send.json", Method.POST);

            string payload = JsonConvert.SerializeObject(new
                              {
                                  key= ApiKey,
                                  message=new
                                              {
                                                  subject = subject,
                                                  html = content,
                                                  from_email=from.Email,
                                                  from_name=from.Name,
                                                  to= recipients
                                              }
                              });

            request.AddParameter("text/json", payload, ParameterType.RequestBody);
            var response = client.Execute<dynamic>(request);
        }
        public void Send(List<EmailAddress> recipients, string subject, EmailAddress from, string templateName, List<TemplateContent> templateContents)
        {
            var request = new RestRequest("/messages/send-template.json", Method.POST);

            string payload = JsonConvert.SerializeObject(new
            {
                key = ApiKey,
                message = new
                {
                    subject = subject,
                    from_email = from.Email,
                    from_name = from.Name,
                    to = recipients
                },
                template_name = templateName,
                template_content = templateContents
            });

            request.AddParameter("text/json", payload, ParameterType.RequestBody);
            var response = client.Execute<dynamic>(request);
        }
    }

    public class EmailAddress
    {
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class TemplateContent
    {

        [JsonProperty("content")]
        public string Content { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
