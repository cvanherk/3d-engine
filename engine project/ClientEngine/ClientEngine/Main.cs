using SlimDX;
using SlimDX.D3DCompiler;
using SlimDX.Direct3D11;
using SlimDX.DXGI;
using SlimDX.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientEngine
{
    public class Main : RenderForm
    {
        public DeviceContext DeviceContext;
        public SlimDX.Direct3D11.Device Device;
        public SwapChain SwapChain;
        public RenderTargetView RenderTargetView;
        public Main()
        {

            // handle alt+enter ourselves
            KeyDown += (o, e) =>
            {
                if (e.Alt && e.KeyCode == Keys.Enter)
                    SwapChain.IsFullScreen = !SwapChain.IsFullScreen;
            };
        }
        SlimDX.Direct3D11.Buffer _v;
        public void OnStart()
        {
            ShaderSignature inputSignature;
            VertexShader vertexShader;
            PixelShader pixelShader;

            // load and compile the vertex shader
            using (var bytecode = ShaderBytecode.CompileFromFile("triangle.fx", "VShader", "vs_4_0", ShaderFlags.None, EffectFlags.None))
            {
                inputSignature = ShaderSignature.GetInputSignature(bytecode);
                vertexShader = new VertexShader(Device, bytecode);
            }

            // load and compile the pixel shader
            using (var bytecode = ShaderBytecode.CompileFromFile("triangle.fx", "PShader", "ps_4_0", ShaderFlags.None, EffectFlags.None))
                pixelShader = new PixelShader(Device, bytecode);

            // create test vertex data, making sure to rewind the stream afterward
            //var vertices = new DataStream(12 * 3, true, true);
            //vertices.Write(new Vector3(0.0f, 0.5f, 0.5f));
            //vertices.Write(new Vector3(0.5f, -0.5f, 0.5f));
            //vertices.Write(new Vector3(-0.5f, -0.5f, 0.5f));
            //vertices.Position = 0;

  //          -1.0, -1.0,  1.0,
  // 1.0, -1.0,  1.0,
  // 1.0,  1.0,  1.0,
  //-1.0,  1.0,  1.0,


            var vertices = new DataStream(12 * 4, true, true);

            vertices.Write(new Vector3(-1.0, -1.0,  1.0));
            vertices.Write(new Vector3(0.5f, -0.5f, 0.5f));
            vertices.Write(new Vector3(-0.5f, -0.5f, 0.5f));
            vertices.Position = 0;

            // create the vertex layout and buffer
            var elements = new[] { new InputElement("POSITION", 0, Format.R32G32B32_Float, 0) };
            var layout = new InputLayout(Device, inputSignature, elements);
            var vertexBuffer = new SlimDX.Direct3D11.Buffer(Device, vertices, 12 * 3, ResourceUsage.Default, BindFlags.VertexBuffer, CpuAccessFlags.None, ResourceOptionFlags.None, 0);

            // configure the Input Assembler portion of the pipeline with the vertex data
            DeviceContext.InputAssembler.InputLayout = layout;
            DeviceContext.InputAssembler.PrimitiveTopology = PrimitiveTopology.TriangleList;
            DeviceContext.InputAssembler.SetVertexBuffers(0, new VertexBufferBinding(vertexBuffer, 12, 0));

            // set the shaders
            DeviceContext.VertexShader.Set(vertexShader);
            DeviceContext.PixelShader.Set(pixelShader);



        }

        public void Render()
        {
            DeviceContext.ClearRenderTargetView(RenderTargetView, new Color4(0.5f, 0.5f, 1.0f));

            DeviceContext.Draw(4, 0);
        }

    }
}
