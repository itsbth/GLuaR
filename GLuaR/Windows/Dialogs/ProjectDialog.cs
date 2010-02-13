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
using System.Windows.Forms;
using GLuaR.Classes.Templates;
using GLuaR.Properties;

namespace GLuaR.Windows.Dialogs
{
    // this is a dialog used when a new project is being created
    public partial class ProjectDialog : Form
    {
        public ProjectDialog()
        {
            InitializeComponent();

            comboBox1.SelectedIndex = 0;
            imageList1.Images.Add("empty_project", Resources.empty_project);


            foreach (ProjectTemplate pt in Templates.ProjectTemps)
            {
                var lvi = new ListViewItem
                              {
                                  ImageKey = "empty_project",
                                  StateImageIndex = 0,
                                  Text = pt.Name,
                                  Tag = pt,
                                  Group = listView1.Groups[0]
                              };

                listView1.Items.Add(lvi);
            }
            listView1.Items[0].Selected = true;

            textBox3.Text = Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\GLuaR Projects\\";
        }

        public string ProjectName
        {
            get { return textBox2.Text; }
        }

        public string ProjectDescription
        {
            get { return textBox4.Text; }
        }

        public ProjectType ProjectType
        {
            get
            {
                var project = (ProjectTemplate) listView1.SelectedItems[0].Tag;

                if (project.AllowType)
                {
                    var type = (ProjectType) Enum.Parse(typeof (ProjectType), comboBox1.Text);
                    return type;
                }
                return project.ForcedType;
            }
        }

        public string ProjectPath
        {
            get { return textBox3.Text; }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var fbd = new FolderBrowserDialog
                          {
                              Description = "Please choose the directory to save the project at.",
                              ShowNewFolderButton = true
                          };

            if (fbd.ShowDialog() != DialogResult.OK)
                return;

            textBox3.Text = fbd.SelectedPath;
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEnable();
            if (listView1.SelectedItems.Count <= 0) return;
            textBox2.Text = ((ProjectTemplate) listView1.SelectedItems[0].Tag).DefaultName;
            textBox3.Text =
                Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\GLuaR Projects\\" + textBox2.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            UpdateEnable();
            textBox3.Text =
                Environment.GetFolderPath(Environment.SpecialFolder.Personal) + "\\GLuaR Projects\\" + textBox2.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            UpdateEnable();
        }

        private void UpdateEnable()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                var project = (ProjectTemplate) listView1.SelectedItems[0].Tag;
                textBox1.Text = project.Description;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox4.Enabled = true;
                button3.Enabled = true;

                if (project.AllowType)
                    comboBox1.Enabled = true;

                if ((textBox2.Text.Length > 0) && (textBox3.Text.Length > 0))
                {
                    button1.Enabled = true;
                }
                else
                {
                    button1.Enabled = false;
                }
            }
            else
            {
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                button1.Enabled = false;
                button3.Enabled = false;
            }
        }
    }
}