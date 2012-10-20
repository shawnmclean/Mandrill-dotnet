using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandrill
{
    public struct ErrorResponse
    {
        public string status;
        public int code;
        public string name;
        public string message; 
    }
}
