using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
        #region Async Methods

        public async Task<dynamic> InfoAsyc()
        {
            return await Task.Run(() => Info());
        }



        #endregion
        public dynamic Info()
        {
            var request = new RestRequest("/users/info.json", Method.POST);
            request.AddParameter("key", ApiKey);
            var response = client.Execute<dynamic>(request);
            return response.Data;
        }

        public List<EmailResult> Send(List<EmailAddress> recipients, string subject, string content, EmailAddress from)
        {
            var request = new RestRequest("/messages/send.json", Method.POST);

            string payload = JsonConvert.SerializeObject(new
                              {
                                  //key= ApiKey,
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
            var response = client.Execute<dynamic>(request).Data;

            var emailResults = new List<EmailResult>();
            //result comes back as array, if loop doesn't work, error occured.
            try
            {
                foreach (var result in response)
                {
                    emailResults.Add(new EmailResult
                                         {
                                             Email = result.email,
                                             IsSuccess = result.status == "success"
                                         });
                }
                return emailResults;
            }
            catch (Exception ex)
            {
                //if (response.status == "error")
                    throw new Exception();
            }
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
}
