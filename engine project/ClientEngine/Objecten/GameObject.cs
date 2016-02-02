using ClientEngine.Objecten.Variables;
using SharpGL;
using System;
using System.Drawing;

namespace ClientEngine.Objecten
{
    class GameObject
    {
        public Vector3 Position = Vector3.Zero;
        public Rotation Rotation = Rotation.Zero;
        public Color Color = Color.Red;
        public Mesh Mesh;

        public bool IsActive = true;
        public bool IsDestroyed = false;

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

            renderer.Translate(Position.X, Position.Y, Position.Z);
            renderer.Rotate(Rotation.Angle, Rotation.X, Rotation.Y, Rotation.Z);
            renderer.Begin(OpenGL.GL_QUADS);
            
            renderer.Color(Color.R, Color.G, Color.B);

            foreach (var vertex in Mesh.vertices)
            {
                renderer.Vertex(vertex.X, vertex.Y, vertex.Z);
            }
        }
    }
}
