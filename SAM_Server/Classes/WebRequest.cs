using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Flurl.Http;

namespace SAM_Server
{
    class WebRequest
    {
        public WebRequest()
        {

        }

        public dynamic PostData(string address, string args)
        {
            try
            {
                string response = address.PostUrlEncodedAsync(args).ReceiveString().Result;
                return JsonConvert.DeserializeObject(response);
            }
            catch
            {
                return null;
            }
        }
        public dynamic GetData(string address)
        {
            try
            {
                string response = address.GetStringAsync().Result;
                return JsonConvert.DeserializeObject(response);
            }
            catch
            {
                return null;
            }
        }
    }
}
