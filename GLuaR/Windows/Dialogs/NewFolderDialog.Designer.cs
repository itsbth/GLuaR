namespace GLuaR
{
    partial class NewFolderDialog
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
            this.imageList1 = new System.Windows.Forms.ImageList( this.components );
            this.txtFolderName = new System.Windows.Forms.TextBox( );
            this.label2 = new System.Windows.Forms.Label( );
            this.btnAdd = new System.Windows.Forms.Button( );
            this.button2 = new System.Windows.Forms.Button( );
            this.SuspendLayout( );
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size( 32, 32 );
            this.imageList1.TransparentColor = System.Drawing.Color.Magenta;
            // 
            // txtFolderName
            // 
            this.txtFolderName.Location = new System.Drawing.Point( 68, 6 );
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size( 233, 20 );
            this.txtFolderName.TabIndex = 3;
            this.txtFolderName.TextChanged += new System.EventHandler( this.txtFolderName_TextChanged );
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point( 12, 9 );
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size( 38, 13 );
            this.label2.TabIndex = 4;
            this.label2.Text = "Name:";
            // 
            // btnAdd
            // 
            this.btnAdd.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point( 145, 32 );
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size( 75, 23 );
            this.btnAdd.TabIndex = 6;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler( this.btnAdd_Click );
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Location = new System.Drawing.Point( 226, 32 );
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size( 75, 23 );
            this.button2.TabIndex = 7;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // NewFolderDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 307, 57 );
            this.Controls.Add( this.button2 );
            this.Controls.Add( this.btnAdd );
            this.Controls.Add( this.label2 );
            this.Controls.Add( this.txtFolderName );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewFolderDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add New Folder";
            this.Load += new System.EventHandler( this.NewFolderDialog_Load );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.TextBox txtFolderName;
    }
}