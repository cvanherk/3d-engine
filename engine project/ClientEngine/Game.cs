using ClientEngine.Models;
using ClientEngine.Objects;
using ClientEngine.Objects.Variables;
using ClientEngine.Test;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ClientEngine
{
    partial class Game : Form
    {
        private static List<IGameObject> _gameObject = new List<IGameObject>();
        public static IGameObject Camera = new Camera();
        public Game()
        {
            InitializeComponent();
            var fbx = new ObjectImporter();
            var mesh = fbx.createMeshStruct(@"D:\Robin\Desktop\Cube\cube.obj");
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
        
     
        
        private void openGlControl_OpenGLDraw(object sender, RenderEventArgs args)
        {
        
            var renderer = OpenGlControl.OpenGL;
            renderer.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);

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
                gameObject.Draw(renderer);
              
                renderer.End();
                renderer.Flush();
            }
            
        }

        private void DestroyGameObject(IGameObject gameObject)
        {
            gameObject.OnDestroy();
            _gameObject.Remove(gameObject);
        }
        private void Game_Load(object sender, EventArgs e)
        {

        }
    }
}