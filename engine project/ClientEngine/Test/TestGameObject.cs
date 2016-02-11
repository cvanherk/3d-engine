using ClientEngine.Objects;
using ClientEngine.Objects.Variables;
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

        private float OnYAccelerate()
        {
            yAcceleration += 0.1f;
            return yAcceleration;
        }

        private void ClearYAcceleration()
        {
            yAcceleration = 0;
        }

        public override void OnGui()
        {
            Gui.DrawLabel(new Vector2(0, 0), "Courier New", 12, "test");
        }

        public void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            Console.WriteLine($"OnkeyDown: {keyEventArgs.KeyCode}");

            switch (keyEventArgs.KeyCode)
            {
                case Keys.T:
                   
                    break;
                case Keys.W:
                    Position.Y += OnYAccelerate();
                    Game.Camera.Position = new Vector3(-Position.X, -Position.Y, -Position.Z);
                    break;

                case Keys.S:
                    Position.Y -= OnYAccelerate();
                    Game.Camera.Position = new Vector3(-Position.X, -Position.Y, -Position.Z);
                    break;

                case Keys.D:
                    Position.X += OnXAccelerate();
                    Game.Camera.Position = new Vector3(-Position.X, -Position.Y, -Position.Z);
                    break;

                case Keys.A:
                    Position.X -= OnXAccelerate();
                    Game.Camera.Position = new Vector3(-Position.X, -Position.Y, -Position.Z);
                    break;

                case Keys.Q:
                    Position.Z += OnZAccelerate();
                break;

                case Keys.E:
                    Position.Z -= OnZAccelerate();
                break;

                case Keys.P:
                    Position.X = 0;
                    Position.Z = 0;
                    GameObject.Instantiate(new TestGameObject2());
                break;

                case Keys.End:
                    //((Camera)Game.Camera).LookAtPosition = new Vector3(Position.X, Position.Y, Position.Z-1);
                    //((Camera)Game.Camera).Center = new Vector3(Position.X, Position.Y, Position.Z);
                    Game.Camera.Position = new Vector3(-Position.X, -Position.Y, -Position.Z);
                break;

                case Keys.Delete:
                    Game.GameObjects[Game.GameObjects.Count - 1].Destroy(Game.GameObjects[Game.GameObjects.Count - 1]);
                break;

                case Keys.L:
                    Rotation.X += OnZAccelerate();
                break;
            }
        }

        public void OnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            Console.WriteLine($"Onkeyup: {keyEventArgs.KeyCode}");

            switch (keyEventArgs.KeyCode)
            {
                case Keys.W:
                    ClearYAcceleration();
                break;

                case Keys.S:
                    ClearYAcceleration();
               break;

                case Keys.D:
                    ClearXAcceleration();
                break;

                case Keys.A:
                    ClearXAcceleration();
                break;

                case Keys.Q:
                    ClearZAcceleration();
                break;

                case Keys.E:
                    ClearZAcceleration();
                break;

                case Keys.L:
                    ClearZAcceleration();
                break;
            }
        }
    }
}
