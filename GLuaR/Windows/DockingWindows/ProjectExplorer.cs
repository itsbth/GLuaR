using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Fireball.Docking;

using GLuaR.Classes;



using GLuaR.Classes.Workspace;

namespace GLuaR.Windows.DockingWindows
{
    public partial class ProjectExplorer : DockableWindow
    {
        
        Workspace myWorkspace;

        public ProjectExplorer( Workspace workspace )
        {
            InitializeComponent();

            myWorkspace = workspace;
            

        }

        private void ProjectExplorer_Load(object sender, EventArgs e)
        {
            imgList.Images.Add( "file_lost", global::GLuaR.Properties.Resources.file_unavailable );
            imgList.Images.Add( "project_folder_closed", global::GLuaR.Properties.Resources.project_folder_closed );
            imgList.Images.Add( "code", global::GLuaR.Properties.Resources.project_code );
            imgList.Images.Add( "root", global::GLuaR.Properties.Resources.project_root );
            
        }

        private void mnuOpenFile_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("Open Clicked...");
            if (tvFiles.SelectedNode == null)
                return;
            else
            {
                System.Diagnostics.Debug.WriteLine(tvFiles.SelectedNode.Tag.GetType().Name);
                if (tvFiles.SelectedNode.Tag.GetType().Name == "OpenedFile")
                {
                    System.Diagnostics.Debug.WriteLine("Opening File...");
                    myWorkspace.ShowProjectFile(((OpenedFile)tvFiles.SelectedNode.Tag));
                }
            }

        }

        private void tvFiles_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            tvFiles.SelectedNode = e.Node;
            if (e.Button == MouseButtons.Right)
            {
                if (e.Node != null)
                    fileMenu.Show(tvFiles.PointToScreen(e.Location).X, tvFiles.PointToScreen(e.Location).Y);
            }
        }

        private void tvFiles_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if ((e.Node != null))
                if( e.Node.Tag.GetType().Name == "OpenedFile" )
                    myWorkspace.ShowProjectFile(((OpenedFile)tvFiles.SelectedNode.Tag));
        }

        private void tvFiles_AfterSelect(object sender, TreeViewEventArgs e)
        {

        }

        private void newFolderToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            myWorkspace.NewFolder( );
        }

        private void mnuDelete_Click ( object sender, EventArgs e )
        {
            if ( tvFiles.SelectedNode == null )
                return;
            else
            {
                if ( tvFiles.SelectedNode.Tag.GetType( ).Name == "Folder" )
                {
                    // Folder Deletion Code
                    myWorkspace.DeleteFolder( ((Folder)tvFiles.SelectedNode.Tag) );
                }
                else if( tvFiles.SelectedNode.Tag.GetType().Name == "OpenedFile" )
                {
                    // File Deletion Code
                    myWorkspace.DeleteFile( ( ( OpenedFile )tvFiles.SelectedNode.Tag ) );
                }
            }
        }

        private void addNewItemToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            myWorkspace.AddNewItem( );
        }

        private void addExistingItemToolStripMenuItem_Click ( object sender, EventArgs e )
        {
            myWorkspace.AddExistingItem( );
        }
    }
}