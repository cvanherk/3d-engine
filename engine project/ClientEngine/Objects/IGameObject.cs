
using ClientEngine.Objects.Variables;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientEngine.Objects
{
    public interface IGameObject
    {
        Vector3 Position { get; set; }
        Rotation Rotation { get; set; }
        bool IsDestroyed { get; set; }
        void Update();
        void Draw(OpenGL openGl);
        void OnDestroy();
    }
}
