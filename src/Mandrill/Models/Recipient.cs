using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mandrill
{
    /// <summary>
    /// Message recipient's information.
    /// </summary>
    public class Recipient
    {
        /// <summary>
        /// Email address of the recipient.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; }

        /// <summary>
        /// Alias of the recipient (if any).
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
