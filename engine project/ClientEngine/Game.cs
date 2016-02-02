using ClientEngine.Objecten;
using ClientEngine.Test;
using SharpGL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientEngine
{
    partial class Game : Form
    {
        private static List<GameObject> _gameObject = new List<GameObject>();

        public Game()
        {
            InitializeComponent();
            _gameObject.Add(new TestGameObject(-5,2));
            _gameObject.Add(new TestGameObject(-5,-1));
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

        private void DestroyGameObject(GameObject gameObject)
        {
            gameObject.OnDestroy();
            _gameObject.Remove(gameObject);
        }
        private void Game_Load(object sender, EventArgs e)
        {

        }
    }
}