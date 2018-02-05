using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SAM_Server.Models
{
    class Device
    {
        public int id { get; set; }
        public string ip { get; set; }
        public string name { get; set; }
        public User user { get; set; }
    }
}
