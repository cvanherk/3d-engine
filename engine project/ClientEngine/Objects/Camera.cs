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
        private Vector3 _up = new Vector3(0, 1);
        private Vector3 _position = new Vector3(0, 0, 0);

        public float Radius = 90f;

        public Vector3 Position
        {
            get
            {
                return _position;
            }

            set
            {
                _position = value;
            }
        }

        public Vector3 Center
        {
            get
            {
                return _center;
            }

            set
            {
                _center = value;
            }
        }

        public Vector3 LookAtPosition
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

        private Guid _internalId = Guid.NewGuid();
        public Guid InternalId
        {
            get
            {
                return _internalId;
            }
        }
        public Camera()
        {

        }

        public void Update()
        {
            
        }

        public void Draw(OpenGL renderer)
        {
            renderer.MatrixMode(SharpGL.Enumerations.MatrixMode.Modelview);
            renderer.LookAt(_eye.X * Radius, _eye.Y * Radius, _eye.Z * Radius, _center.X * Radius, _center.Y * Radius, _center.Z * Radius, _up.X, _up.Y, _up.Z);
            renderer.Translate(_position.X, _position.Y, _position.Z);
        }

        public void OnDestroy()
        {
            
        }
    }
}
