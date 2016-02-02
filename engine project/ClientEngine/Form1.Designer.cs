namespace ClientEngine
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.OpenGlControl = new SharpGL.OpenGLControl();
            ((System.ComponentModel.ISupportInitialize)(this.OpenGlControl)).BeginInit();
            this.SuspendLayout();
           
            // 
            // openGlControl
            // 
            this.OpenGlControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenGlControl.DrawFPS = false;
            this.OpenGlControl.FrameRate = 28;
            this.OpenGlControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenGlControl.Location = new System.Drawing.Point(12, 12);
            this.OpenGlControl.Name = "openGlControl";
            this.OpenGlControl.RenderContextType = SharpGL.RenderContextType.FBO;
            this.OpenGlControl.Size = new System.Drawing.Size(768, 410);
            this.OpenGlControl.TabIndex = 0;
            this.OpenGlControl.OpenGLDraw += new SharpGL.RenderEventHandler(this.openGlControl_OpenGLDraw);
            // 
            // FormSimpleDrawingSample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 467);
            this.Controls.Add(this.OpenGlControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSimpleDrawingSample";
            this.Text = "Simple Drawing Sample";
            ((System.ComponentModel.ISupportInitialize)(this.OpenGlControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SharpGL.OpenGLControl OpenGlControl;
    }

}

