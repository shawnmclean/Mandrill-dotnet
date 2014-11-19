using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mandrill.Models
{
    public class MergeVars
    {
        public string rcpt { get; set; }
        public IEnumerable<TemplateContent> vars { get; set; }
    }
}
