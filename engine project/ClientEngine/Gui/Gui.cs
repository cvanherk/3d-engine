using ClientEngine.Objects.Variables;
using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientEngine.Gui
{
    public class Gui
    {
        private OpenGL _openGl;
        public Gui(OpenGL openGl)
        {
            _openGl = openGl;
        }

        public static Gui NewInstance(OpenGL openGL)
        {
            return new Gui(openGL);
        }

        public static void DrawTextBox()
        {
            _openGl.Draw
        }

        public void DrawLabel(Vector2 position, string faceName, float fontSize, string text, Color? color = null)
        {
            Color c;

            if (!color.HasValue)
            {
                c = Color.White;
            }
            else
            {
                c = color.Value;
            }

            _openGl.DrawText((int)position.X, (int)position.Y, c.R, c.G, c.B, faceName, fontSize,
                    text);
            _openGl.Flush();
        }
    }
}
