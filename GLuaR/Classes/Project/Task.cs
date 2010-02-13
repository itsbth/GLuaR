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
using System.Text;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace GLuaR.Classes
{
    [XmlInclude(typeof(TaskPriority))]
    public class Task
    {
        public enum TaskPriority
        {
            Later,
            ToDo,
            Normal,
            LessImportant,
            MoreImportant,
        }
        [XmlIgnore]
        public ListViewItem lvm = new ListViewItem( );

        public Task( )
        {
            lvm.SubItems.Add( "" );
            lvm.SubItems.Add( "" );
        }

        public TaskPriority Priority
        {
            get { return priority; }
            set
            {
                priority = value;
                lvm.SubItems[ 1 ].Text = priority.ToString( );
            }
        }
        TaskPriority priority = TaskPriority.Normal;

        bool done = false;
        public bool Done { get { return done; } set { done = value; if( lvm.Checked != done ) lvm.Checked = done; } }

        string text = "Enter your task name here";
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                lvm.SubItems[ 2 ].Text = text;
            }
        }

    }
}
