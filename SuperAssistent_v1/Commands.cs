using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperAssistent_v1
{
    class Commands
    {
        private string[] commands = {
            "open"
        };

        public Commands()
        {

        }

        public void CheckCommand (string cmd)
        {
            if (cmd.Contains("open"))
            {
                cmd.Split(' ');
            }
        }




        public string[] GetCommands()
        {
            return commands;
        }
    }
}
