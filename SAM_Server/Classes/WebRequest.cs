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



        public dynamic GetData(string address)
        {
            string response = address.GetStringAsync().Result;
            dynamic json = JsonConvert.DeserializeObject(response);
            return json;
        }
    }
}
