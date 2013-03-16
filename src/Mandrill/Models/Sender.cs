using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mandrill.Models
{
    public class Sender
    {
        public string address { get; set; }
        public string created_at { get; set; }
        public int sent { get; set; }
        public int hard_bounces { get; set; }
        public int soft_bounces { get; set; }
        public int rejects { get; set; }
        public int complaints { get; set; }
        public int unsubs { get; set; }
        public int opens { get; set; }
        public int clicks { get; set; }
    }
}
