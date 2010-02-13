namespace GLuaR.Windows.DockingWindows
{
    partial class TaskWindow
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip( );
            this.btnAddTask = new System.Windows.Forms.ToolStripButton( );
            this.btnEditTask = new System.Windows.Forms.ToolStripButton( );
            this.btnDeleteTask = new System.Windows.Forms.ToolStripButton( );
            this.lstTasks = new System.Windows.Forms.ListView( );
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader( );
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader( );
            this.toolStrip1.SuspendLayout( );
            this.SuspendLayout( );
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange( new System.Windows.Forms.ToolStripItem[ ] {
            this.btnAddTask,
            this.btnEditTask,
            this.btnDeleteTask} );
            this.toolStrip1.Location = new System.Drawing.Point( 0, 0 );
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size( 570, 25 );
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // btnAddTask
            // 
            this.btnAddTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddTask.Image = global::GLuaR.Properties.Resources.add_new_item;
            this.btnAddTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size( 23, 22 );
            this.btnAddTask.Text = "Add a Task";
            this.btnAddTask.Click += new System.EventHandler( this.btnAddTask_Click );
            // 
            // btnEditTask
            // 
            this.btnEditTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnEditTask.Image = global::GLuaR.Properties.Resources.cut;
            this.btnEditTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditTask.Name = "btnEditTask";
            this.btnEditTask.Size = new System.Drawing.Size( 23, 22 );
            this.btnEditTask.Text = "Edit Task";
            this.btnEditTask.Click += new System.EventHandler( this.btnEditTask_Click );
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDeleteTask.Image = global::GLuaR.Properties.Resources.remove;
            this.btnDeleteTask.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size( 23, 22 );
            this.btnDeleteTask.Text = "Delete Task";
            this.btnDeleteTask.Click += new System.EventHandler( this.btnDeleteTask_Click );
            // 
            // lstTasks
            // 
            this.lstTasks.CheckBoxes = true;
            this.lstTasks.Columns.AddRange( new System.Windows.Forms.ColumnHeader[ ] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader2} );
            this.lstTasks.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstTasks.FullRowSelect = true;
            this.lstTasks.GridLines = true;
            this.lstTasks.Location = new System.Drawing.Point( 0, 25 );
            this.lstTasks.Name = "lstTasks";
            this.lstTasks.Size = new System.Drawing.Size( 570, 112 );
            this.lstTasks.TabIndex = 2;
            this.lstTasks.UseCompatibleStateImageBehavior = false;
            this.lstTasks.View = System.Windows.Forms.View.Details;
            this.lstTasks.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler( this.lstTasks_ItemChecked );
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Done?";
            this.columnHeader1.Width = 55;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Task";
            this.columnHeader2.Width = 427;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Priority";
            this.columnHeader3.Width = 78;
            // 
            // TaskWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 13F );
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size( 570, 137 );
            this.Controls.Add( this.lstTasks );
            this.Controls.Add( this.toolStrip1 );
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.HideOnClose = true;
            this.Name = "TaskWindow";
            this.TabText = "Task Window";
            this.Text = "Task Window";
            this.Load += new System.EventHandler( this.TaskWindow_Load );
            this.toolStrip1.ResumeLayout( false );
            this.toolStrip1.PerformLayout( );
            this.ResumeLayout( false );
            this.PerformLayout( );

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton btnAddTask;
        private System.Windows.Forms.ToolStripButton btnEditTask;
        private System.Windows.Forms.ToolStripButton btnDeleteTask;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        public System.Windows.Forms.ListView lstTasks;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;

    }
}