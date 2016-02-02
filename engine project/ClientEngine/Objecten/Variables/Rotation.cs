using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEngine.Objecten.Variables
{
    class Rotation
    {
        public float Angle { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }

        public Rotation(float angle, float x, float y, float z)
        {
            Angle = angle;
            X = x;
            Y = y;
            Z = z;
        }

        public Rotation(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Rotation(float x, float y)
        {
            X = x;
            Y = y;
        }

        public Rotation()
        {
            X = 0;
            Y = 0;
            Z = 0;

        }

        public static Rotation Zero
        {
            get
            {
                return new Rotation(0f,0f, 0f, 0f);
            }
        }
    }
}
