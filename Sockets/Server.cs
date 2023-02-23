using System;
using System.Collections.Generic;

namespace Sockets
{
    internal class Server
    {
        public static void InitializeServer()
        {
            Console.Write("> Port : ");
            int port = Convert.ToInt32(Console.ReadLine());

            Sockets.CreateConnection(port);
        }
    }
}
