namespace GLuaR.Windows.DockingWindows
{
    partial class DesignToolbox
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
            this.SuspendLayout();
            // 
            // DesignToolbox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 320);
            this.DockableAreas = ((Fireball.Docking.DockAreas)(((((Fireball.Docking.DockAreas.Float | Fireball.Docking.DockAreas.DockLeft)
                        | Fireball.Docking.DockAreas.DockRight)
                        | Fireball.Docking.DockAreas.DockTop)
                        | Fireball.Docking.DockAreas.DockBottom)));
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DesignToolbox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TabText = "[ DesignToolbox ]";
            this.Text = "[ Toolbox ]";
            this.ResumeLayout(false);

        }

        #endregion

    }
}