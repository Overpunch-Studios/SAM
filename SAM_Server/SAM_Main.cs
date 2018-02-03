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
            string response = request.GetData("https://swapi.co/api/people/1/").name;
            MessageBox.Show(response);
        }
    }
}
