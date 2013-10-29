
namespace Mandrill
{
    public class EmailAddress
    {
        public string email { get; set; }
        public string name { get; set; }
        /// <summary>
        /// The header type to use for the recipient, defaults to "to" if not provided
        /// oneof(to, cc, bcc)
        /// </summary>
        public string type { get; set; }

        public EmailAddress() { }

        public EmailAddress(string email)
        {
            this.email = email;
            this.name = "";
        }

        public EmailAddress(string email, string name)
        {
            this.email = email;
            this.name = name;
        }

        public EmailAddress(string email, string name, string type)
        {
            this.email = email;
            this.name = name;
            this.type = type;
        }
    }
}