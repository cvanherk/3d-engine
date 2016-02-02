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
            this.OpenGlControl = new SharpGL.OpenGLControl();
            ((System.ComponentModel.ISupportInitialize)(this.OpenGlControl)).BeginInit();
            this.SuspendLayout();
            // 
            // OpenGlControl
            // 
            this.OpenGlControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenGlControl.DrawFPS = false;
            this.OpenGlControl.FrameRate = 28;
            this.OpenGlControl.Location = new System.Drawing.Point(0, 0);
            this.OpenGlControl.Name = "OpenGlControl";
            this.OpenGlControl.OpenGLVersion = SharpGL.Version.OpenGLVersion.OpenGL2_1;
            this.OpenGlControl.RenderContextType = SharpGL.RenderContextType.FBO;
            this.OpenGlControl.RenderTrigger = SharpGL.RenderTrigger.TimerBased;
            this.OpenGlControl.Size = new System.Drawing.Size(792, 467);
            this.OpenGlControl.TabIndex = 0;
            this.OpenGlControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGlControl_OpenGLDraw);
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 467);
            this.Controls.Add(this.OpenGlControl);
            this.Name = "Game";
            this.Text = "Game";
            this.Load += new System.EventHandler(this.Game_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OpenGlControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SharpGL.OpenGLControl OpenGlControl;
    }

}

