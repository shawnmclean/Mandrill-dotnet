using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;

namespace Mandrill
{
    public partial class MandrillApi
    {
        #region Async Methods

        /// <summary>
        /// Async method to send a new transactional message through Mandrill.
        /// </summary>
        /// <param name="recipients"></param>
        /// <param name="subject"></param>
        /// <param name="content"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public async Task<List<EmailResult>> SendAsync(List<EmailAddress> recipients, string subject, string content, EmailAddress from)
        {
            return await Task.Run(() => Send(recipients, subject, content, from));
        }

        /// <summary>
        /// Async version to send a new transactional message through Mandrill using a template
        /// </summary>
        /// <param name="recipients"></param>
        /// <param name="subject"></param>
        /// <param name="from"></param>
        /// <param name="templateName"></param>
        /// <param name="templateContents"></param>
        /// <returns></returns>
        public async Task<List<EmailResult>> SendAsync(List<EmailAddress> recipients, string subject, EmailAddress from, string templateName, List<TemplateContent> templateContents)
        {
            return await Task.Run(() => Send(recipients, subject, from, templateName, templateContents));
        }

        #endregion Async Methods

        /// <summary>
        /// Send a new transactional message through Mandrill.
        /// </summary>
        /// <param name="recipients"></param>
        /// <param name="subject"></param>
        /// <param name="content"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public List<EmailResult> Send(List<EmailAddress> recipients, string subject, string content, EmailAddress from)
        {
            var request = new RestRequest("/messages/send.json", Method.POST);

            string payload = JsonConvert.SerializeObject(new
            {
                //key= ApiKey,
                message = new
                {
                    subject = subject,
                    html = content,
                    from_email = from.Email,
                    from_name = from.Name,
                    to = recipients
                }
            });

            request.AddParameter("text/json", payload, ParameterType.RequestBody);

            return enumerateMessageResult(client.Execute<dynamic>(request).Data);
        }

        /// <summary>
        /// Send a new transactional message through Mandrill using a template
        /// </summary>
        /// <param name="recipients"></param>
        /// <param name="subject"></param>
        /// <param name="from"></param>
        /// <param name="templateName"></param>
        /// <param name="templateContents"></param>
        /// <returns></returns>
        public List<EmailResult> Send(List<EmailAddress> recipients, string subject, EmailAddress from, string templateName, List<TemplateContent> templateContents)
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
            return enumerateMessageResult(client.Execute<dynamic>(request).Data);
        }

        #region private methods

        /// <summary>
        ///
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private List<EmailResult> enumerateMessageResult(dynamic response)
        {
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
                //try to get the error from the result
                var dict = response as IDictionary;
                if (dict != null && dict.Contains("message"))
                {
                    throw new Exception(response.message);
                }
                else
                {
                    throw new Exception("response was not in an expected format.");
                }
            }
        }

        #endregion private methods
    }
}