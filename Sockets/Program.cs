using System;
using System.Collections.Generic;

namespace Sockets
{
    class Program
    {
        static void ProcessOption(int option)
        {
            switch (option)
            {
                case 1: Server.InitializeServer(); break;
                case 2: Client.InitializeClient(); break;
                default: Console.WriteLine("> Invalid option!"); break;
            }
        }

        static void Main(string[] args)
        {
            Console.Write("(1 - Create server | 2 - Create client)\r\n> Option : ");
            int option = Convert.ToInt32(Console.ReadLine());

            ProcessOption(option);
        }
    }
}