using serverEngine.Connections;
using serverEngine.Debug;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace serverEngine
{
    class Program
    {
        public static bool IsRunning;

        private static Socket _serverListenerSocket;
        public static List<Connection> Connections;
        private static List<Connection> DisconnectedConnections;

        private static int LastTime;
        private static int CurrentTime;

        private static void Main(string[] args)
        {
            //init
            IsRunning = false;
            LastTime = 0;
            CurrentTime = 0;
            Connections = new List<Connection>(Config.MaxPlayers);
            DisconnectedConnections = new List<Connection>(Config.MaxPlayers);
            
            try
            {
                //maakt ipendpoint voor server listening
                //luistert naar 
                var iPEndPoint = new IPEndPoint(0, Config.ServerPort);
                _serverListenerSocket = new Socket(iPEndPoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                _serverListenerSocket.Bind(iPEndPoint);
                _serverListenerSocket.Listen(25);
                _serverListenerSocket.BeginAccept(new AsyncCallback(acceptCallback), _serverListenerSocket);

                IsRunning = true;
                Debugging.WriteLine($"--[{Config.ServerName} started on port {Config.ServerPort}]--", ConsoleColor.Red);
                //start de game update thread.
                new Thread(new ThreadStart(GameThread)).Start();
            }
            catch (SocketException ioe)
            {
                Debugging.WriteLine($"Error: {ioe.Message}", ConsoleColor.Red);

                IsRunning = false;
            }
        }
        
        private static void GameThread()
        {
            while (IsRunning)
            {
                RemoveConnections();

                Console.Title = $" [{Connections.Count} : Connections] ";

                CurrentTime = Environment.TickCount;
                LastTime = CurrentTime;

                lock (Connections)
                {
                    foreach (Connection con in Connections)
                    {
                        con.ProcessPackets();
                    }
                }
                
                try
                {
                    Thread.Sleep(500 - (Environment.TickCount - CurrentTime));
                }
                catch
                { }
            }

            Console.WriteLine("Server successful afgesloten.");
            Console.ReadLine();
        }

        private static void acceptCallback(IAsyncResult result)
        {
            Connection connection = null;


            try
            {
                Socket s = (Socket)result.AsyncState;
                connection = new Connection();
                connection.socket = s.EndAccept(result);
                connection.buffer = new byte[5000];

                lock (Connections)
                {
                    Connections.Add(connection);
                }

                connection.socket.BeginReceive(connection.buffer, 0, connection.buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), connection);
                _serverListenerSocket.BeginAccept(new AsyncCallback(acceptCallback), _serverListenerSocket);
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);

                if (connection.socket != null)
                {
                    connection.socket.Close();
                    lock (Connections)
                    {
                        DisconnectConnection(connection);
                    }
                }

                _serverListenerSocket.BeginAccept(new AsyncCallback(acceptCallback), _serverListenerSocket);
            }
            catch (Exception)
            {
                if (connection.socket != null)
                {
                    connection.socket.Close();
                    lock (Connections)
                    {
                        DisconnectConnection(connection);
                    }
                }

                _serverListenerSocket.BeginAccept(new AsyncCallback(acceptCallback), _serverListenerSocket);
            }
        }

        private static void ReceiveCallback(IAsyncResult result)
        {
            Connection connection = (Connection)result.AsyncState;

            try
            {
                if (connection == null || connection.socket == null) return;

                int bytesRead = connection.socket.EndReceive(result);

                if (bytesRead > 0)
                {
                    connection.AppendChuckedPackets(bytesRead);
                    connection.PacketDecoder();
                    connection.socket.BeginReceive(connection.buffer, 0, connection.buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), connection);
                }
                else
                {

                    connection.socket.Close();
                    lock (Connections)
                    {
                        DisconnectConnection(connection);

                    }
                }

            }
            catch (Exception e)
            {
                if (e is SocketException || e is ObjectDisposedException)
                {
                    if (connection.socket != null)
                    {
                        connection.socket.Close();
                        lock (Connections)
                        {
                            DisconnectConnection(connection);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Receiver: " + e.Message);
                }
            }
        }

        public static void DisconnectConnection(Connection connection)
        {
            Connections.Remove(connection);
        }

        private static void RemoveConnections()
        {

            if (DisconnectedConnections.Count > 0)
            {
                List<Connection> removedCons = new List<Connection>();
                foreach (Connection con in DisconnectedConnections)
                {
                    Connections.Remove(con);
                    removedCons.Add(con);
                }

                for (int i = 0; i < removedCons.Count; i++)
                {
                    DisconnectedConnections.Remove(removedCons[i]);
                }
            }
        }
    }
}
