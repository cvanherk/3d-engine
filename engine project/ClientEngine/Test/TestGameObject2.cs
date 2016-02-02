using ClientEngine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientEngine.Test
{
    public class TestGameObject2 : GameObject , IInputManager
    {
        
        public TestGameObject2()
        {
           
        }
        public TestGameObject2(float z, float x)
        {
            Position.Z = z;
            Position.X = x;
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
