using ClientEngine.Objects;
using System;
using System.Windows.Forms;

namespace ClientEngine.Test
{
    public class TestGameObject2 : GameObject
    {
        public TestGameObject2()
        {
            //Position.Z = 55f;
            //Position.X = -15f;
            //Position.Y = 4f;
            ObjFilePath = @"C:\Users\Freijlord\Desktop\blokje.obj";
           // Texture = @"C:\Users\Corne\Desktop\4166276_t.jpg";
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
          
        }

        public void OnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
           
        }
    }
}
