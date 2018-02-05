using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace SAM_Server
{
    class SocketHandler
    {
        public Socket server;
        public int port;
        Thread receivingThread;

        public SocketHandler()
        {
            IniHandler ini = new IniHandler();
            port = ini.GetIntSetting("socketPort");
        }

        public void StartServer()
        {
            IPEndPoint point = new IPEndPoint(IPAddress.Any, port);
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Blocking = false;
            server.Bind(point);
            server.Listen(1);
            StartReceiveThread();
        }

        private void StartReceiveThread()
        {
            receivingThread = new Thread(this.ReceiveData);
            receivingThread.Start();
        }

        private void ReceiveData()
        {
            while (receivingThread.IsAlive)
            {
                string data = null;
                byte[] bytes = new Byte[1024];
                try
                {
                    server.Accept();
                }
                catch { }
                data = null;
                while (server.Connected)
                {
                    bytes = new byte[1024];
                    int bytesRec = server.Receive(bytes);
                    data = Encoding.ASCII.GetString(bytes, 0, bytesRec);

                    string response = "";
                    //RUN COMMAND AND GET RESPONSE
                    SendString(server, response);
                    server.Dispose();
                    break;
                }
            }
        }

        private void SendString(Socket handler, string message)
        {
            byte[] msg = Encoding.ASCII.GetBytes(message);
            handler.Send(msg);
        }

        public void StopServer()
        {
            server.Close();
            receivingThread.Abort();
        }
    }
}
