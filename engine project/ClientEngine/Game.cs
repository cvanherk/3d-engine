using ClientEngine.Objects;
using ClientEngine.Test;
using SharpGL;
using SharpGL.Enumerations;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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

            Camera.Position.Y = 10;
            Camera.Position.X = -0.3f;
            Camera.Position.Z = 1;
           
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
        
        //  The texture identifier.
        uint[] textures = new uint[1];
        //  Storage the texture itself.
        Bitmap textureImage;
        private void GameFrame_OpenGLInitialized(object sender, EventArgs e)
        {
            //var renderer = GameFrame.OpenGL;

            ////  We need to load the texture from file.
            ////textureImage = new Bitmap(@"C:\Users\Corne\Desktop\A10.png");

            //renderer.Enable(OpenGL.GL_TEXTURE_2D);
            ////  Get one texture id, and stick it into the textures array.
            //renderer.GenTextures(1, textures);

            ////  Bind the texture.
            //renderer.BindTexture(OpenGL.GL_TEXTURE_2D, textures[0]);

            ////  Tell OpenGL where the texture data is.
            //renderer.TexImage2D(OpenGL.GL_TEXTURE_2D, 0, 3, textureImage.Width, textureImage.Height, 0, OpenGL.GL_BGR, OpenGL.GL_UNSIGNED_BYTE,
            //    textureImage.LockBits(new Rectangle(0, 0, textureImage.Width, textureImage.Height),
            //    ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb).Scan0);

            ////  Specify linear filtering.
            //renderer.TexParameter(OpenGL.GL_TEXTURE_2D, OpenGL.GL_TEXTURE_MIN_FILTER, OpenGL.GL_LINEAR);


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
                //renderer.Begin(OpenGL.GL_QUADS);
                Camera.Draw(renderer);
                gameObject.Draw(renderer);
                //renderer.End();
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