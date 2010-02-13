namespace GLuaR.Windows.DockingWindows
{
    partial class ProjectExplorer
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectExplorer));
            this.tvFiles = new System.Windows.Forms.TreeView();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.fileMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuOpenFile = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRename = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.newFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.folderMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.projectMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNewItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addExistingItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.projectPropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeProjectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuViewCode = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuViewDesign = new System.Windows.Forms.ToolStripMenuItem();
            this.fileMenu.SuspendLayout();
            this.folderMenu.SuspendLayout();
            this.projectMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvFiles
            // 
            this.tvFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvFiles.FullRowSelect = true;
            this.tvFiles.HideSelection = false;
            this.tvFiles.HotTracking = true;
            this.tvFiles.ImageIndex = 0;
            this.tvFiles.ImageList = this.imgList;
            this.tvFiles.Location = new System.Drawing.Point(0, 0);
            this.tvFiles.Name = "tvFiles";
            this.tvFiles.SelectedImageIndex = 0;
            this.tvFiles.Size = new System.Drawing.Size(224, 321);
            this.tvFiles.TabIndex = 0;
            this.tvFiles.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFiles_NodeMouseDoubleClick);
            this.tvFiles.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvFiles_AfterSelect);
            this.tvFiles.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvFiles_NodeMouseClick);
            // 
            // imgList
            // 
            this.imgList.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imgList.ImageSize = new System.Drawing.Size(16, 16);
            this.imgList.TransparentColor = System.Drawing.Color.Fuchsia;
            // 
            // fileMenu
            // 
            this.fileMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenFile,
            this.mnuRename,
            this.mnuDelete,
            this.toolStripSeparator2,
            this.mnuViewCode,
            this.mnuViewDesign,
            this.toolStripMenuItem1,
            this.newFolderToolStripMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(153, 170);
            // 
            // mnuOpenFile
            // 
            this.mnuOpenFile.Image = global::GLuaR.Properties.Resources.open_file;
            this.mnuOpenFile.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuOpenFile.Name = "mnuOpenFile";
            this.mnuOpenFile.Size = new System.Drawing.Size(152, 22);
            this.mnuOpenFile.Text = "Open";
            this.mnuOpenFile.Click += new System.EventHandler(this.mnuOpenFile_Click);
            // 
            // mnuRename
            // 
            this.mnuRename.Image = global::GLuaR.Properties.Resources.redo;
            this.mnuRename.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuRename.Name = "mnuRename";
            this.mnuRename.Size = new System.Drawing.Size(152, 22);
            this.mnuRename.Text = "Rename";
            // 
            // mnuDelete
            // 
            this.mnuDelete.Image = global::GLuaR.Properties.Resources.close_button;
            this.mnuDelete.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(152, 22);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // newFolderToolStripMenuItem
            // 
            this.newFolderToolStripMenuItem.Image = global::GLuaR.Properties.Resources.project_folder_open;
            this.newFolderToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.newFolderToolStripMenuItem.Name = "newFolderToolStripMenuItem";
            this.newFolderToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newFolderToolStripMenuItem.Text = "New Folder";
            this.newFolderToolStripMenuItem.Click += new System.EventHandler(this.newFolderToolStripMenuItem_Click);
            // 
            // folderMenu
            // 
            this.folderMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem8,
            this.toolStripMenuItem7,
            this.toolStripMenuItem5,
            this.toolStripSeparator1,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.folderMenu.Name = "fileMenu";
            this.folderMenu.Size = new System.Drawing.Size(170, 120);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Image = global::GLuaR.Properties.Resources.add_new_item;
            this.toolStripMenuItem8.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem8.Text = "Add New Item";
            this.toolStripMenuItem8.Click += new System.EventHandler(this.addNewItemToolStripMenuItem_Click);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Image = global::GLuaR.Properties.Resources.add_existing_item;
            this.toolStripMenuItem7.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem7.Text = "Add Existing Item";
            this.toolStripMenuItem7.Click += new System.EventHandler(this.addExistingItemToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Image = global::GLuaR.Properties.Resources.project_folder_open;
            this.toolStripMenuItem5.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem5.Text = "New Folder";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.newFolderToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(166, 6);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Image = global::GLuaR.Properties.Resources.redo;
            this.toolStripMenuItem3.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem3.Text = "Rename";
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Image = global::GLuaR.Properties.Resources.close_button;
            this.toolStripMenuItem4.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(169, 22);
            this.toolStripMenuItem4.Text = "Delete";
            // 
            // projectMenu
            // 
            this.projectMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNewItemToolStripMenuItem,
            this.addExistingItemToolStripMenuItem,
            this.toolStripMenuItem6,
            this.toolStripMenuItem2,
            this.projectPropertiesToolStripMenuItem,
            this.closeProjectToolStripMenuItem});
            this.projectMenu.Name = "fileMenu";
            this.projectMenu.Size = new System.Drawing.Size(172, 120);
            // 
            // addNewItemToolStripMenuItem
            // 
            this.addNewItemToolStripMenuItem.Image = global::GLuaR.Properties.Resources.add_new_item;
            this.addNewItemToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.addNewItemToolStripMenuItem.Name = "addNewItemToolStripMenuItem";
            this.addNewItemToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.addNewItemToolStripMenuItem.Text = "Add New Item";
            this.addNewItemToolStripMenuItem.Click += new System.EventHandler(this.addNewItemToolStripMenuItem_Click);
            // 
            // addExistingItemToolStripMenuItem
            // 
            this.addExistingItemToolStripMenuItem.Image = global::GLuaR.Properties.Resources.add_existing_item;
            this.addExistingItemToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.addExistingItemToolStripMenuItem.Name = "addExistingItemToolStripMenuItem";
            this.addExistingItemToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.addExistingItemToolStripMenuItem.Text = "Add Existing Item";
            this.addExistingItemToolStripMenuItem.Click += new System.EventHandler(this.addExistingItemToolStripMenuItem_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Image = global::GLuaR.Properties.Resources.project_folder_open;
            this.toolStripMenuItem6.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(171, 22);
            this.toolStripMenuItem6.Text = "New Folder";
            this.toolStripMenuItem6.Click += new System.EventHandler(this.newFolderToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(168, 6);
            // 
            // projectPropertiesToolStripMenuItem
            // 
            this.projectPropertiesToolStripMenuItem.Image = global::GLuaR.Properties.Resources.project_properties;
            this.projectPropertiesToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.projectPropertiesToolStripMenuItem.Name = "projectPropertiesToolStripMenuItem";
            this.projectPropertiesToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.projectPropertiesToolStripMenuItem.Text = "Project Properties";
            // 
            // closeProjectToolStripMenuItem
            // 
            this.closeProjectToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.closeProjectToolStripMenuItem.Name = "closeProjectToolStripMenuItem";
            this.closeProjectToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.closeProjectToolStripMenuItem.Text = "Close Project";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // mnuViewCode
            // 
            this.mnuViewCode.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewCode.Image")));
            this.mnuViewCode.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuViewCode.Name = "mnuViewCode";
            this.mnuViewCode.Size = new System.Drawing.Size(152, 22);
            this.mnuViewCode.Text = "View Code";
            // 
            // mnuViewDesign
            // 
            this.mnuViewDesign.Image = ((System.Drawing.Image)(resources.GetObject("mnuViewDesign.Image")));
            this.mnuViewDesign.ImageTransparentColor = System.Drawing.Color.Fuchsia;
            this.mnuViewDesign.Name = "mnuViewDesign";
            this.mnuViewDesign.Size = new System.Drawing.Size(152, 22);
            this.mnuViewDesign.Text = "View VGUI";
            // 
            // ProjectExplorer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 321);
            this.Controls.Add(this.tvFiles);
            this.DockableAreas = ((Fireball.Docking.DockAreas)(((((Fireball.Docking.DockAreas.Float | Fireball.Docking.DockAreas.DockLeft)
                        | Fireball.Docking.DockAreas.DockRight)
                        | Fireball.Docking.DockAreas.DockTop)
                        | Fireball.Docking.DockAreas.DockBottom)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.HelpButton = true;
            this.HideOnClose = true;
            this.Name = "ProjectExplorer";
            this.TabText = "Project Explorer";
            this.Text = "Project Explorer";
            this.Load += new System.EventHandler(this.ProjectExplorer_Load);
            this.fileMenu.ResumeLayout(false);
            this.folderMenu.ResumeLayout(false);
            this.projectMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView tvFiles;
        public System.Windows.Forms.ImageList imgList;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenFile;
        private System.Windows.Forms.ToolStripMenuItem mnuRename;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem addNewItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addExistingItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem projectPropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeProjectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
        public System.Windows.Forms.ContextMenuStrip fileMenu;
        public System.Windows.Forms.ContextMenuStrip folderMenu;
        public System.Windows.Forms.ContextMenuStrip projectMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuViewCode;
        private System.Windows.Forms.ToolStripMenuItem mnuViewDesign;
    }
}