using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Assignment1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //This should *definitely* be more descriptive.
            Console.WriteLine("hey so like welcome to my server");
            int port = 12345; // Choose your desired port
            SimpleChatServer server = new SimpleChatServer(port);
            server.Start();
        }
    }
}
