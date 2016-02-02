using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientEngine.Objects.Variables;
using SharpGL;

namespace ClientEngine.Objects
{
    public class Camera : IGameObject
    {
        private Vector3 _eye = new Vector3(0, 0, 1);
        private Vector3 _center = new Vector3();
        private Vector3 _up = new Vector3();

        public float Radius = 1f;

        public Vector3 Position
        {
            get
            {
                return _eye;
            }

            set
            {
                _eye = value;
            }
        }

        public Rotation Rotation
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }
        private bool _isDestoyed;
        public bool IsDestroyed
        {
            get
            {
                return _isDestoyed;
            }

            set
            {
                _isDestoyed = value;
            }
        }

        public Camera()
        {

        }

        public void Update()
        {
            
        }

        public void Draw(OpenGL openGl)
        {
            openGl.MatrixMode(SharpGL.Enumerations.MatrixMode.Modelview);
            openGl.LookAt(_eye.X * Radius, _eye.Y, _eye.Z * Radius, _center.X, _center.Y, _center.Z, _up.X, -1, _up.Z);
        }

        public void OnDestroy()
        {
            
        }
    }
}
