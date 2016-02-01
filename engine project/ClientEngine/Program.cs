using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientEngine
{
    static class Program
    {
        static void Main()
        {

            using (var mainForm = new Main())
            {
                if (!mainForm.InitializeGraphics()) // Initialize Direct3D
                {
                    MessageBox.Show(
                        "Could not initialize Direct3D..");
                    return;
                }
                mainForm.Show();

                // While the form is still valid, render and process messages
                while (mainForm.Created)
                {
                    mainForm.Render();
                    Application.DoEvents();
                }
            }
        }
    }
}
