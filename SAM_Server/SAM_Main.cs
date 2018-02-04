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
            VoiceRecognition sam = new VoiceRecognition("advanced");
            while (true)
            {
                sam.Recognize();
            }
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
    }
}
