/*

    This file is part of GLuaR

    GLuaR Development Environment
    Copyright (C) 2007 "Marine" (FPMarine@googlemail.com).
    Portions by "VoiDeD".

    GLuaR is free software; you can redistribute it and/or modify
    it under the terms of the GNU Lesser General Public License as published by
    the Free Software Foundation; either version 3 of the License, or
    (at your option) any later version.

    GLuaR is distributed in the hope that it will be useful,
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
using System.Diagnostics;

namespace GLuaR
{
    // this dialog is displayed whenever an error occurs from within the main window
    // I've had issues where people got the default .NET exception dialog box and I couldn't figure out why
    // Look at Program.Main() for more info
    public partial class ErrorDialog : Form
    {
        public ErrorDialog(Exception ex)
        {
            InitializeComponent();
            textBox1.Text = "Type: " + ex.GetType().Name + "\r\n" +
                "Message: " + ex.Message + "\r\n" + "Source: " + ex.Source + "\r\n" +
                "Exception Stack Trace:\r\n" + ex.StackTrace;
           button2.Image = global::GLuaR.Properties.Resources.run_search;
            ( ( Bitmap )button2.Image ).MakeTransparent( Color.Magenta );
        }

        private void button1_Click( object sender, EventArgs e )
        {
            this.Close();
        }
        private void button2_Click( object sender, EventArgs e )
        {
            try
            {
                Process.Start( "http://glua.net/bugtrack/index.php?do=index&project=3" );
            }
            catch { }
        }
    }
}