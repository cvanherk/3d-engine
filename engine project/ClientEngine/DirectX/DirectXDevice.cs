using Microsoft.DirectX.Direct3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientEngine.DirectX
{
    public class DirectXDevice
    {
        public DirectXDevice()
        {

        }

        public static Device Instantiate(Form form)
        {
            // Now  setup our D3D stuff
            var presentParams = new PresentParameters
            {
               Windowed = true,
               SwapEffect = SwapEffect.Discard
            };

            return new Device(0, DeviceType.Hardware, form,
                     CreateFlags.SoftwareVertexProcessing, presentParams);
        }
    }
}
