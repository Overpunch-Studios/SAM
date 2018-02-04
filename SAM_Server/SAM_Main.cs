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
            VoiceRecognition sam = new VoiceRecognition();
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
    }
}
