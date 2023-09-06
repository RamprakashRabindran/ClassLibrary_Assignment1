using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp_Assignment1
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;

    public class SimpleChatServer
    {
        private TcpListener listener;
        private List<ConnectedClient> connectedClients;

        public SimpleChatServer(int port)
        {
            listener = new TcpListener(IPAddress.Any, port);
            connectedClients = new List<ConnectedClient>();
        }

        public void Start()
        {
            listener.Start();
            Console.WriteLine($"Server listening on port {((IPEndPoint)listener.LocalEndpoint).Port}...");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client connected.");

                // Handle the client in a separate thread.
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }

        private void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();

            // Prompt the client for a username
            byte[] usernamePrompt = Encoding.ASCII.GetBytes("Enter your username: ");
            stream.Write(usernamePrompt, 0, usernamePrompt.Length);

            byte[] usernameBuffer = new byte[1024];
            int bytesRead = stream.Read(usernameBuffer, 0, usernameBuffer.Length);
            string username = Encoding.ASCII.GetString(usernameBuffer, 0, bytesRead);

            if (IsUsernameUnique(username))
            {
                // Add the client to the list of connected clients
                ConnectedClient connectedClient = new ConnectedClient(username, client);
                connectedClients.Add(connectedClient);

                // Notify the client that they have successfully joined
                byte[] successMessage = Encoding.ASCII.GetBytes($"Welcome, {username}!\n");
                stream.Write(successMessage, 0, successMessage.Length);

                // Handle user interaction here
                // You can implement message distribution, private messaging, etc.
            }
            else
            {
                // Notify the client that the username is already in use
                byte[] errorMessage = Encoding.ASCII.GetBytes("Username already in use. Please choose another.\n");
                stream.Write(errorMessage, 0, errorMessage.Length);

                // Close the client connection
                client.Close();
            }
        }

        private bool IsUsernameUnique(string username)
        {
            // Check if the username is unique among connected clients
            lock (connectedClients)
            {
                foreach (var client in connectedClients)
                {
                    if (client.Username.Equals(username, StringComparison.OrdinalIgnoreCase))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        // Other methods for message distribution, private messaging, etc. can be added here.
    }
}
