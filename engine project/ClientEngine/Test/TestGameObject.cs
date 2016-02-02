using ClientEngine.Objecten;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEngine.Test
{
    class TestGameObject : GameObject
    {
        public TestGameObject(float z, float x)
        {
            Position.Z = z;
            Position.X = x;
        }
    }
}
