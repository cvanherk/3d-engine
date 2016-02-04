using ClientEngine.Objects.Variables;
using SharpGL;
using System;
using System.Drawing;
namespace ClientEngine.Objects
{
    public class GameObject : IGameObject
    {
        private Vector3 _position = Vector3.Zero;
        private Rotation _rotation = Rotation.Zero;
        private float _xAcceleration = 0;
        private float _yAcceleration = 0;
        private float _zAcceleration = 0;

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

        public float xAcceleration
        {
            get
            {
                return _xAcceleration;
            }
            set
            {
                _xAcceleration = value;
            }
        }

        public float yAcceleration
        {
            get
            {
                return _yAcceleration;
            }
            set
            {
                _yAcceleration = value;
            }
        }

        public float zAcceleration
        {
            get
            {
                return _zAcceleration;
            }
            set
            {
                _zAcceleration = value;
            }
        }

        public Rotation Rotation
        {
            get
            {
                return _rotation;
            }

            set
            {
                _rotation = value;
            }
        }
        private bool _isDestroyed;
        public bool IsDestroyed
        {
            get
            {
                return _isDestroyed;
            }

            set
            {
                _isDestroyed = value;
            }
        }

        private Guid _internalId =  Guid.NewGuid();

        public Guid InternalId
        {
            get
            {
                return _internalId;
            } 
        }

        public Color Color = Color.Red;
        public Mesh? Mesh;

        public bool IsActive = true;

        public GameObject()
        {
            Start();
        }

        public void Destroy(GameObject gameObject)
        {
            gameObject.IsDestroyed = true;
        }

        public virtual void Start()
        {

        }

        public virtual void Update()
        {

        }

        public virtual void OnDestroy()
        {

        }

        public void Draw(OpenGL renderer)
        {
            if (!IsActive)
                return;

            renderer.Translate(_position.X, _position.Y, _position.Z);
            renderer.Rotate(_rotation.Angle, _rotation.X, _rotation.Y, _rotation.Z);

            renderer.Begin(OpenGL.GL_LINES);

            renderer.Color(Color.R, Color.G, Color.B);

            if (Mesh?.vertices != null)
            {
                foreach (var vertex in Mesh?.vertices)
                {
                    renderer.Vertex(vertex.X, vertex.Y, vertex.Z);
                }
            }
            
        }
    }
}
