using ClientEngine.Objects;
using System;
using System.Windows.Forms;

namespace ClientEngine.Test
{
    public class TestGameObject : GameObject, IInputManager
    {
        public TestGameObject()
        {
            //Position.Z = 55f;
            //Position.X = -15f;
            //Position.Y = 4f;
            ObjFilePath = @"C:\Users\Corne\Desktop\blokje.obj";
            Texture = @"C:\Users\Corne\Desktop\4166276_t.jpg";
        } 

        public override void Start()
        {
         
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

            switch (keyEventArgs.KeyCode)
            {
                case Keys.W:
                    Position.X += OnXAccelerate();
                    break;

                case Keys.L:
                    Rotation.X += OnXAccelerate();
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
