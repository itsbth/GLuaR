namespace GLuaR.Windows.DockingWindows
{
    partial class Design
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
            this.baseDermaControl2 = new GLuaR.Windows.Designer.BaseDermaControl();
            this.baseDermaControl3 = new GLuaR.Windows.Designer.BaseDermaControl();
            this.baseDermaControl4 = new GLuaR.Windows.Designer.BaseDermaControl();
            this.baseDermaControl1 = new GLuaR.Windows.Designer.BaseDermaControl();
            this.baseDermaControl5 = new GLuaR.Windows.Designer.BaseDermaControl();
            this.baseDermaControl6 = new GLuaR.Windows.Designer.BaseDermaControl();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // baseDermaControl2
            // 
            this.baseDermaControl2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.baseDermaControl2.Location = new System.Drawing.Point(206, 174);
            this.baseDermaControl2.Name = "baseDermaControl2";
            this.baseDermaControl2.Size = new System.Drawing.Size(130, 33);
            this.baseDermaControl2.TabIndex = 1;
            // 
            // baseDermaControl3
            // 
            this.baseDermaControl3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.baseDermaControl3.Location = new System.Drawing.Point(342, 213);
            this.baseDermaControl3.Name = "baseDermaControl3";
            this.baseDermaControl3.Size = new System.Drawing.Size(130, 33);
            this.baseDermaControl3.TabIndex = 2;
            // 
            // baseDermaControl4
            // 
            this.baseDermaControl4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.baseDermaControl4.Location = new System.Drawing.Point(342, 174);
            this.baseDermaControl4.Name = "baseDermaControl4";
            this.baseDermaControl4.Size = new System.Drawing.Size(130, 33);
            this.baseDermaControl4.TabIndex = 3;
            // 
            // baseDermaControl1
            // 
            this.baseDermaControl1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.baseDermaControl1.Location = new System.Drawing.Point(206, 135);
            this.baseDermaControl1.Name = "baseDermaControl1";
            this.baseDermaControl1.Size = new System.Drawing.Size(130, 33);
            this.baseDermaControl1.TabIndex = 1;
            // 
            // baseDermaControl5
            // 
            this.baseDermaControl5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.baseDermaControl5.Location = new System.Drawing.Point(342, 252);
            this.baseDermaControl5.Name = "baseDermaControl5";
            this.baseDermaControl5.Size = new System.Drawing.Size(130, 33);
            this.baseDermaControl5.TabIndex = 4;
            // 
            // baseDermaControl6
            // 
            this.baseDermaControl6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.baseDermaControl6.Location = new System.Drawing.Point(206, 96);
            this.baseDermaControl6.Name = "baseDermaControl6";
            this.baseDermaControl6.Size = new System.Drawing.Size(130, 33);
            this.baseDermaControl6.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(336, 29);
            this.label1.TabIndex = 6;
            this.label1.Text = "Active Derma Control: None";
            // 
            // Design
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 381);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.baseDermaControl6);
            this.Controls.Add(this.baseDermaControl5);
            this.Controls.Add(this.baseDermaControl4);
            this.Controls.Add(this.baseDermaControl3);
            this.Controls.Add(this.baseDermaControl1);
            this.Controls.Add(this.baseDermaControl2);
            this.DockableAreas = Fireball.Docking.DockAreas.Document;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Design";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.TabText = "[ Design ]";
            this.Text = "[ Design ]";
            this.Activated += new System.EventHandler(this.Design_Activated);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GLuaR.Windows.Designer.BaseDermaControl baseDermaControl2;
        private GLuaR.Windows.Designer.BaseDermaControl baseDermaControl3;
        private GLuaR.Windows.Designer.BaseDermaControl baseDermaControl4;
        private GLuaR.Windows.Designer.BaseDermaControl baseDermaControl1;
        private GLuaR.Windows.Designer.BaseDermaControl baseDermaControl5;
        private GLuaR.Windows.Designer.BaseDermaControl baseDermaControl6;
        private System.Windows.Forms.Label label1;

    }
}