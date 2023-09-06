using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Assignment1
{
    public class ConnectedClient
    {
        public string Username { get; }
        public TcpClient Client { get; }

        public ConnectedClient(string username, TcpClient client)
        {
            Username = username;
            Client = client;
        }
    }
}
