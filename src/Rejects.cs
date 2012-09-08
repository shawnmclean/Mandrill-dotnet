using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandrill
{
    public partial class MandrillApi
    {
        public RejectDeleteResult DeleteReject(string email)
        {
            try
            {
                return DeleteRejectAsync(email).Result;
            }
            catch (AggregateException aex)
            {
                //catch and throw the inner exception
                throw aex.Flatten().InnerException;
            }
        }
        public Task<RejectDeleteResult> DeleteRejectAsync(string email)
        {
            var path = "/rejects/delete.json";
            return PostAsync<RejectDeleteResult>(path, null);
        }
    }
}
