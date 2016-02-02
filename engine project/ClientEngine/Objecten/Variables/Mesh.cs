namespace ClientEngine.Objecten.Variables
{
    public struct Mesh
    {
        public Vector3[] vertices;
        public Vector3[] normals;
        public Vector2[] uv;
        public Vector2[] uv1;
        public Vector2[] uv2;
        public int[] triangles;
        public int[] faceVerts;
        public int[] faceUVs;
        public Vector3[] faceData;
        public string name;
        public string fileName;
    }
}
