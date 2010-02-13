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
using System.Xml.Serialization;
using System.Windows.Forms;
using System.IO;

using Fireball.Windows.Forms;

namespace GLuaR.Classes.Workspace
{
    public class OpenedFile
    {
        /// <summary>
        /// The name of the file
        /// </summary>
        public string Name;

        /// <summary>
        /// The fullname of the file
        /// </summary>
        [XmlIgnore]
        public string FullName;

        /// <summary>
        /// Determines if the file is saved
        /// </summary>
        [XmlIgnore]
        public bool Saved;

        /// <summary>
        /// Used to determine whether this is in a project or not.
        /// </summary>
        [XmlIgnore]
        public bool InProject;

        /// <summary>
        /// The syntax editor control for this file
        /// </summary>
        [XmlIgnore]
        public CodeEditorControl Editor;

        /// <summary>
        /// The treenode used to display this file
        /// </summary>
        [XmlIgnore]
        public TreeNode Node;
        

        /// <summary>
        /// Determines if this file is valid and could be loaded
        /// </summary>
        [XmlIgnore]
        public bool Valid;

        /// <summary>
        /// Folder the file is present in (Used for TreeView)
        /// </summary>
        [XmlIgnore]
        public Folder Folder;

        /// <summary>
        /// Saves the file
        /// </summary>
        public void Save ( )
        {
            if ( Editor == null )
                return;
            Editor.Save( FullName );
            Saved = true;

            if ( Editor.Parent == null )
                return;
            Editor.Parent.Text = Editor.Parent.Text.TrimEnd( '*' );
            return;
        }
    }
}
