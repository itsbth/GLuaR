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

namespace GLuaR.Windows.Dialogs
{
    // this dialog is used to select GCF requirements in the project properties control
    public partial class GCFRequirementDialog : Form
    {
        public GCFRequirementDialog()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void radioButton1_CheckedChanged( object sender, EventArgs e )
        {
            comboBox1.Enabled = radioButton1.Checked;
            textBox1.Enabled = radioButton2.Checked;
        }

        private void radioButton2_CheckedChanged( object sender, EventArgs e )
        {
            comboBox1.Enabled = radioButton1.Checked;
            textBox1.Enabled = radioButton2.Checked;
        }

        public int AppId
        {
            get
            {
                if ( radioButton1.Checked )
                {
                    if ( comboBox1.SelectedIndex >= 0 )
                    {
                        string[] strs = comboBox1.SelectedItem.ToString().Split( '(' );
                        string app = strs[strs.Length - 1].TrimEnd( ')' );
                        return Convert.ToInt32( app );
                    }
                    else
                    {
                        Util.ShowError( StringTable.AppNotSelected );
                        return -1;
                    }
                }
                else
                {
                    try
                    {
                        return Convert.ToInt32( textBox1.Text );
                    }
                    catch
                    {
                        Util.ShowError( StringTable.InvalidAppID );
                        return -1;
                    }
                }
            }
        }
    }
}