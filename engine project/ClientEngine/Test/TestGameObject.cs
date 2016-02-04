using ClientEngine.Models;
using ClientEngine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientEngine.Test
{
    public class TestGameObject : GameObject, IInputManager
    {
        public TestGameObject()
        {
            Position.Z = -10f;
        } 

        public override void Start()
        {
            var objLoader = new ObjectImporter();
            Mesh = objLoader.CreateMeshStruct(@"cube.obj");
        }

        private float OnXAccelerate()
        {
            xAcceleration += 0.1f;
            return xAcceleration;
        }

        private void ClearXAcceleration()
        {
            xAcceleration = 0;
        }

        private float OnZAccelerate()
        {
            zAcceleration += 0.1f;
            return zAcceleration;
        }

        private void ClearZAcceleration()
        {
            zAcceleration = 0;
        }

        public void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            Console.WriteLine($"OnkeyDown: {keyEventArgs.KeyCode}");

            switch(keyEventArgs.KeyCode)
            {
                case Keys.W:
                    Position.X += OnXAccelerate();
                break;

                case Keys.S:
                    Position.X -= OnXAccelerate();
                break;

                case Keys.D:
                    Position.Z += OnZAccelerate();
                    break;

                case Keys.A:
                    Position.Z -= OnZAccelerate();
                    break;

                case Keys.P:
                    Position.X = 0;
                    Position.Z = 0;
                    break;
            }
        }

        public void OnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            Console.WriteLine($"Onkeyup: {keyEventArgs.KeyCode}");

            switch (keyEventArgs.KeyCode)
            {
                case Keys.W:
                    ClearXAcceleration();
                break;

                case Keys.S:
                    ClearXAcceleration();
               break;

                case Keys.D:
                    ClearZAcceleration();
                    break;

                case Keys.A:
                    ClearZAcceleration();
                    break;
            }
        }
    }
}
