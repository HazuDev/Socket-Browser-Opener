using System;
using System.Collections.Generic;

namespace Sockets
{
    internal class Client
    {
        public static void InitializeClient()
        {
            Console.Write("> IP : ");
            string? IP = Console.ReadLine();

            if(IP != null)
            {
                Console.Write("> Port : ");
                int port = Convert.ToInt32(Console.ReadLine());

                Sockets.ConnectToServer(IP, port);
            }
        }
    }
}