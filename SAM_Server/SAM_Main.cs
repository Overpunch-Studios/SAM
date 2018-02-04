using SAM_Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SAM_Server
{
    public partial class SAM_Main : Form
    {
        public SAM_Main()
        {
            InitializeComponent();
        }

        private void SAM_Main_Load(object sender, EventArgs e)
        {
            Login();
            GetCommands();
            GetDevices();
            VoiceRecognition sam = new VoiceRecognition("advanced");
            sam.Recognize();
            //SendRequest();
            
        }

        private void SendRequest()
        {
            WebRequest request = new WebRequest();
            string apikey = request.PostData("http://127.0.0.1:8000/api/login", "email=admin@test.com&password=toptal").token;
            string response = request.PostData("http://127.0.0.1:8000/api/user", "api_token=" + apikey).id;
            MessageBox.Show(response);
        }

        private void Login()
        {
            WebRequest request = new WebRequest();
            string apikey = request.PostData("http://127.0.0.1:8000/api/login", "email=admin@test.com&password=toptal").token;
            dynamic result = request.PostData("http://127.0.0.1:8000/api/user", "api_token=" + apikey);
            Program.user.id = result.id;
            Program.user.username = result.username;
            Program.user.token = apikey;
        }

        private void GetCommands()
        {
            Command[] commands = new Command[1];
            WebRequest request = new WebRequest();

            string ids = request.PostData("http://127.0.0.1:8000/api/commands/range", "api_token=" + Program.user.token).ids;
            string[] idsArr = ids.Split(',');

            commands = new Command[idsArr.Length];

            for(int i = 0; i < idsArr.Length; i++)
            {
                commands[i] = new Command();

                dynamic result = request.PostData("http://127.0.0.1:8000/api/commands/" + idsArr[i], "api_token=" + Program.user.token);

                commands[i].id = result.id;
                commands[i].request = result.request;
                commands[i].response = result.response;
            }

            Program.commands = commands;
        }

        private void GetDevices()
        {
            Device[] devices = new Device[1];
            WebRequest request = new WebRequest();

            string ids = request.PostData("http://127.0.0.1:8000/api/devices/range", "api_token=" + Program.user.token).ids;
            string[] idsArr = ids.Split(',');

            devices = new Device[idsArr.Length];

            for (int i = 0; i < idsArr.Length; i++)
            {
                devices[i] = new Device();
                devices[i].user = new User();
                dynamic result = request.PostData("http://127.0.0.1:8000/api/devices/" + idsArr[i], "api_token=" + Program.user.token);

                devices[i].id = result.id;
                devices[i].ip = result.ip;
                devices[i].name = result.name;
                devices[i].user.id = result.user.id;
                devices[i].user.username = result.user.username;
                devices[i].user.token = "EMPTY";
            }

            Program.devices = devices;

            MessageBox.Show($"There are {Program.devices.Length} devices available");
        }

        private void SAM_Main_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }
    }
}
