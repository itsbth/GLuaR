/*

    This file is part of GLua

    GLua Development Environment
    Copyright (C) 2007 VoiDeD

    GLua is free software; you can redistribute it and/or modify
    it under the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation; either version 3 of the License, or
    (at your option) any later version.

    GLua is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU Lesser General Public License for more details.

    You should have received a copy of the GNU Lesser General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.

*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

using Fireball.Docking;

using GLuaR.Windows.Dialogs;

using GLuaR.Classes;
using GLuaR.Classes.Workspace;

namespace GLuaR.Windows.DockingWindows
{
    // this is the control displayed with the project info tab
    // this is completed and shouldn't be edited, but go ahead if you want

    /* 
     * This control is used like this
     * 
     * 1) Code creates a new ProjectProperties object for a specific project
     * 2) Save is called when the save button is clicked
     * 3) Retrieve an updated Project by using ProjectProperties.PRoject
     * 
     */
    public partial class ProjectProperties : DockableWindow
    {
        Project project;

        public ProjectProperties(Project proj)
        {
            InitializeComponent();
            project = proj;
            textBox1.Text = proj.Name;
            textBox2.Text = proj.Description;
            comboBox1.SelectedItem = proj.Type.ToString();
            textBox3.Text = proj.Version;
            textBox4.Text = proj.Update;
            textBox5.Text = proj.AuthorName;
            textBox6.Text = proj.AuthorEmail;
            textBox7.Text = proj.AuthorWebsite;

            checkBox1.Checked = proj.HideEntry;

            for ( int x= 0; x < proj.Requirements.Count; x++)
            {
                ListViewItem lvi = new ListViewItem( x.ToString() );
                lvi.SubItems.Add( new ListViewItem.ListViewSubItem( lvi, proj.Requirements[x].AppID.ToString() ) );
                listView1.Items.Add( lvi );
            }
        }

        private void button1_Click( object sender, EventArgs e )
        {
            GCFRequirementDialog grd = new GCFRequirementDialog();

            if ( grd.ShowDialog() != DialogResult.OK )
                return;

            if ( grd.AppId == -1 )
                return;

            AddItem( grd.AppId );
        }
        private void button2_Click( object sender, EventArgs e )
        {
            if ( listView1.SelectedItems.Count > 0 )
            {
                listView1.Items.Remove( listView1.SelectedItems[0] );
            }
        }
        private void comboBox1_SelectedIndexChanged( object sender, EventArgs e )
        {
            if ( comboBox1.SelectedItem.ToString() == "Addon" )
            {
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }
        }
        private void button3_Click( object sender, EventArgs e )
        {
            Save();

        }


        public Project Project
        {
            get { return project; }
        }

        // util
        private void AddItem( int id )
        {
            ListViewItem lvi = new ListViewItem( listView1.Items.Count.ToString() );
            lvi.SubItems.Add( new ListViewItem.ListViewSubItem( lvi, id.ToString() ) );
            listView1.Items.Add( lvi );
        }
        public void Save()
        {
            foreach ( char chr in textBox1.Text.ToCharArray() )
            {
                foreach ( char invalidChar in Path.GetInvalidFileNameChars() )
                {
                    if ( chr == invalidChar )
                    {
                        Util.ShowError( StringTable.InvalidProjectName );
                        return;
                    }
                }
            }

            if ( project.Name != textBox1.Text )
            {
                File.Copy( project.Path + "\\" + project.Name + ".glu", project.Path + "\\" + textBox1.Text + ".glu" );
                File.Delete( project.Path + "\\" + project.Name + ".glu" );
            }
            project.FullName = project.Path + "\\" + textBox1.Text + ".glu";
            project.Name = textBox1.Text;
            project.Description = textBox2.Text;
            project.Type = ( ProjectType )Enum.Parse( typeof( ProjectType ), comboBox1.SelectedItem.ToString() );
            project.Version = textBox3.Text;
            project.Update = textBox4.Text;
            project.AuthorName = textBox5.Text;
            project.AuthorEmail = textBox6.Text;
            project.AuthorWebsite = textBox7.Text;

            project.HideEntry = checkBox1.Checked;

            project.Requirements.Clear();
            foreach ( ListViewItem lvi in listView1.Items )
            {
                Requirement req = new Requirement();
                req.AppID = Convert.ToInt32( lvi.SubItems[1].Text );
                project.Requirements.Add( req );
            }
        }

    }
}
