using System;
using System.Net;
using System.Net.Sockets;
using System.Diagnostics;
using System.Text;

namespace Sockets
{
    internal class Sockets
    {
        private const string WEBBROWSER = @"C:\Program Files\Google\Chrome\Application\chrome.exe"; //Change this to your browser path

        public static void ConnectToServer(string IP, int port)
        {
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress mainIP = IPAddress.Parse(IP);

            socket.Connect(mainIP, port);

            Console.Write("> URL : ");
            string? url = Console.ReadLine();

            if(url != null)
            {
                byte[] data = Encoding.ASCII.GetBytes(url);
                socket.Send(data);

                byte[] buffer = new byte[1024];
                int bytesReceived = socket.Receive(buffer);

                string response = Encoding.ASCII.GetString(buffer, 0, bytesReceived);
                Console.WriteLine("> Response : " + response);
            }

            socket.Shutdown(SocketShutdown.Both);
            socket.Close();
        }

        public static void CreateConnection(int port)
        {
            Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            server.Bind(new IPEndPoint(IPAddress.Any, port));

            IPAddress[] IPAddresses = Dns.GetHostAddresses(Dns.GetHostName());

            foreach(IPAddress IPDir in IPAddresses)
            {
                if(IPDir.AddressFamily == AddressFamily.InterNetwork)
                {
                    Console.WriteLine("> IP : " + IPDir.ToString());
                    break;
                }
            }

            server.Listen(2);
            Socket client = server.Accept();

            byte[] buffer = new byte[1024];
            int receivedBytes = client.Receive(buffer);

            string url = Encoding.ASCII.GetString(buffer, 0, receivedBytes);
            Process.Start(WEBBROWSER, url);

            client.Shutdown(SocketShutdown.Both);

            client.Close();
            server.Close();
        }
    }
}
