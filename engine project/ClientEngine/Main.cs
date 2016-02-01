using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.DirectX.Direct3D;
using ClientEngine.DirectX;

namespace ClientEngine
{
    public partial class Main : Form
    {
        private Device _device;
        public Main()
        {
            InitializeComponent();
            
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        public bool InitializeGraphics()
        {

            _device = DirectXDevice.Instantiate(this);
            return false;

        }

        public void Render()
        {
            if (_device == null)
                return;

            //Clear the backbuffer to a blue color 
            _device.Clear(ClearFlags.Target, System.Drawing.Color.Blue, 1.0f, 0);
            //Begin the scene
            _device.BeginScene();

            // Rendering of scene objects can happen here

            //End the scene
            _device.EndScene();
            _device.Present();
        }
    }
}
