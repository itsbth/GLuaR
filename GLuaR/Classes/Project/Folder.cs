/*

    This file is part of GLua

    GLua Development Environment
    Copyright (C) 2007 Marine and VoiDeD

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

using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using GLuaR.Classes.Workspace;

namespace GLuaR.Classes
{
    /// <summary>
    /// Represents a folder of files
    /// </summary>
    public class Folder
    {
        /// <summary>
        /// List of files within the folder
        /// </summary>
        public List<OpenedFile> Files;

        /// <summary>
        /// List of folders within the folder
        /// </summary>
        public List<Folder> Folders;

        /// <summary>
        /// Folder Name (Shown in the project view)
        /// </summary>
        public string Name;

        /// <summary>
        /// Treeview Node
        /// </summary>
        [XmlIgnore] public TreeNode Node;

        /// <summary>
        /// Parent Folder, null if none.
        /// </summary>
        [XmlIgnore] public Folder Parent;

        /// <summary>
        /// Project the folder is in
        /// </summary>
        [XmlIgnore] public Project Project;

        /// <summary>
        /// WorkSpace
        /// </summary>
        [XmlIgnore] public Workspace.Workspace WorkSpace;

        public Folder()
        {
            Folders = new List<Folder>();
            Files = new List<OpenedFile>();
        }

        public string FullName()
        {
            string filepath = Project.Path;

            // Recurse through the folders (parents) until the parent is null, then work our way back through
            Folder ff = this;

            var fldrList = new List<Folder>();

            while (ff != null)
            {
                fldrList.Add(ff);
                ff = ff.Parent;
            }

            for (int i = fldrList.Count - 1; i >= 0; i--)
            {
                if (ff == this)
                {
                    break;
                }
                ff = fldrList[i];
                filepath += @"\" + ff.Name;
            }
            return filepath;
        }

        public void BuildTreeview(Workspace.Workspace work, Project proj)
        {
            Project = proj;

            foreach (Folder f in Folders)
            {
                var node = new TreeNode
                               {
                                   Text = f.Name,
                                   ContextMenuStrip = work.FolderStrip,
                                   ImageKey = "project_folder_closed",
                                   SelectedImageKey = "project_folder_closed",
                                   Tag = f
                               };
                f.Node = node;
                Node.Nodes.Add(node);

                f.BuildTreeview(work, proj);
            }

            foreach (OpenedFile pf in Files)
            {
                string filepath = FullName();

                filepath += @"\";

                if (!File.Exists(filepath + pf.Name))
                {
                    pf.Valid = false;
                    pf.Saved = true;
                    pf.Folder = this;
                    var node = new TreeNode
                                   {
                                       Text = pf.Name,
                                       ContextMenuStrip = work.CodeStrip,
                                       ImageKey = "file_lost",
                                       SelectedImageKey = "file_lost",
                                       Tag = pf
                                   };
                    pf.Node = node;
                    Node.Nodes.Add(node);
                    continue;
                }

                pf.FullName = filepath + pf.Name;
                pf.Saved = true;
                pf.Valid = true;
                pf.Folder = this;

                var tn2 = new TreeNode
                              {
                                  Text = pf.Name,
                                  ContextMenuStrip = work.CodeStrip,
                                  ImageKey = "code",
                                  SelectedImageKey = "code",
                                  Tag = pf
                              };
                pf.Node = tn2;

                Node.Nodes.Add(tn2);
            }
        }

        /// <summary>
        /// Recurses through all files and checks if they are saved, then recurses through all folders and does the same...
        /// </summary>
        /// <returns>True if everything is saved, otherwise false</returns>
        public bool AllFilesSaved()
        {
            foreach (Folder f in Folders)
            {
                if (!f.AllFilesSaved())
                    return false;
            }

            foreach (OpenedFile of in Files)
            {
                if (!of.Saved)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// Save's all files
        /// </summary>
        public void Save()
        {
            foreach (Folder f in Folders)
            {
                f.Save();
            }
            foreach (OpenedFile f in Files)
            {
                f.Save();
            }
        }

        public bool ContainsFile(string name)
        {
            foreach (Folder f in Folders)
            {
                if (f.ContainsFile(name))
                    return true;
            }
            foreach (OpenedFile of in Files)
            {
                if (of.Name == name)
                    return true;
            }
            return false;
        }

        public void RebuildParents(Folder parentFolder, bool rootFolder)
        {
            Parent = rootFolder ? null : parentFolder;

            foreach (Folder folder in Folders)
                folder.RebuildParents(this, false);
        }
    }
}