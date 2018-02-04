using SAM_Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAM_Server
{
    static class Program
    {
        public static User user;
        public static Device[] devices;
        public static Command[] commands;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            user = new User();
            commands = new Command[0];
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new SAM_Main());
        }
    }
}
