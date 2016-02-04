using ClientEngine.Models;
using ClientEngine.Objects;
using ClientEngine.Objects.Variables;
using ClientEngine.Test;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public Game()
        {
            InitializeComponent();
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