using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mandrill
{
    public struct merge_var
    {
        public string name;
        public string content;
    }

    public class rcpt_merge_var
    {
        public string rcpt;
        public List<merge_var> vars;

        public rcpt_merge_var()
        {
            vars = new List<merge_var>();
        }
    }

    public struct rcpt_metadata
    {
        public string rcpt;
        public IEnumerable<string> values;
    }

    public struct attachment 
    {
        public string type;
        public string name;
        public string content;
    }

    public class EmailMessage
    {
        public string html { get; set; }
        public string text { get; set; }
        public string subject { get; set; }
        public string from_email { get; set; }
        public string from_name { get; set; }
        public IEnumerable<EmailAddress> to { get; set; }
        public JsonObject headers { get; private set; }
        public bool track_opens { get; set; }
        public bool track_clicks { get; set; }
        public bool auto_text { get; set; }
        public bool url_strip_qs { get; set; }
        public bool preserve_recipients { get; set; }
        public string bcc_address { get; set; }
        public bool merge { get; set; }
        public List<merge_var> global_merge_vars { get; private set; }
        public List<rcpt_merge_var> merge_vars { get; private set; }
        public IEnumerable<string> tags { get; set; }
        public IEnumerable<string> google_analytics_domains { get; set; }
        public string google_analytics_campaign { get; set; }
        public IEnumerable<KeyValuePair<string,string>> metadata { get; set; }
        public IEnumerable<rcpt_metadata> recipient_metadata { get; set; }
        public IEnumerable<attachment> attachments { get; set; }

        public void AddGlobalVariable(string name, string content)
        {
            if (global_merge_vars == null)
            {
                global_merge_vars = new List<merge_var>();
            }

            var mv = new merge_var()
            {
                name = name,
                content = content
            };
            global_merge_vars.Add(mv);
        }

        public void AddHeader(string name, string value)
        {
            if (this.headers == null)
            {
                this.headers = new JsonObject();
            }

            this.headers[name] = value;
        }

        public void AddRecipientVariable(string recipient, string name, string content)
        {
            if (merge_vars == null)
            {
                merge_vars = new List<rcpt_merge_var>();
            }

            var entry = merge_vars.Where(e => e.rcpt == recipient).FirstOrDefault();
            if (entry == null)
            {
                entry = new rcpt_merge_var{rcpt = recipient};
                merge_vars.Add(entry);
            }

            var mv = new merge_var()
            {
                name = name,
                content = content
            };

            entry.vars.Add(mv);
        }
    }
}
