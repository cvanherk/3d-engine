using ClientEngine.Models;
using ClientEngine.Objects;
using ClientEngine.Objects.Variables;
using SharpGL;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClientEngine
{
    partial class Game : Form
    {
        private List<IGameObject> _gameObject = new List<IGameObject>();
        public IGameObject Camera = new Camera();

        public Game()
        {
            InitializeComponent();

            //obj loader laad de vertixe en faces in
            var objLoader = new ObjectImporter();
            var mesh = objLoader.createMeshStruct(@"D:\Robin\Desktop\Cube\cube.obj");

            //test gameobject
            var gameObject = new GameObject
            {
                Position = new Vector3
                {
                    X = -2,
                    Y = -1,
                    Z = -7.5f,
                },
                Rotation = new Rotation
                {
                    Angle = 0.5f,
                    X = 0f,
                    Y = 1f,
                    Z = 1f,
                },
                Mesh = mesh,
            };
            _gameObject.Add(gameObject);

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
            for (int i = 0; i < _gameObject.Count; i++)
            {
                var gameObject = _gameObject[i];

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
        private void DestroyGameObject(IGameObject gameObject)
        {
            gameObject.OnDestroy();
            _gameObject.Remove(gameObject);
        }
    }
}