﻿using ClientEngine.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEngine.Test
{
    class TestGameObject : GameObject
    {
        public TestGameObject(float x, float y, float z)
        {
            Position.X = x;
            Position.Y = y;
            Position.Z = z;
          
        }
    }
}
