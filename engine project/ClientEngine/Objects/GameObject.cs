using ClientEngine.Objects.Variables;
using SharpGL;
using SharpGL.SceneGraph;
using SharpGL.SceneGraph.Core;
using SharpGL.SceneGraph.Primitives;
using SharpGL.Serialization;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;


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

        List<Polygon> _polygons;

        private List<Polygon> ImportPolygon(OpenGL gl,string fileName)
        {
            List<Polygon> polygons = new List<Polygon>();
            Scene scene = SerializationEngine.Instance.LoadScene(fileName);
            if (scene != null)
            {
                foreach (var polygon in scene.SceneContainer.Traverse<Polygon>())
                {
                    //  Get the bounds of the polygon.
                    BoundingVolume boundingVolume = polygon.BoundingVolume;
                    float[] extent = new float[3];
                    polygon.BoundingVolume.GetBoundDimensions(out extent[0], out extent[1], out extent[2]);

                    //  Get the max extent.
                    float maxExtent = extent.Max();

                    //  Scale so that we are at most 10 units in size.
                    float scaleFactor = maxExtent > 10 ? 10.0f / maxExtent : 1;
                    polygon.Transformation.ScaleX = scaleFactor;
                    polygon.Transformation.ScaleY = scaleFactor;
                    polygon.Transformation.ScaleZ = scaleFactor;
                    //polygon.Freeze(gl);
                    polygons.Add(polygon);
                }
            }

            return polygons;
        }

        public void Draw(OpenGL renderer)
        {
            if (_polygons == null)
            {
                _polygons = ImportPolygon(renderer, @"C:\Users\Corne\Desktop\shuttle.obj");
            }
            if (!IsActive)
                return;



            renderer.Color(Color.R, Color.G, Color.B);

            //  Draw every polygon in the collection.
            foreach (Polygon polygon in _polygons)
            {
                polygon.PushObjectSpace(renderer);
                polygon.Render(renderer, RenderMode.Render);
                polygon.PopObjectSpace(renderer);

                polygon.Transformation.TranslateX = _position.X;
                polygon.Transformation.TranslateY = _position.Y;
                polygon.Transformation.TranslateZ = _position.Z;

                polygon.Transformation.RotateX = _rotation.X;
                polygon.Transformation.RotateY = _rotation.Y;
                polygon.Transformation.RotateZ = _rotation.Z;

            }
        


            //if (Mesh?.vertices != null)
            //{

            //    foreach (var vertex in Mesh?.vertices)
            //    {
            //        renderer.Vertex(vertex.X, vertex.Y, vertex.Z);
            //    }
            //}

        }
    }
}
