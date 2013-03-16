using Mandrill.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandrill
{
    public partial class MandrillApi
    {

        public Task<List<Sender>> ListSendersAsync()
        {
            const string path = "/senders/list.json";

            return this.PostAsync(path, null).ContinueWith(
                p => JSON.Parse<List<Sender>>(p.Result.Content),
                TaskContinuationOptions.ExecuteSynchronously);
        }

        public List<Sender> LisSenders()
        {
            return this.ListSendersAsync().Result;
        }
    }
}
