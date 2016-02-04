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
            Position.Z = -7f;
        } 

        public override void Start()
        {
            var objLoader = new ObjectImporter();
            Mesh = objLoader.CreateMeshStruct(@"cube.obj");
        }

        public void OnKeyDown(object sender, KeyEventArgs keyEventArgs)
        {
            Console.WriteLine($"OnkeyDown: {keyEventArgs.KeyCode}");
        }

        public void OnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
            Console.WriteLine($"Onkeyup: {keyEventArgs.KeyCode}");
        }
    }
}
