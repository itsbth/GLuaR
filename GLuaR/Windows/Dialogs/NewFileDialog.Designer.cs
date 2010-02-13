namespace GLuaR
{
    partial class NewFileDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container( );
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup( "Installed Templates", System.Windows.Forms.HorizontalAlignment.Left );
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup( "Custom Templates", System.Windows.Forms.HorizontalAlignment.Left );
            this.label1 = new System.Windows.Forms.Label( );
            this.listView1 = new System.Windows.Forms.ListView( );
            this.imageList1 = new System.Windows.Forms.ImageList( this.components );
            this.textBox1 = new System.Windows.Forms.TextBox( );
            this.txtFileName = new System.Windows.Forms.TextBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.groupBox1 = new System.Windows.Forms.GroupBox( );
            this.button1 = new System.Windows.Forms.Button( );
            this.button2 = new System.Windows.Forms.Button( );
            this.SuspendLayout( );
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point( 13, 13 );
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size( 59, 13 );
            this.label1.TabIndex = 0;
            this.label1.Text = "Templates:";
            // 
            // listView1
            // 
            listViewGroup1.Header = "Installed Templates";
            listViewGroup1.Name = "Installed Templates";
            listViewGroup2.Header = "Custom Templates";
            listViewGroup2.Name = "Custom Templates";
            this.listView1.Groups.AddRange( new System.Windows.Forms.ListViewGroup[ ] {
            listViewGroup1,
            listViewGroup2} );
            this.listView1.HideSelection = false;
            this.listView1.LargeImageList = this.imageList1;
            this.listView1.Location = new System.Drawing.Point( 12, 29 );
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size( 564, 207 );
            this.listView1.TabIndex = 1;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler( this.listView1_SelectedIndexChanged );
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size( 32, 32 );
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point( 12, 242 );
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size( 564, 20 );
            this.textBox1.TabIndex = 2;
            // 
            // txtFileName
            // 
            this.txtFileName.Location = new System.Drawing.Point( 69, 268 );
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size( 450, 20 );
            this.txtFileName.TabIndex = 3;
            this.txtFileName.TextChanged += new System.EventHandler( this.textBox2_TextChanged );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 13, 271 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 38, 13 );
            this.label2.TabIndex = 4;
            this.label2.Text = "Name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point( 12, 294 );
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size( 564, 2 );
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point( 420, 302 );
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size( 75, 23 );
            this.button1.TabIndex = 6;
            this.button1.Text = "Add";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point( 501, 302 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 75, 23 );
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // NewFileDialog
            // 
            this.AcceptButton = this.button1;
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.button2;
            this.ClientSize = new System.Drawing.Size( 588, 337 );
            this.Controls.Add( this.button2 );
            this.Controls.Add( this.button1 );
            this.Controls.Add( this.groupBox1 );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.txtFileName );
            this.Controls.Add( this.textBox1 );
            this.Controls.Add( this.listView1 );
            this.Controls.Add( this.label1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewFileDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Item";
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ImageList imageList1;
    }
}