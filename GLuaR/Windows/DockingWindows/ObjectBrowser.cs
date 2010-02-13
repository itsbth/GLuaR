using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;


using Fireball.Docking;

using GLuaR.Classes.Workspace;
using GLuaR.Classes;


namespace GLuaR.Windows.DockingWindows
{
    public partial class ObjectBrowser : DockableWindow
    {

        string lastUrl = "";

        CodeProvider code;

        Workspace myWorkspace;

        public ObjectBrowser( CodeProvider cp, ImageList images, Workspace workspace)
        {
            this.Text = "Object Browser";
            InitializeComponent();

            myWorkspace = workspace;

            treeView1.ImageList = images;
            treeView2.ImageList = images;

            code = cp;

            LoadLibs( code );
        }

        private void LoadLibs( CodeProvider code )
        {
            treeView1.Nodes.Clear();

            foreach ( Library lib in code.Libraries )
            {
                TreeNode tn = new TreeNode();
                tn.ImageKey = "library";
                tn.SelectedImageKey = "library";
                tn.Text = lib.Name;
                tn.Tag = lib;
                treeView1.Nodes.Add( tn );
            }
        }

        private void treeView1_AfterSelect( object sender, TreeViewEventArgs e )
        {
            if ( e.Node == null )
                return;

            if ( e.Node.Tag is Library )
            {
                Library lib = ( Library )e.Node.Tag;
                treeView2.Nodes.Clear();

                foreach ( Member memb in lib.Members )
                {
                    TreeNode tn = new TreeNode();
                    LibraryMember lm = new LibraryMember();
                    lm.Library = lib;
                    lm.Member = memb;

                    if ( memb is Function )
                    {
                        Function func = ( Function )memb;
                        tn.Text = func.Name + "(" + func.Params + ")";
                        tn.Tag = lm;
                        switch ( func.Type )
                        {
                            case "SHARED":
                                tn.ImageKey = "shared";
                                tn.SelectedImageKey = "shared";
                                break;
                            case "SERVER":
                                tn.ImageKey = "server";
                                tn.SelectedImageKey = "server";
                                break;
                            case "CLIENT":
                                tn.ImageKey = "client";
                                tn.SelectedImageKey = "client";
                                break;
                        }
                    }
                    else if ( memb is Property )
                    {
                        Property prop = ( Property )memb;
                        tn.Text = prop.Name;
                        tn.Tag = lm;
                        switch ( prop.Type )
                        {
                            case "SHARED":
                                tn.ImageKey = "shared";
                                tn.SelectedImageKey = "shared";
                                break;
                            case "SERVER":
                                tn.ImageKey = "server";
                                tn.SelectedImageKey = "server";
                                break;
                            case "CLIENT":
                                tn.ImageKey = "client";
                                tn.SelectedImageKey = "client";
                                break;
                        }
                    }

                    treeView2.Nodes.Add( tn );

                }

                HTML doc = new HTML();
                doc.Header();
                doc.AddLine( "Library " );
                doc.AddLine("<b>");
                doc.AddLine( lib.Name );
                doc.AddLine("</b>");
                doc.AddLine( "\n\n" );
                doc.AddLine("<b>");
                doc.AddLine( "Summary:");
                doc.AddLine("</b>");
                doc.AddLine("\n" + lib.Description);
                doc.AddLine("\n\n");
                doc.AddLine("Wiki: <a href=\"http://www.garrysmod.com/wiki/?title=" + lib.Name + "\">" + lib.Name + "</a>");
                doc.Footer();
                wb.DocumentStream = doc.GetStream();
            }
            else if ( e.Node.Tag is LibraryMember )
            {
                treeView2.Nodes.Clear();

                LibraryMember lm = ( LibraryMember )e.Node.Tag;
                Library lib = lm.Library;
                Member memb = lm.Member;

                if ( memb is Function )
                {
                    Function func = ( Function )memb;

                    HTML doc = new HTML();
                    doc.Header();
                    doc.AddLine( func.Return + " " );
                    doc.AddLine( "<b>" );
                    doc.AddLine( lib.Name );
                    doc.AddLine( "</b>" );
                    doc.AddLine( "." );
                    doc.AddLine( "<b>" );
                    doc.AddLine( func.Name );
                    doc.AddLine( "</b>" );
                    doc.AddLine( "(" );
                    string paramText = "";
                    foreach ( Parameter param in func.Parameters )
                    {
                        paramText += param.DataType + " " + param.Name + ", ";
                    }
                    paramText = paramText.TrimEnd( ',', ' ' );
                    doc.AddLine( paramText + ")\n\n" );
                    doc.AddLine( "<b>" );
                    doc.AddLine( "Summary:" );
                    doc.AddLine( "</b>" );
                    doc.AddLine( "\n" + func.Description + "\n\n" );
                    if ( func.Parameters.Count > 0 )
                    {
                        doc.AddLine( "<b>" );
                        doc.AddLine( "Parameters:" );
                        doc.AddLine( "</b>" );
                    }
                    foreach ( Parameter param in func.Parameters )
                    {
                        doc.AddLine("<i>");
                        doc.AddLine( "\n" + param.Name );
                        doc.AddLine( "</i>" );
                        doc.AddLine( ": " + param.Description );
                    }
                    doc.Footer();
                    wb.DocumentStream = doc.GetStream();

                }
                else if ( memb is Property )
                {
                    Property prop = ( Property )memb;

HTML doc = new HTML();
                    doc.Header();
                    doc.AddLine( prop.DataType + " " );
                    doc.AddLine( "<b>" );
                    doc.AddLine( lib.Name );
                    doc.AddLine( "</b>" );
                    doc.AddLine( "." );
                    doc.AddLine( "<b>" );
                    doc.AddLine( prop.Name );
                    doc.AddLine( "</b>" );
                    doc.AddLine( "\n\n" );
                    doc.AddLine( "<b>" );
                    doc.AddLine( "Summary:" );
                    doc.AddLine( "</b>" );
                    doc.AddLine( "\n" + prop.Description );
                    doc.Footer();
                    wb.DocumentStream = doc.GetStream();
                }
            }
        }
        private void treeView2_AfterSelect( object sender, TreeViewEventArgs e )
        {
            if ( e.Node == null )
                return;

            LibraryMember lm = ( LibraryMember )e.Node.Tag;
            Library lib = lm.Library;
            Member memb = lm.Member;

            

            if ( memb is Function )
            {
                Function func = ( Function )memb;
                HTML doc = new HTML();
                doc.Header();
                doc.AddLine( func.Return + " " );
                doc.AddLine( "<b>" );
                doc.AddLine( func.Name );
                doc.AddLine( "</b>" );
                doc.AddLine( "(" );
                string paramText = "";
                foreach ( Parameter param in func.Parameters )
                {
                    paramText += param.DataType + " " + param.Name + ", ";
                }
                paramText = paramText.TrimEnd( ',', ' ' );
                doc.AddLine( paramText + ")\n\n" );
                doc.AddLine( "<b>" );
                doc.AddLine( "Summary:" );
                doc.AddLine( "</b>" );
                doc.AddLine( "\n" + func.Description + "\n\n" );
                if ( func.Parameters.Count > 0 )
                {
                    doc.AddLine( "<b>" );
                    doc.AddLine( "Parameters:" );
                    doc.AddLine( "</b>" );
                }
                foreach ( Parameter param in func.Parameters )
                {
                    doc.AddLine("<i>");
                    doc.AddLine( "\n" + param.Name );
                    doc.AddLine( "</i>" );
                    doc.AddLine( ": " + param.Description );
                }
                doc.AddLine("\n\n");
                doc.AddLine("Wiki: <a href=\"http://www.garrysmod.com/wiki/?title=" + lib.Name + "." + func.Name + "\">" + lib.Name + "." + func.Name + "</a>");
                doc.Footer();
                wb.DocumentStream = doc.GetStream();

            }
            else if ( memb is Property )
            {
                Property prop = ( Property )memb;

                HTML doc = new HTML();
                doc.Header();
                doc.AddLine( prop.DataType + " " );
                doc.AddLine( "<b>" );
                doc.AddLine( lib.Name );
                doc.AddLine( "</b>" );
                doc.AddLine( "." );
                doc.AddLine( "<b>" );
                doc.AddLine( prop.Name );
                doc.AddLine( "</b>" );
                doc.AddLine( "\n\n" );
                doc.AddLine( "<b>" );
                doc.AddLine( "Summary:" );
                doc.AddLine( "</b>" );
                doc.AddLine( "\n" + prop.Description );
                doc.Footer();
                wb.DocumentStream = doc.GetStream();
            }
        }

        private void toolStripButton1_Click( object sender, EventArgs e )
        {
            if ( String.IsNullOrEmpty( toolStripComboBox1.Text ) )
                return;

            toolStripComboBox1.Items.Add( toolStripComboBox1.Text );

            treeView1.Nodes.Clear();
            treeView2.Nodes.Clear();

            foreach ( Library lib in code.Libraries )
            {
                if ( lib.Name.IndexOf( toolStripComboBox1.Text, 0, StringComparison.InvariantCultureIgnoreCase ) != -1 )
                {
                    TreeNode tn = new TreeNode();
                    tn.ImageKey = "library";
                    tn.SelectedImageKey = "library";
                    tn.Text = lib.Name;
                    tn.Tag = lib;
                    treeView1.Nodes.Add( tn );
                }
                foreach ( Member memb in lib.Members )
                {

                    if ( memb is Function )
                    {
                        LibraryMember lm = new LibraryMember();
                        lm.Library = lib;
                        lm.Member = memb;
                        Function func = ( Function )memb;

                        if ( func.Name.IndexOf( toolStripComboBox1.Text, 0, StringComparison.InvariantCultureIgnoreCase ) != -1 )
                        {

                            TreeNode tn = new TreeNode();
                            tn.Text = func.Name + "(" + func.Params + ")";
                            tn.Tag = lm;
                            switch ( func.Type )
                            {
                                case "SHARED":
                                    tn.ImageKey = "shared";
                                    tn.SelectedImageKey = "shared";
                                    break;
                                case "SERVER":
                                    tn.ImageKey = "server";
                                    tn.SelectedImageKey = "server";
                                    break;
                                case "CLIENT":
                                    tn.ImageKey = "client";
                                    tn.SelectedImageKey = "client";
                                    break;
                            }
                            treeView1.Nodes.Add( tn );
                        }
                    }
                    else if ( memb is Property )
                    {
                        LibraryMember lm = new LibraryMember();
                        lm.Library = lib;
                        lm.Member = memb;
                        Property prop = ( Property )memb;
                        if ( prop.Name.IndexOf( toolStripComboBox1.Text, 0, StringComparison.InvariantCultureIgnoreCase ) != -1 )
                        {
                            TreeNode tn = new TreeNode();
                            tn.Text = prop.Name;
                            tn.Tag = lm;
                            switch ( prop.Type )
                            {
                                case "SHARED":
                                    tn.ImageKey = "shared";
                                    tn.SelectedImageKey = "shared";
                                    break;
                                case "SERVER":
                                    tn.ImageKey = "server";
                                    tn.SelectedImageKey = "server";
                                    break;
                                case "CLIENT":
                                    tn.ImageKey = "client";
                                    tn.SelectedImageKey = "client";
                                    break;
                            }
                            treeView1.Nodes.Add( tn );
                        }
                    }
                }
            }
        }
        private void toolStripButton2_Click( object sender, EventArgs e )
        {
            toolStripComboBox1.Text = "<Search>";
            treeView2.Nodes.Clear();
            LoadLibs( code );
        }

        private void toolStripComboBox1_KeyDown( object sender, KeyEventArgs e )
        {
            if ( e.KeyCode == Keys.Enter )
                toolStripButton1_Click( null, null );
        }
        private void toolStripComboBox1_TextChanged( object sender, EventArgs e )
        {
            if ( toolStripComboBox1.Text == "<Search>" )
            {
                toolStripButton1.Enabled = false;
            }
            else
            {
                toolStripButton1.Enabled = true;
            }
        }

        private void ObjectBrowser_Load(object sender, EventArgs e)
        {
           myWorkspace.HideProjectExplorer();
        }

        private void wb_NewWindow(object sender, CancelEventArgs e)
        {
            
        }

        private void wb_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
            if (e.Url.ToString() != "about:blank")
            {
                WebWindow ww = new WebWindow(e.Url.ToString());
                ww.Show(myWorkspace.Manager);
                e.Cancel = true;
            }

        }

        private void wb_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {

        }

        private void wb_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }


    }
    public class LibraryMember
    {
        public Library Library;
        public Member Member;
    }
}
