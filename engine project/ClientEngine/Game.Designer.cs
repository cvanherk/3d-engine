namespace ClientEngine
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GameFrame = new SharpGL.OpenGLControl();
            ((System.ComponentModel.ISupportInitialize)(this.GameFrame)).BeginInit();
            this.SuspendLayout();
            // 
            // GameFrame
            // 
            this.GameFrame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameFrame.DrawFPS = false;
            this.GameFrame.FrameRate = 28;
            this.GameFrame.Location = new System.Drawing.Point(0, 0);
            this.GameFrame.Name = "GameFrame";
            this.GameFrame.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.GameFrame.RenderContextType = SharpGL.RenderContextType.FBO;
            this.GameFrame.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.GameFrame.Size = new System.Drawing.Size(792, 467);
            this.GameFrame.TabIndex = 0;
            this.GameFrame.OpenGLDraw += new SharpGL.RenderEventHandler(this.GameFrame_Renderer);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 467);
            this.Controls.Add(this.GameFrame);
            this.Name = "Game";
            this.Text = "Simple Drawing Sample";
            ((System.ComponentModel.ISupportInitialize)(this.GameFrame)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private SharpGL.OpenGLControl GameFrame;
    }

}

