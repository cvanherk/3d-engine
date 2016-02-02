using ClientEngine.Objects.Variables;
using SharpGL;
using System;
using System.Drawing;
using System;

namespace ClientEngine.Objects
{
    class GameObject : IGameObject
    {
        private Vector3 _position = Vector3.Zero;
        private Rotation _rotation = Rotation.Zero;

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

        public Color Color = Color.Red;
        public Mesh Mesh;

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

            renderer.Begin(OpenGL.GL_QUADS);

            renderer.Color(Color.R, Color.G, Color.B);
            
            foreach (var vertex in Mesh.vertices)
            {
                renderer.Vertex(vertex.X, vertex.Y, vertex.Z);
            }
        }
    }
}
