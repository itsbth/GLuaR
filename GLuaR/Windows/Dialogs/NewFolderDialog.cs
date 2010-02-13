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

using GLuaR.Classes.Templates;

namespace GLuaR
{
    // this dialog is used when a new file is being added
    public partial class NewFolderDialog : Form
    {
        public NewFolderDialog()
        {
            InitializeComponent();
        }

        private void txtFolderName_TextChanged ( object sender, EventArgs e )
        {
            if ( txtFolderName.Text == "" )
                btnAdd.Enabled = false;
            else
                btnAdd.Enabled = true;
        }

        private void btnAdd_Click ( object sender, EventArgs e )
        {

        }

        private void NewFolderDialog_Load ( object sender, EventArgs e )
        {

        }
    }
}