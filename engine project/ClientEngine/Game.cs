using clientEngine.Net;
using ClientEngine.Objects;
using serverEngine.Connections;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace ClientEngine
{
    partial class Game : Form
    {
        private List<GameObject> _gameObjects = Assembly.GetExecutingAssembly().GetTypes()
                                                        .Where(t => t.IsSubclassOf(typeof(GameObject)) && !t.IsAbstract).
                                                            Select(t => (GameObject)Activator.CreateInstance(t)).ToList().Where(x=>x.IsActive).ToList();
        public IGameObject Camera = new Camera();

        private List<Guid> _objectIds = new List<Guid>();

        public Connection Connection;
        private bool IsRunning = false;
        public Game()
        {
            InitializeComponent();
            try
            {
                Connection = new Connection(this);
                Connection.buffer = new byte[5000];
                Connection.socket = new Socket(SocketType.Stream, ProtocolType.Tcp);
                Connection.socket.Connect("127.0.0.1",1337);
                Connection.socket.BeginReceive(Connection.buffer, 0, Connection.buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), Connection);

                IsRunning = true;
                new Thread(GameThread).Start();



                var packet = new Packet(PacketId.Position);
                var packetBuilder = new PacketBuilder(packet);
                packetBuilder.WriteInt32(12);
                Connection.SendPacket(packetBuilder.ToPacket());
            }
            catch (SocketException socketEx)
            {
                IsRunning = false;
                Console.WriteLine(socketEx.Message);
            }
        }

        private void ReceiveCallback(IAsyncResult result)
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
                    IsRunning = false;
                }

            }
            catch (Exception e)
            {
                if (e is SocketException || e is ObjectDisposedException)
                {
                    if (connection.socket != null)
                    {
                        connection.socket.Close();
                        IsRunning = false;
                    }
                }
                else
                {
                    Console.WriteLine("Receiver: " + e.Message);
                }
            }
        }

        private void ReadWriteEventArg_Completed(object sender, SocketAsyncEventArgs e)
        {
            Console.WriteLine(e.Buffer.Length);
        }

        private void GameThread()
        {
            //Socket listening
            while (IsRunning)
            {

            }
        }

        /// <summary>
        /// Onkey down op game event.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GameFrame_KeyDown(object sender, KeyEventArgs e)
        {
            foreach (var gameObject in _gameObjects)
            {
                if (gameObject.IsActive)
                {
                    if (gameObject is IInputManager)
                    {
                        ((IInputManager)gameObject).OnKeyDown(sender, e);
                    }
                }

            }
        }

        private void GameFrame_KeyUp(object sender, KeyEventArgs e)
        {
            foreach (var gameObject in _gameObjects)
            {
                if (gameObject.IsActive)
                {
                    if (gameObject is IInputManager)
                    {
                        ((IInputManager)gameObject).OnKeyUp(sender, e);
                    }
                }
            }
        }


        /// <summary>
        /// Standaard game update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void GameFrame_Renderer(object sender, RenderEventArgs args)
        {
            //haalt de opengl renderer op en cleart het scherm
            var renderer = GameFrame.OpenGL;
            renderer.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

            //loopt door de game objecten heen en drawt deze
            for (int i = 0; i < _gameObjects.Count; i++)
            {
                var gameObject = _gameObjects[i];

                if (gameObject.IsDestroyed)
                {
                    DestroyGameObject(gameObject);
                    continue;
                }
                renderer.LoadIdentity();
                gameObject.Update();
                Camera.Draw(renderer);
                gameObject.Draw(renderer);
                renderer.End();
                renderer.Flush();
            }
        }

        /// <summary>
        /// Als Game object ge destroyed is verwijder deze en roep on destroy aan
        /// </summary>
        /// <param name="gameObject"></param>
        private void DestroyGameObject(GameObject gameObject)
        {
            gameObject.OnDestroy();
            _gameObjects.Remove(gameObject);
        }
    }
}


//obj loader laad de vertixe en faces in
//var objLoader = new ObjectImporter();
//var mesh = objLoader.CreateMeshStruct(@"cube.obj");

////test gameobject
//var gameObject = new GameObject
//{
//    Position = new Vector3
//    {
//        X = 0,
//        Y = 0,
//        Z = -7.5f,
//    },

//    Mesh = mesh,
//};
//_gameObjects.Add(gameObject);

//_gameObjects.Add(new TestGameObject2());