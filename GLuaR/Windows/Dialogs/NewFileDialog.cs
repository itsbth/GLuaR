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

namespace GLuaR
{
    // this dialog is used when a new file is being added
    public partial class NewFileDialog : Form
    {
        public NewFileDialog()
        {
            InitializeComponent();
            imageList1.Images.Add("lua_file", Resources.lua_file);

            foreach (Template temp in Templates.FileTemps)
            {
                if (!temp.Visible) continue;
                var lvi = new ListViewItem
                              {
                                  Text = temp.Name,
                                  Tag = temp,
                                  StateImageIndex = 0,
                                  ImageKey = "lua_file",
                                  Group = listView1.Groups[0]
                              };
                listView1.Items.Add(lvi);
            }
            listView1.Items[0].Selected = true;
        }

        public Template SelectedTemplate
        {
            get { return (Template) listView1.SelectedItems[0].Tag; }
        }

        public string FileName
        {
            get { return txtFileName.Text; }
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateEnable();
            if (listView1.SelectedItems.Count > 0)
                txtFileName.Text = ((Template) listView1.SelectedItems[0].Tag).DefaultFileName;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            UpdateEnable();
        }

        private void UpdateEnable()
        {
            if (listView1.SelectedItems.Count > 0)
            {
                txtFileName.Enabled = true;
                var template = (Template) listView1.SelectedItems[0].Tag;
                textBox1.Text = template.Description;

                if (txtFileName.Text.Length > 0)
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
                textBox1.Text = "";
                txtFileName.Text = "";
                txtFileName.Enabled = false;
                button1.Enabled = false;
            }
        }
    }
}