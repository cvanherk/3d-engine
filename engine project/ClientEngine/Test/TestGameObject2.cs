using ClientEngine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEngine.Test
{
    class TestGameObject2 : GameObject
    {
        public TestGameObject2(float z, float x)
        {
            Position.Z = z;
            Position.X = x;
        }
    }
}
