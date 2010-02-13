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
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using Fireball.Docking;
using Fireball.Windows.Forms;
using GLuaR.Windows.Dialogs;
using GLuaR.Windows.DockingWindows;

namespace GLuaR.Classes.Workspace
{
    public class Workspace
    {
        private readonly WebWindow _bug;
        private readonly CodeProvider _code;
        private readonly ProjectExplorer _explorer;
        private readonly ObjectBrowser _obj;
        public ContextMenuStrip CodeStrip;
        public ContextMenuStrip EditStrip;
        public ContextMenuStrip FolderStrip;
        public ImageList ImageList;
        public DockContainer Manager;
        public Project Project;
        // Removed by Marine
        // Settings settings;
        public ContextMenuStrip ProjectStrip;
        public ContextMenuStrip TabStrip;
        public TreeView TreeView;
        private bool _fileLoading;
        private OutputWindow _output;
        private ProjectProperties _projProperties;
        private TaskWindow _taskList;

        /// <summary>
        /// Creates a new Environment class
        /// </summary>
        /// <param name="sdm">The docking manager used by GLua</param>
        /// <param name="tStrip">Tab context menu</param>
        /// <param name="eStrip">Edit control context menu</param>
        /// <param name="pStrip">Project node context menu</param>
        /// <param name="cStrip">Code node context menu</param>
        /// <param name="fStrip">Folder node context menu</param>
        /// <param name="code">Code provider for code completion</param>
        public Workspace(DockContainer sdm, ContextMenuStrip tStrip, ContextMenuStrip eStrip, ContextMenuStrip pStrip,
                         ContextMenuStrip cStrip, ContextMenuStrip fStrip, ImageList images)
        {
            // set all the values
            Manager = sdm;
            ImageList = images;

            _explorer = new ProjectExplorer(this);
            TreeView = _explorer.tvFiles;
            ImageList = _explorer.imgList;
            _explorer.Show(sdm, DockState.DockLeft); //, DockState.DockLeft);

            _bug = new WebWindow("http://code.google.com/p/gluar/issues/list") {TabText = "Bug Reporter"};

            TabStrip = tStrip;
            EditStrip = eStrip;
            ProjectStrip = _explorer.projectMenu;
            CodeStrip = _explorer.fileMenu;
            FolderStrip = _explorer.folderMenu;

            // used to set the right clicked node as the current node
            //treeView.NodeMouseClick += new TreeNodeMouseClickEventHandler(treeView_NodeMouseClick);

            // Taken out by Marine
            // !  Put back in by VoiDeD
            // load the code database and settings
            _code = CodeProvider.Load(Application.StartupPath + "\\code.db");

            _obj = new ObjectBrowser(_code, images, this);

            // Taken out by Marine
            // Get working in next version
            //settings = Settings.Load( Application.StartupPath + "\\data\\settings.xml" );
        }

        /// <summary>
        /// Checks if a project is open
        /// </summary>
        /// <returns>True if a project is open, otherwise false</returns>
        public bool IsProjectOpen()
        {
            return (Project != null);
        }

        /// <summary>
        /// Checks if the current project is saved, does not check if a project is open
        /// </summary>
        /// <returns>True if saved, otherwise false</returns>
        public bool IsProjectSaved()
        {
            return Project.IsProjectSaved();
        }

        /// <summary>
        /// Checks if a specific project file is shown in the interface
        /// </summary>
        /// <param name="file">The project file to check</param>
        /// <returns>True if the file is open, otherwise false</returns>
        public bool IsProjectFileShown(OpenedFile file)
        {
            foreach (DockableWindow tp in Manager.Documents)
            {
                if (IsSpecialTab(tp)) continue;
                if (tp.Tag == file)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if a special tab is open, such as the Object Browser
        /// </summary>
        /// <param name="tab">The special tab to check</param>
        /// <returns>True if the tab is shown, otherwise false</returns>
        public bool IsSpecialTabShown(SpecialTab tab)
        {
            foreach (DockableWindow tp in Manager.Documents)
            {
                if (!IsSpecialTab(tp)) continue;
                if (((SpecialTab) tp.Tag).Type == tab.Type)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the object browser window is shown
        /// </summary>
        /// <returns>Returns true if the object browser is shown, otherwise false</returns>
        public bool IsObjectBrowserShown()
        {
            foreach (DockableWindow tp in Manager.Documents)
            {
                if (!IsSpecialTab(tp)) continue;
                if (((SpecialTab) tp.Tag).Type == TabType.ObjectBrowser)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if the project info window is shown
        /// </summary>
        /// <returns>Returns true if the project info window is shown, otherwise false</returns>
        public bool IsProjectInfoShown()
        {
            foreach (DockableWindow tp in Manager.Documents)
            {
                if (!IsSpecialTab(tp)) continue;
                if (((SpecialTab) tp.Tag).Type == TabType.ProjectInfo)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Checks if a tab window is a special tab
        /// </summary>
        /// <param name="tp">The window to check</param>
        /// <returns>True if the window is a special tab, otherwise false</returns>
        public static bool IsSpecialTab(DockableWindow tp)
        {
            return (tp != null) && (tp.GetType().Name != "CodeTab");
        }

        /// <summary>
        /// Checks if a specific dockable window is a special tab
        /// </summary>
        /// <param name="tp">The window to check</param>
        /// <returns>True if the window is a special tab, otherwise false</returns>
        //public bool IsSpecialTab( DockableWindow tp )
        //{
        //    return ((tp is DockableWindow) && (tp.Tag is SpecialTab));
        //}
        /// <summary>
        /// Checks if any tabs are open
        /// </summary>
        /// <returns>True if a tab is open, otherwise false</returns>
        public bool IsTabOpen()
        {
            return (Manager.Documents.Length > 0);
        }

        /// <summary>
        /// Checks if any code tabs are open
        /// </summary>
        /// <returns>True if a tab is open, otherwise false</returns>
        public bool IsCodeTabOpen()
        {
            if (IsTabOpen())
            {
                foreach (DockableWindow td in Manager.Documents)
                {
                    if (IsCodeTab(td))
                        return true;
                }
                return false;
            }
            return false;
        }

        /// <summary>
        /// Checks if the active tab is a special tab
        /// </summary>
        /// <returns>True if the tab is a special tab, otherwise false</returns>
        public bool IsActiveTabSpecial()
        {
            return IsSpecialTab((DockableWindow) Manager.ActiveDocument);
        }

        /// <summary>
        /// Checks if a tab is a code tab
        /// </summary>
        /// <param name="tp">The tab to check</param>
        /// <returns>True if the tab is a code tab, otherwise false</returns>
        public static bool IsCodeTab(DockableWindow tp)
        {
            return (tp != null) && ((tp.GetType().Name == "CodeTab"));
        }

        /// <summary>
        /// Checks if a window is a code tab
        /// </summary>
        /// <param name="tp">The window to check</param>
        /// <returns>True if the window is a code tab, otherwise false</returns>
        //public bool IsCodeTab( DockableWindow tp )
        //{
        //    return ((tp is DockableWindow) && !(tp.Tag is SpecialTab));
        //}
        /// <summary>
        /// Checks if a specific char is a char that strings should be split by, used for auto-completion
        /// </summary>
        /// <param name="chr">The character to check</param>
        /// <returns>True if the char is a split char, otherwise false</returns>
        public bool IsSplitChar(char chr)
        {
            return (
                       (chr == ' ') ||
                       (chr == '\t') ||
                       (chr == '\r') ||
                       (chr == '\n') ||
                       (chr == '(') ||
                       (chr == '|') ||
                       (chr == '!') ||
                       (chr == '.') ||
                       (chr == ':') ||
                       (chr == '&') ||
                       (chr == '~') ||
                       (chr == '-')
                   );
        }

        /// <summary>
        /// Checks if a file in the project exists by name
        /// </summary>
        /// <param name="fullname">The filename to check</param>
        /// <returns>True if the file exists, otherwise false</returns>
        public bool DoesProjectFileExist(string fullname)
        {
            if (IsProjectOpen())
            {
                foreach (OpenedFile pf in Project.Files)
                {
                    if (pf.FullName == fullname)
                        return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Returns the name of the currently focused tab
        /// </summary>
        /// <returns>The name of the tab</returns>
        public string GetActiveTabName()
        {
            return IsTabOpen() ? Manager.ActiveDocument.DockHandler.TabText : "";
        }

        /// <summary>
        /// Returns a tree node object of the currently focused node
        /// </summary>
        /// <returns>The treenode</returns>
        public TreeNode GetSelectedTreeNode()
        {
            return TreeView.SelectedNode ?? null;
        }

        /// <summary>
        /// Clears all nodes and tabs
        /// </summary>
        public void Clear()
        {
            ClearNodes();
            ClearTabs();
            _taskList.lstTasks.Items.Clear();
            _output.Hide();
            _output.Dispose();

            _taskList.Hide();
            _taskList.Dispose();
        }

        /// <summary>
        /// Clears all the nodes in the treeview
        /// </summary>
        public void ClearNodes()
        {
            TreeView.Nodes.Clear();
        }

        /// <summary>
        /// Clears all tabs in the environment, but keeps the object browser open
        /// </summary>
        public void ClearTabs()
        {
            foreach (DockableWindow tp in Manager.Documents)
            {
                if (IsSpecialTab(tp))
                {
                    if (((SpecialTab) tp.Tag).Type == TabType.ObjectBrowser)
                        continue;
                }
                tp.Close();
            }
        }

        /// <summary>
        /// Refreshes the nodes of the current project
        /// </summary>
        public void ReloadNodes()
        {
            ClearNodes();
            AddProject(Project);
        }

        /// <summary>
        /// Removes a specific project file node
        /// </summary>
        /// <param name="file">The project file to remove</param>
        public void RemoveNode(OpenedFile file)
        {
            if (!IsProjectOpen()) return;
            foreach (TreeNode tn in TreeView.Nodes[0].Nodes)
            {
                if (!(tn.Tag is OpenedFile)) continue;
                if (tn.Tag == file)
                    tn.Remove();
            }
        }

        /// <summary>
        /// Renames an existing project file node to something else
        /// </summary>
        /// <param name="file">The file to rename</param>
        /// <param name="newName">The new name to give the file</param>
        public void RenameNode(OpenedFile file, string newName)
        {
            if (!IsProjectOpen()) return;
            foreach (TreeNode tn in TreeView.Nodes[0].Nodes)
            {
                if (!(tn.Tag is OpenedFile)) continue;
                if (tn.Tag == file)
                    tn.Text = newName;
            }
        }

        /// <summary>
        /// Renames the currently opened project's node to something new
        /// </summary>
        /// <param name="newName">The new name to assign to the project</param>
        public void RenameProjectNode(string newName)
        {
            if (IsProjectOpen())
            {
                TreeView.Nodes[0].Text = "Project '" + newName + "'";
            }
        }

        /// <summary>
        /// Shows the object browser
        /// </summary>
        public void ShowObjectBrowser()
        {
            _obj.Show(Manager);
        }

        /// <summary>
        /// Makes the object browser the currently active tab
        /// </summary>
        public void MakeObjectBrowserActive()
        {
            // HACK: FIX!

            //foreach ( TabbedDocument tp in manager.Documents )
            //{
            //    if ( IsSpecialTab( tp ) )
            //    {
            //        if ( ( ( SpecialTab )tp.Tag ).Type == TabType.ObjectBrowser )
            //            manager.ActiveDocument = tp;
            //    }
            //}
        }

        /// <summary>
        /// Closes the object browser
        /// </summary>
        public void CloseObjectBrowser()
        {
            if (IsObjectBrowserShown())
            {
                foreach (DockableWindow tp in Manager.Documents)
                {
                    if (!IsSpecialTab(tp)) continue;
                    if (((SpecialTab) tp.Tag).Type == TabType.ObjectBrowser)
                    {
                        tp.Close();
                    }
                }
            }
        }

        /// <summary>
        /// Shows the project info tab
        /// </summary>
        public void ShowProjectInfo()
        {
            if (!IsProjectOpen()) return;
            if (IsProjectInfoShown())
            {
                MakeProjectInfoActive();
                return;
            }

            // HACK!!! Fix for Project Properties.
            //DockableWindow tp = new DockableWindow();
            //tp.Text = "Project Properties";
            //SpecialTab st = new SpecialTab();
            //st.Type = TabType.ProjectInfo;
            //tp.Tag = st;
            //tp.BackColor = System.Drawing.SystemColors.Control;

            //ProjectProperties pp = new ProjectProperties(project);
            //pp.Dock = DockStyle.Fill;
            //tp.Controls.Add(pp);

            //tp.Show(manager);
            if (_projProperties == null)
            {
                _projProperties = new ProjectProperties(Project);
                _projProperties.TabText = "[ Project Properties ]";
                _projProperties.DockableAreas = DockAreas.Document;
                _projProperties.Show(Manager, DockState.Document);
            }
            else
            {
                _projProperties.Show(Manager, DockState.Document);
            }
        }

        /// <summary>
        /// Makes the project info tab the currently active tab
        /// </summary>
        public void MakeProjectInfoActive()
        {
            // HACK: FIX!

            //foreach (DockableWindow tp in manager.Documents)
            //{
            //    if ( IsSpecialTab( tp ) )
            //    {
            //        if ( ( ( SpecialTab )tp.Tag ).Type == TabType.ProjectInfo )
            //            manager.ActiveDocument = tp;
            //    }
            //}
        }

        /// <summary>
        /// Closes the project info tab
        /// </summary>
        public void CloseProjectInfo()
        {
            if (!IsProjectInfoShown()) return;
            foreach (DockableWindow tp in Manager.Documents)
            {
                // HACK!!! FIX!
                //if (IsSpecialTab(tp))
                //{
                //    if (((SpecialTab)tp.Tag).Type == TabType.ProjectInfo)
                //    {
                //        project = ((ProjectProperties)tp.Controls[0]).Project;
                //        project.Saved = false;
                //        tp.Close();
                //        ReloadNodes();
                //    }
                //}
            }
        }

        /// <summary>
        /// Displays the settings dialog
        /// </summary>
        public void ShowSettingsDialog()
        {
            // HACK!!! FIX!!!
            //SettingsDialog sd = new SettingsDialog(settings);
            //sd.ShowDialog();

            //settings = sd.Settings;
        }

        /// <summary>
        /// Adds a project to the environment, and loads all nodes
        /// </summary>
        /// <param name="proj"></param>
        public void AddProject(Project proj)
        {
            Project = proj;

            ClearNodes();

            var tn = new TreeNode
                         {
                             Text = "Project '" + proj.Name + "'",
                             ImageKey = "root",
                             Tag = proj,
                             ContextMenuStrip = ProjectStrip,
                             SelectedImageKey = "root"
                         };

            TreeView.Nodes.Add(tn);

            foreach (Folder f in proj.Folders)
            {
                var node = new TreeNode
                               {
                                   Text = f.Name,
                                   ContextMenuStrip = FolderStrip,
                                   ImageKey = "project_folder_closed",
                                   SelectedImageKey = "project_folder_closed",
                                   Tag = f
                               };
                f.Node = node;
                TreeView.Nodes[0].Nodes.Add(node);

                f.BuildTreeview(this, proj);
            }

            foreach (OpenedFile pf in proj.Files)
            {
                if (!File.Exists(proj.Path + @"\" + pf.Name))
                {
                    pf.Valid = false;
                    pf.Saved = true;
                    var node = new TreeNode
                                   {
                                       Text = pf.Name,
                                       ContextMenuStrip = CodeStrip,
                                       ImageKey = "file_lost",
                                       SelectedImageKey = "file_lost",
                                       Tag = pf
                                   };
                    pf.Node = node;
                    TreeView.Nodes[0].Nodes.Add(node);
                    continue;
                }
                pf.FullName = proj.Path + @"\" + pf.Name;
                pf.Saved = true;
                pf.Valid = true;

                var tn2 = new TreeNode
                              {
                                  Text = pf.Name,
                                  ContextMenuStrip = CodeStrip,
                                  ImageKey = "code",
                                  SelectedImageKey = "code",
                                  Tag = pf
                              };
                pf.Node = tn2;

                TreeView.Nodes[0].Nodes.Add(tn2);
            }

            TreeView.ExpandAll();

            // And setup all the tasks
            _output = new OutputWindow(this);
            _output.Show(Manager, DockState.DockBottomAutoHide); //, DockState.DockBottom);

            _taskList = new TaskWindow(this);
            _taskList.Show(Manager, DockState.DockBottomAutoHide); //, DockState.DockBottom);

            // Now load in the tasks
            _taskList.Reload();
        }

        /// <summary>
        /// Removes the currently open project from the envionment, use CloseProject() unless you need to force delete a project
        /// </summary>
        public void RemoveProject()
        {
            Project = null;

            Clear();
        }

        /// <summary>
        /// Checks if a project is currently open and creates a new project
        /// </summary>
        public void NewProject()
        {
            if (IsProjectOpen())
            {
                if (!IsProjectSaved())
                {
                    DialogResult res = Util.ShowQuestion(StringTable.ProjectNotSaved);

                    switch (res)
                    {
                        case DialogResult.Yes:
                            Project.Save();
                            break;
                        case DialogResult.No:
                            break;
                        case DialogResult.Cancel:
                            return;
                    }
                }
                DialogResult result = Util.ShowQuestion(StringTable.OpenProject);

                switch (result)
                {
                    case DialogResult.Yes:
                        RemoveProject();
                        NewProject();
                        break;
                    case DialogResult.No:
                        return;
                    case DialogResult.Cancel:
                        return;
                }
            }
            else
            {
                Project = Project.NewProject();
                if (Project == null)
                    return;

                SaveProject();

                AddProject(Project);
            }
        }

        /// <summary>
        /// Shows a dialog and opens an existing project
        /// </summary>
        public void OpenProject()
        {
            if (IsProjectOpen())
            {
                if (!IsProjectSaved())
                {
                    DialogResult res = Util.ShowQuestion(StringTable.ProjectNotSaved);

                    switch (res)
                    {
                        case DialogResult.Yes:
                            Project.Save();
                            break;
                        case DialogResult.No:
                            break;
                        case DialogResult.Cancel:
                            return;
                    }
                }
                DialogResult result = Util.ShowQuestion(StringTable.OpenProject);

                switch (result)
                {
                    case DialogResult.Yes:
                        RemoveProject();
                        OpenProject();
                        break;
                    case DialogResult.No:
                        return;
                    case DialogResult.Cancel:
                        return;
                }
            }
            else
            {
                var ofd = new OpenFileDialog
                              {
                                  Title = "Open project...",
                                  CheckFileExists = true,
                                  CheckPathExists = true,
                                  DereferenceLinks = true,
                                  Filter = "GLua Projects (*.glu)|*.glu",
                                  Multiselect = false
                              };

                if (ofd.ShowDialog() != DialogResult.OK)
                    return;

                Project = Project.LoadProject(ofd.FileName);
                if (Project == null)
                    return;
                Project.FullName = ofd.FileName;
                Project.Path = new FileInfo(ofd.FileName).Directory.FullName;
                Project.Saved = true;
                foreach (Folder folder in Project.Folders)
                {
                    folder.RebuildParents(folder, true);
                }
                AddProject(Project);
            }
        }

        /// <summary>
        /// Asks to save, closes the project, and calls RemoveProject()
        /// </summary>
        public void CloseProject()
        {
            if (!IsProjectOpen()) return;
            if (!IsProjectSaved())
            {
                DialogResult res = Util.ShowQuestion(StringTable.ProjectNotSaved);

                switch (res)
                {
                    case DialogResult.Yes:
                        Project.Save();
                        RemoveProject();
                        break;
                    case DialogResult.No:
                        RemoveProject();
                        break;
                    case DialogResult.Cancel:
                        return;
                }
            }
            else
            {
                RemoveProject();
            }
        }

        /// <summary>
        /// Saves the currently opened project
        /// </summary>
        public void SaveProject()
        {
            if (IsProjectOpen())
            {
                if (Project.FullName == "")
                {
                    var sfd = new SaveFileDialog
                                  {
                                      Title = "Save project...",
                                      AddExtension = true,
                                      DefaultExt = ".glu",
                                      Filter = "GLua Project (*.glu)|*.glu",
                                      OverwritePrompt = true,
                                      SupportMultiDottedExtensions = true,
                                      ValidateNames = true
                                  };

                    if (sfd.ShowDialog() != DialogResult.OK)
                        return;

                    Project.FullName = sfd.FileName;
                    Project.Path = new FileInfo(Project.FullName).Directory.FullName;
                    Project.Save();
                }
                else
                {
                    Project.Save();
                }
            }
        }

        /// <summary>
        /// Displays a dialog and renames the project
        /// </summary>
        public void RenameProject()
        {
            if (IsProjectOpen())
            {
                // HACK!!! FIX!!!
                //RenameResult rr = RenameDialog.ShowDialog(project.Name);

                //foreach (char chr in rr.RenameRes.ToCharArray())
                //{
                //    foreach (char invalidChar in Path.GetInvalidFileNameChars())
                //    {
                //        if (chr == invalidChar)
                //        {
                //            Util.ShowError(StringTable.InvalidProjectName);
                //            RenameProject();
                //            return;
                //        }
                //    }
                //}

                //switch (rr.DialogRes)
                //{
                //    case DialogResult.OK:
                //        bool pInfoShown = false;
                //        if (IsProjectInfoShown())
                //        {
                //            pInfoShown = true;
                //            CloseProjectInfo();
                //        }
                //        RenameProjectNode(rr.RenameRes);
                //        project.Name = rr.RenameRes;
                //        if (pInfoShown)
                //            ShowProjectInfo();
                //        project.Saved = false;
                //        break;
                //    case DialogResult.Cancel:
                //        return;
                //}
            }
        }

        /// <summary>
        /// Shows a dialog and opens a file which will not be part of the project
        /// </summary>
        public void OpenFile()
        {
            var ofd = new OpenFileDialog
                          {
                              Title = "Open file...",
                              CheckFileExists = true,
                              CheckPathExists = true,
                              DereferenceLinks = true,
                              Filter = "Lua Files (*.lua)|*.lua|All Files (*.*)|*.*",
                              Multiselect = true
                          };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            foreach (string file in ofd.FileNames)
            {
                var of = new OpenedFile();
                of.FullName = file;
                var fi = new FileInfo(file);
                of.Name = fi.Name;
                of.Saved = true;

                ShowOpenedFile(of);
            }
        }

        /// <summary>
        /// Opens a file directly from a filename
        /// </summary>
        /// <param name="fname">The filename to open</param>
        public void OpenFile(string fname)
        {
            var of = new OpenedFile {FullName = fname};
            var fi = new FileInfo(fname);
            of.Name = fi.Name;
            of.Saved = true;

            ShowOpenedFile(of);
        }

        /// <summary>
        /// Creates and shows a tab for an opened file which is sperate from the project
        /// </summary>
        /// <param name="file">The file to open</param>
        public void ShowOpenedFile(OpenedFile file)
        {
            _fileLoading = true;

            var ct = new CodeTab(file) {TabText = file.Name};
            ct.Show(Manager);

            if (file.Editor == null)
                file.Editor = ct.Editor;

            _fileLoading = false;
        }

        /// <summary>
        /// Adds a previously created project file to the project
        /// </summary>
        /// <param name="file">The file to add</param>
        public void AddProjectFile(OpenedFile file)
        {
            if (file.Folder == null)
            {
                // Add to Project
                Project.Files.Add(file);
                var tn = new TreeNode
                             {
                                 Text = file.Name,
                                 ImageKey = "code",
                                 ContextMenuStrip = CodeStrip,
                                 SelectedImageKey = "code",
                                 Tag = file
                             };
                file.Node = tn;
                TreeView.Nodes[0].Nodes.Add(tn);
                TreeView.ExpandAll();
            }
            else
            {
                // Add to the folder
                file.Folder.Files.Add(file);
                var tn = new TreeNode
                             {
                                 Text = file.Name,
                                 ImageKey = "code",
                                 ContextMenuStrip = CodeStrip,
                                 SelectedImageKey = "code",
                                 Tag = file
                             };
                file.Node = tn;
                file.Folder.Node.Nodes.Add(tn);
                TreeView.ExpandAll();
            }
        }

        public void AddProjectFolder(Folder folder)
        {
            var tn = new TreeNode
                         {
                             Text = folder.Name,
                             ImageKey = "project_folder_closed",
                             ContextMenuStrip = FolderStrip,
                             SelectedImageKey = "project_folder_closed",
                             Tag = folder
                         };
            folder.Node = tn;

            if (folder.Parent == null)
                TreeView.Nodes[0].Nodes.Add(tn);
            else
                folder.Parent.Node.Nodes.Add(tn);

            TreeView.ExpandAll();
        }

        public void NewFolder()
        {
            var nfd = new NewFolderDialog();
            if (nfd.ShowDialog() != DialogResult.OK) return;
            if (_explorer.tvFiles.SelectedNode != null &&
                _explorer.tvFiles.SelectedNode.Tag.GetType().Name == "Project")
            {
                bool found = false;
                foreach (Folder f in Project.Folders)
                {
                    if (f.Name != nfd.txtFolderName.Text) continue;
                    Util.ShowError(" Folder Already Exists: " + nfd.txtFolderName.Text + " ");
                    found = true;
                    break;
                }
                if (!found)
                {
                    // Try and create the folder on the filesystem
                    try
                    {
                        Directory.CreateDirectory(Project.Path + @"\" + nfd.txtFolderName.Text);
                    }
                    catch
                    {
                        // XXX: Handle this
                        Util.ShowError("Unable to create folder " + Project.Path + @"\" + nfd.txtFolderName.Text);
                    }

                    var folder = new Folder
                                     {
                                         Name = nfd.txtFolderName.Text,
                                         Project = Project,
                                         Parent = null,
                                         WorkSpace = this
                                     };
                    Project.Folders.Add(folder);
                    AddProjectFolder(folder);
                }
            }
            else if (_explorer.tvFiles.SelectedNode != null &&
                     _explorer.tvFiles.SelectedNode.Tag.GetType().Name == "Folder")
            {
                bool found = false;
                foreach (Folder f in ((Folder) _explorer.tvFiles.SelectedNode.Tag).Folders)
                {
                    if (f.Name != nfd.txtFolderName.Text) continue;
                    Util.ShowError(" Folder Already Exists: " + nfd.txtFolderName.Text + " ");
                    found = true;
                    break;
                }
                if (!found)
                {
                    StringBuilder filepath = new StringBuilder(Project.Path);

                    // Recurse through the folders (parents) until the parent is null, then work our way back through
                    var ff = ((Folder) _explorer.tvFiles.SelectedNode.Tag);

                    var fldrList = new List<Folder>();

                    while (ff != null)
                    {
                        fldrList.Add(ff);
                        ff = ff.Parent;
                    }

                    for (int i = fldrList.Count - 1; i >= 0; i--)
                    {
                        if (ff == (_explorer.tvFiles.SelectedNode.Tag))
                            break;
                        ff = fldrList[i];
                        filepath.Append(@"\" + ff.Name);
                    }

                    filepath.Append(@"\");

                    // Try and create the folder on the filesystem
                    try
                    {
                        Directory.CreateDirectory(filepath + nfd.txtFolderName.Text);
                    }
                    catch
                    {
                    }

                    var folder = new Folder
                                     {
                                         Name = nfd.txtFolderName.Text,
                                         Project = Project,
                                         Parent = ((Folder) _explorer.tvFiles.SelectedNode.Tag),
                                         WorkSpace = this
                                     };
                    // WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF WTF
                    //project.Folders.Add( folder );
                    // This should fix our little issue..
                    ((Folder) _explorer.tvFiles.SelectedNode.Tag).Folders.Add(folder);
                    AddProjectFolder(folder);
                }
            }
        }

        /// <summary>
        /// Removes a previously created project file from the project
        /// </summary>
        /// <param name="file">The file to remove</param>
        public void RemoveProjectFile(OpenedFile file)
        {
            if (IsProjectOpen())
            {
                // HACK!!! FIX!!!
                //DialogResult res = FileRemoveDialog.ShowDialog(file.Name);

                //switch (res)
                //{
                //    case DialogResult.Yes:
                //        File.Delete(file.FullName);
                //        CloseCodeTab(file);
                //        RemoveNode(file);
                //        project.Files.Remove(file);
                //        project.Saved = false;
                //        break;
                //    case DialogResult.No:
                //        CloseCodeTab(file);
                //        RemoveNode(file);
                //        project.Files.Remove(file);
                //        project.Saved = false;
                //        break;
                //    case DialogResult.Cancel:
                //        return;
                //}
            }
        }

        /// <summary>
        /// Displays a dialog and renames a project file
        /// </summary>
        /// <param name="file">The file to rename</param>
        public void RenameProjectFile(OpenedFile file)
        {
            if (IsProjectOpen())
            {
                // HACK!!! FIX!!!
                //RenameResult rr = RenameDialog.ShowDialog(file.Name);

                //foreach (char chr in rr.RenameRes.ToCharArray())
                //{
                //    foreach (char invalidChar in Path.GetInvalidFileNameChars())
                //    {
                //        if (chr == invalidChar)
                //        {
                //            // invalid character, call RenameProjectFile() again
                //            Util.ShowError(StringTable.InvalidFileName);
                //            RenameProjectFile(file);
                //            return;
                //        }
                //    }
                //}

                //switch (rr.DialogRes)
                //{
                //    case DialogResult.OK:
                //        if (file.Name == rr.RenameRes)
                //            return;

                //        File.Copy(file.FullName, file.FullName.Replace(file.Name, rr.RenameRes));
                //        File.Delete(file.FullName);
                //        RenameNode(file, rr.RenameRes);
                //        RenameCodeTab(file, rr.RenameRes);
                //        file.FullName = file.FullName.Replace(file.Name, rr.RenameRes);
                //        file.Name = rr.RenameRes;
                //        file.Saved = false;
                //        project.Saved = false;
                //        break;
                //    case DialogResult.Cancel:
                //        return;
                //}
            }
        }

        /// <summary>
        /// Makes a previously opened project file active
        /// </summary>
        /// <param name="file">The file to activate</param>
        public void MakeProjectFileActive(OpenedFile file)
        {
            // HACK: FIX!
            //foreach ( TabbedDocument tp in manager.Documents )
            //{
            //    if ( !IsSpecialTab( tp ) )
            //    {
            //        if ( tp.Tag == file )
            //            manager.ActiveDocument = tp;
            //    }
            //}
        }

        /// <summary>
        /// Creates a tab and shows a project file, if the tab is already created it is made active
        /// </summary>
        /// <param name="file">The file to show</param>
        public void ShowProjectFile(OpenedFile file)
        {
            if (IsProjectFileShown(file))
            {
                MakeProjectFileActive(file);
                return;
            }

            if (File.Exists(file.FullName))
            {
                file.Valid = true;
                file.Node.ImageKey = "code";
                file.Node.SelectedImageKey = "code";
            }
            else
            {
                Util.ShowError(StringTable.ProjectFileLost.Replace("%FILE%", file.Name));
                return;
            }

            if (_fileLoading) return;
            _fileLoading = true;

            var ct = new CodeTab(file) {TabText = file.Name};
            ct.Show(Manager);

            file.Editor = ct.Editor;

            _fileLoading = false;
        }

        /// <summary>
        /// Saves a project file
        /// </summary>
        /// <param name="file">The project file to save</param>
        public void SaveProjectFile(OpenedFile file)
        {
            file.Save();
        }

        /// <summary>
        /// Shows a special tab
        /// </summary>
        /// <param name="specialTab">The special tab to open</param>
        public void ShowSpecialTab(SpecialTab specialTab)
        {
            if (IsSpecialTabShown(specialTab))
                return;

            switch (specialTab.Type)
            {
                case TabType.ObjectBrowser:
                    ShowObjectBrowser();
                    break;
                case TabType.ProjectInfo:
                    ShowProjectInfo();
                    break;
            }
        }

        /// <summary>
        /// Checks for special tabs and files, asks to save, and then closes the currently active tab
        /// </summary>
        public void CloseActiveTab()
        {
            // BIG HACK!!!!!

            //if (IsSpecialTab((DockableWindow)manager.ActiveDocument))
            //{
            //    if ( ( ( SpecialTab )manager.ActiveDocument.DockHandler.Tag ).Type == TabType.ObjectBrowser )
            //    {
            //        CloseObjectBrowser();
            //        return;
            //    }
            //    if ( ( ( SpecialTab )manager.ActiveDocument ).Type == TabType.ProjectInfo )
            //    {
            //        CloseProjectInfo();
            //        return;
            //    }
            //}
            //else
            //{
            //    if ( manager.ActiveDocument.DockHandler.Tag is ProjectFile )
            //    {
            //        ProjectFile pf = ( ProjectFile )manager.ActiveDocument.DockHandler.Tag;

            //        if ( !pf.Saved )
            //        {
            //            DialogResult res = Util.ShowQuestion( StringTable.FileNotSaved.Replace( "%FILE%", pf.Name ) );

            //            switch ( res )
            //            {
            //                case DialogResult.Yes:
            //                    pf.Save();
            //                    manager.ActiveDocument.Close();
            //                    break;
            //                case DialogResult.No:
            //                    manager.ActiveDocument.Close();
            //                    break;
            //                case DialogResult.Cancel:
            //                    return;

            //            }
            //        }
            //        else
            //        {
            //            manager.ActiveDocument.Close();
            //        }
            //    }
            //    else if ( manager.ActiveDocument.Tag is OpenedFile )
            //    {
            //        OpenedFile of = ( OpenedFile )manager.ActiveDocument.Tag;

            //        if ( !of.Saved )
            //        {
            //            DialogResult res = Util.ShowQuestion( StringTable.FileNotSaved.Replace( "%FILE%", of.Name ) );

            //            switch ( res )
            //            {
            //                case DialogResult.Yes:
            //                    of.Save();
            //                    manager.ActiveDocument.Close();
            //                    break;
            //                case DialogResult.No:
            //                    manager.ActiveDocument.Close();
            //                    break;
            //                case DialogResult.Cancel:
            //                    return;

            //            }
            //        }
            //        else
            //        {
            //            manager.ActiveDocument.Close();
            //        }
            //    }
            //}
        }

        /// <summary>
        /// Closes a code tab without saving
        /// </summary>
        /// <param name="file"></param>
        public void CloseCodeTab(OpenedFile file)
        {
            foreach (DockableWindow td in Manager.Documents)
            {
                if (IsSpecialTab(td)) continue;
                if (td.Tag == file)
                    td.Close();
            }
        }

        /// <summary>
        /// Renames a a code tab of a project file
        /// </summary>
        /// <param name="file">The project file to rename</param>
        /// <param name="newName">The new name to give the code tab</param>
        public void RenameCodeTab(OpenedFile file, string newName)
        {
            foreach (DockableWindow td in Manager.Documents)
            {
                if (IsSpecialTab(td)) continue;
                if (td.Tag == file)
                    td.Text = newName;
            }
        }

        /// <summary>
        /// Asks to save and closes all tabs except the active tab
        /// </summary>
        public void CloseAllButActiveTab()
        {
            foreach (DockableWindow tp in Manager.Documents)
            {
                if (tp == Manager.ActiveDocument)
                    continue;

                if (IsSpecialTab(tp))
                {
                    if (((SpecialTab) tp.Tag).Type == TabType.ObjectBrowser)
                        CloseObjectBrowser();
                    if (((SpecialTab) tp.Tag).Type == TabType.ProjectInfo)
                        CloseProjectInfo();
                }
                else
                {
                    if (tp.Tag is OpenedFile)
                    {
                        var pf = (OpenedFile) tp.Tag;

                        if (!pf.Saved)
                        {
                            DialogResult res = Util.ShowQuestion(StringTable.FileNotSaved.Replace("%FILE%", pf.Name));

                            switch (res)
                            {
                                case DialogResult.Yes:
                                    pf.Save();
                                    tp.Close();
                                    break;
                                case DialogResult.No:
                                    tp.Close();
                                    break;
                                case DialogResult.Cancel:
                                    return;
                            }
                        }
                        else
                        {
                            tp.Close();
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Attempts to save the currently active tab
        /// </summary>
        public void SaveActiveTab()
        {
            if (Manager.ActiveDocument == null)
                return;
            if (Manager.ActiveDocument.GetType().Name != "CodeTab") return;
            Debug.WriteLine("Active Tabs Name: " + ((CodeTab) Manager.ActiveDocument).Tag.GetType().Name);
            if (((CodeTab) Manager.ActiveDocument).Tag.GetType().Name == "OpenedFile")
                ((OpenedFile) ((CodeTab) Manager.ActiveDocument).Tag).Save();
        }

        /// <summary>
        /// Shows a save dialog and generates an info file
        /// </summary>
        public void GenerateInfoFile()
        {
            if (!IsProjectOpen()) return;
            var sfd = new SaveFileDialog
                          {
                              AddExtension = true,
                              DefaultExt = ".txt",
                              FileName = "info.txt",
                              Filter = "Info Files (info.txt)|info.txt",
                              InitialDirectory = Project.Path,
                              Title = "Save Info File..."
                          };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            InfoGenerator.GenerateInfo(sfd.FileName, Project);
        }

        /// <summary>
        /// Checks for any active code files and projects, asks to save, closes and removes tabs, and saves settings
        /// </summary>
        /// <returns>True if the exit completed successfully, otherwise false if the user decided to cancel</returns>
        public bool Exit()
        {
            if (IsProjectOpen())
            {
                if (!IsProjectSaved())
                {
                    DialogResult res = Util.ShowQuestion(StringTable.ProjectNotSaved);

                    switch (res)
                    {
                        case DialogResult.Yes:
                            SaveProject();
                            RemoveProject();
                            break;
                        case DialogResult.No:
                            RemoveProject();
                            break;
                        case DialogResult.Cancel:
                            return false;
                    }
                }
                RemoveProject();
            }

            if (IsCodeTabOpen())
            {
                foreach (DockableWindow td in Manager.Documents)
                {
                    if (IsSpecialTab(td))
                        continue;
                    if (!(td.Tag is OpenedFile)) continue;
                    var of = (OpenedFile) td.Tag;

                    if (of.Saved) continue;
                    DialogResult res = Util.ShowQuestion(StringTable.FileNotSaved.Replace("%FILE%", of.Name));

                    switch (res)
                    {
                        case DialogResult.Yes:
                            of.Save();
                            td.Close();
                            break;
                        case DialogResult.No:
                            td.Close();
                            break;
                        case DialogResult.Cancel:
                            return false;
                    }
                }
            }
            // HACK!!! FIX!!!
            //Settings.Save(Application.StartupPath + "\\data\\settings.xml", settings);

            return true;
        }

        /// <summary>
        /// Shows the add new item dialog and adds a new item
        /// </summary>
        public void AddNewItem()
        {
            if (!IsProjectOpen()) return;
            var nfd = new NewFileDialog();

            if (nfd.ShowDialog() != DialogResult.OK)
                return;

            var pf = new OpenedFile();
            string filePath;

            if (_explorer.tvFiles.SelectedNode == null) // Just do the normal adding to project...
            {
                filePath = Project.Path;
                pf.Folder = null;
            }
            else switch (_explorer.tvFiles.SelectedNode.Tag.GetType().Name)
            {
                case "Project":
                    filePath = Project.Path;
                    pf.Folder = null;
                    break;
                case "Folder":
                    filePath = ((Folder) _explorer.tvFiles.SelectedNode.Tag).FullName();
                    pf.Folder = ((Folder) _explorer.tvFiles.SelectedNode.Tag);
                    break;
                case "OpenedFile":
                    if (((OpenedFile) _explorer.tvFiles.SelectedNode.Tag).Folder == null) // Project File
                    {
                        filePath = Project.Path;
                        pf.Folder = null;
                    }
                    else // File in Folder, so folders parent is cool :D
                    {
                        filePath = ((OpenedFile) _explorer.tvFiles.SelectedNode.Tag).Folder.FullName();
                        pf.Folder = ((OpenedFile) _explorer.tvFiles.SelectedNode.Tag).Folder;
                    }
                    break;
                default:
                    filePath = Project.Path;
                    pf.Folder = null;
                    break;
            }

            if (File.Exists(filePath + @"\" + nfd.FileName))
            {
                Util.ShowError(StringTable.FileAlreadyExists);
                AddNewItem();
                return;
            }
            File.Create(filePath + @"\" + nfd.FileName).Close();
            File.WriteAllText(filePath + @"\" + nfd.FileName, PreprocessCode(nfd.SelectedTemplate.Code));

            pf.Name = nfd.FileName;
            pf.Saved = false;
            pf.FullName = filePath + @"\" + pf.Name;

            Project.Saved = false;

            AddProjectFile(pf);

            SaveProject();

            OpenFile(filePath + @"\" + nfd.FileName);
        }

        // TODO: Do something
        private string PreprocessCode(string code)
        {
            Regex r = new Regex(@"\$\{(\w+?)\}", RegexOptions.Compiled);
            return r.Replace(code, m => (m.Groups[1].Value));
        }

        /// <summary>
        /// Shows the open file dialog and adds an existing item
        /// </summary>
        public void AddExistingItem()
        {
            if (!IsProjectOpen()) return;
            var ofd = new OpenFileDialog
                          {
                              Filter = "Lua Files (*.lua)|*.lua",
                              Multiselect = true,
                              Title = "Add Existing Item..."
                          };

            if (ofd.ShowDialog() != DialogResult.OK)
                return;

            foreach (string name in ofd.FileNames)
            {
                var fi = new FileInfo(name);

                // Were we clicked on a node in the treeview? If so, was it a folder or a file in a 
                // Folder? If so, add it to that folder, otherwise just add it to the project.
                object selNode = _explorer.tvFiles.SelectedNode.Tag;
                OpenedFile selFile;
                Folder selFolder;
                OpenedFile pf;
                switch (selNode.GetType().Name)
                {
                    case "OpenedFile":
                        selFile = ((OpenedFile) selNode);
                        if (selFile.Folder == null)
                        {
                            // Add to Project
                            pf = new OpenedFile {Name = fi.Name, Saved = true};
                            pf.FullName = Project.Path + @"\" + pf.Name;
                        }
                        else
                        {
                            // Add to the selected files containing folder
                            pf = new OpenedFile
                                     {
                                         Name = fi.Name,
                                         Saved = true,
                                         Folder = selFile.Folder,
                                         FullName = selFile.Folder.FullName() + @"\" + fi.Name
                                     };
                        }
                        break;
                    case "Folder":
                        selFolder = ((Folder) selNode);
                        pf = new OpenedFile
                                 {
                                     Name = fi.Name,
                                     Saved = true,
                                     Folder = selFolder,
                                     FullName = selFolder.FullName() + @"\" + fi.Name
                                 };
                        break;
                    default:
                        pf = new OpenedFile {Name = fi.Name, Saved = true};
                        pf.FullName = Project.Path + @"\" + pf.Name;
                        break;
                }

                if (DoesProjectFileExist(pf.FullName))
                {
                    Util.ShowError(StringTable.FileAlreadyAdded);
                    continue;
                }
                AddProjectFile(pf);
            }

            Project.Saved = false;

            SaveProject();
        }

        /// <summary>
        /// Deletes a folder from the Project, and possibly from the filesystem also.
        /// </summary>
        /// <param name="folder">The folder to Delete</param>
        public void DeleteFolder(Folder folder)
        {
            DialogResult msgRes =
                Util.ShowQuestion(
                    "Do you want to remove the physical folder from the hard drive?\nYes: Remove both Project Reference and Physical Folder\nNo: Remove Project Reference and leave Physical Folder\nCancel: Cancel File Operation");

            if (msgRes == DialogResult.Yes)
            {
                // Remove the TreeNode
                folder.Node.Remove();
                // Remove physical file
                Directory.Delete(folder.FullName(), true);
                // Remove the project reference
                if (folder.Parent == null)
                    // Remove from Project
                    Project.Folders.Remove(folder);
                else
                    // Remove from the parent folder
                    folder.Parent.Folders.Remove(folder);
            }
            else if (msgRes == DialogResult.No)
            {
                folder.Node.Remove();
                // Remove just the project reference
                if (folder.Parent == null)
                    // Remove from Project
                    Project.Folders.Remove(folder);
                else
                    // Remove from the parent folder
                    folder.Parent.Folders.Remove(folder);
            }
        }

        public void DeleteFile(OpenedFile file)
        {
            DialogResult msgRes =
                Util.ShowQuestion(
                    "Do you want to remove the physical File from the hard drive?\nYes: Remove both Project Reference and Physical File\nNo: Remove Project Reference and leave Physical File\nCancel: Cancel File Operation");

            if (msgRes == DialogResult.Yes)
            {
                // Remove the TreeNode
                file.Node.Remove();
                if (file.FullName != null)
                    // Remove physical file
                    File.Delete(file.FullName);
                // Remove the project reference
                if (file.Folder == null)
                    // Remove from Project
                    Project.Files.Remove(file);
                else
                    // Remove from the parent folder
                    file.Folder.Files.Remove(file);
            }
            else if (msgRes == DialogResult.No)
            {
                file.Node.Remove();
                // Remove the project reference
                if (file.Folder == null)
                    // Remove from Project
                    Project.Files.Remove(file);
                else
                    // Remove from the parent folder
                    file.Folder.Files.Remove(file);
            }
        }

        ///// <summary>
        ///// Creates an lua specific syntax editor control
        ///// </summary>
        ///// <returns>A customized syntax edit control used for editing lua files</returns>
        //public CodeEditorControl CreateTextEditor()
        //{
        //    CodeEditorControl se = new CodeEditorControl();

        //    //se.Lexer = new Lexer();
        //    //se.Lexer.LoadScheme( Application.StartupPath + "\\data\\lua_scheme.xml" );

        //    //se.Dock = DockStyle.Fill;

        //    //se.Gutter.Options = GutterOptions.PaintLineModificators | GutterOptions.PaintLineNumbers;
        //    //se.Source.HighlightUrls = true;
        //    //se.Source.UndoOptions = UndoOptions.AllowUndo | UndoOptions.UndoAfterSave;
        //    //se.TextChanged += new EventHandler( se_TextChanged );
        //    //se.NeedCodeCompletion += new CodeCompletionEvent( se_NeedCodeCompletion );
        //    //se.MouseClick += new MouseEventHandler( se_MouseClick );
        //    //se.Braces.BracesOptions = BracesOptions.Highlight | BracesOptions.HighlightBounds;
        //    //se.Braces.ClosingBraces = new char[] { ')', ']', '}' };
        //    //se.Braces.OpenBraces = new char[] { '(', '[', '{' };
        //    //se.CodeCompletionChars = new char[] { '.', ':', '(', ',' };
        //    //se.DisplayLines.AllowOutlining = true;
        //    //se.DisplayLines.OutlineOptions = OutlineOptions.DrawButtons | OutlineOptions.DrawLines | OutlineOptions.ShowHints;
        //    //se.Gutter.LineNumbersAlignment = StringAlignment.Far;
        //    //se.Gutter.LineNumbersStart = 1;
        //    //se.Gutter.LineNumbersLeftIndent = 20;
        //    //se.IndentOptions = IndentOptions.AutoIndent;
        //    //se.Scrolling.Options = ScrollingOptions.SmoothScroll | ScrollingOptions.ShowScrollHint;

        //    //// file menu shortcuts
        //    //se.KeyList.Add( Keys.Control | Keys.Shift | Keys.S, new KeyEvent( se_SaveProject ) );
        //    //se.KeyList.Add( Keys.Control | Keys.S, new KeyEvent( se_SaveActive ) );
        //    //se.KeyList.Add( Keys.Control | Keys.Shift | Keys.N, new KeyEvent( se_NewProject ) );
        //    //se.KeyList.Add( Keys.Control | Keys.Shift | Keys.O, new KeyEvent( se_OpenProject ) );
        //    //se.KeyList.Add( Keys.Control | Keys.O, new KeyEvent( se_OpenFile ) );
        //    //se.KeyList.Add( Keys.Alt | Keys.F4, new KeyEvent( se_Exit ) );

        //    //// view menu shortcuts
        //    //se.KeyList.Add( Keys.Control | Keys.Alt | Keys.E, new KeyEvent( se_ShowProjectExplorer ) );
        //    //se.KeyList.Add( Keys.Control | Keys.Alt | Keys.B, new KeyEvent( se_ShowObjectBrowser ) );
        //    //se.KeyList.Add( Keys.Control | Keys.Alt | Keys.T, new KeyEvent( se_ShowTaskList ) );
        //    //se.KeyList.Add( Keys.Control | Keys.Alt | Keys.O, new KeyEvent( se_ShowOutput ) );

        //    //// project menu shortcuts
        //    //se.KeyList.Add( Keys.Control | Keys.Shift | Keys.A, new KeyEvent( se_AddNewItem ) );
        //    //se.KeyList.Add( Keys.Alt | Keys.Shift | Keys.A, new KeyEvent( se_AddExistingItem ) );

        //    //// help menu shortcuts
        //    //se.KeyList.Add( Keys.F1, new KeyEvent( se_GmodWiki ) );
        //    //se.KeyList.Add( Keys.Alt | Keys.F1, new KeyEvent( se_FPLuaScripting ) );
        //    //se.KeyList.Add( Keys.Control | Keys.F1, new KeyEvent( se_GLuaHome ) );

        //    //// code edit shortcuts
        //    //se.KeyList.Add( Keys.Control | Keys.J, new KeyEvent( se_WordCompletion ) );


        //    //se.DefaultMenu.MenuItems.Clear();
        //    //se.Refresh();
        //    //se.Update();
        //    se.BorderStyle = ControlBorderStyle.SunkenThin;
        //    return se;
        //}
        /// <summary>
        /// Checks if the environment can undo
        /// </summary>
        /// <returns>True if undo is allowed, otherwise false</returns>
        public bool CanUndo()
        {
            if (!IsTabOpen())
            {
                return false;
            }
            if (IsActiveTabSpecial())
                return false;
            var edit = (CodeEditorControl) Manager.ActiveDocument.DockHandler.DockPanel.Controls[0];
            return edit.CanUndo;
        }

        /// <summary>
        /// Checks if the environment can redo
        /// </summary>
        /// <returns>True if redo is allowed, otherwise false</returns>
        public bool CanRedo()
        {
            if (!IsTabOpen())
            {
                return false;
            }
            if (IsActiveTabSpecial())
                return false;
            var edit = (CodeEditorControl) Manager.ActiveDocument.DockHandler.DockPanel.Controls[0];
            return edit.CanRedo;
        }

        /// <summary>
        /// Checks if the environment can cut
        /// </summary>
        /// <returns>True if cut is allowed, otherwise false</returns>
        public bool CanCut()
        {
            if (IsTabOpen())
            {
                if (IsActiveTabSpecial())
                    return false;
                var edit = (CodeEditorControl) Manager.ActiveDocument.DockHandler.DockPanel.Controls[0];
                return edit.CanCopy;
            }
            return false;
        }

        /// <summary>
        /// Checks if the environment can copy
        /// </summary>
        /// <returns>True if copy is allowed, otherwise false</returns>
        public bool CanCopy()
        {
            if (!IsTabOpen())
            {
                return false;
            }
            if (IsActiveTabSpecial())
                return false;
            var edit = (CodeEditorControl) Manager.ActiveDocument.DockHandler.DockPanel.Controls[0];
            return edit.CanCopy;
        }

        /// <summary>
        /// Checks if the environment can paste
        /// </summary>
        /// <returns>True if paste is allowed, otherwise false</returns>
        public bool CanPaste()
        {
            if (!IsTabOpen())
            {
                return false;
            }
            if (IsActiveTabSpecial())
                return false;
            var edit = (CodeEditorControl) Manager.ActiveDocument.DockHandler.DockPanel.Controls[0];
            return edit.CanPaste;
        }

        /// <summary>
        /// Checks if the environment can delete
        /// </summary>
        /// <returns>True if delete is allowed, otherwise false</returns>
        public bool CanDelete()
        {
            return IsCodeTabOpen();
        }

        /// <summary>
        /// Undo's the last change in the editor
        /// </summary>
        public void Undo()
        {
            if (IsActiveTabSpecial())
                return;
            if (IsCodeTab(((DockableWindow) Manager.ActiveDocument)))
            {
                CodeEditorControl edit = ((CodeTab) Manager.ActiveDocument).Editor;
                edit.Undo();
            }
        }

        /// <summary>
        /// Redo's the last change in the editor
        /// </summary>
        public void Redo()
        {
            if (IsActiveTabSpecial())
                return;
            if (IsCodeTab((DockableWindow) Manager.ActiveDocument))
            {
                CodeEditorControl edit = ((CodeTab) Manager.ActiveDocument).Editor;
                edit.Redo();
            }
        }

        /// <summary>
        /// Cuts text from the editor
        /// </summary>
        public void Cut()
        {
            if (IsActiveTabSpecial())
                return;
            if (IsCodeTab((DockableWindow) Manager.ActiveDocument))
            {
                CodeEditorControl edit = ((CodeTab) Manager.ActiveDocument).Editor;
                edit.Cut();
            }
        }

        /// <summary>
        /// Copies text from the editor
        /// </summary>
        public void Copy()
        {
            if (IsActiveTabSpecial())
                return;
            if (IsCodeTab((DockableWindow) Manager.ActiveDocument))
            {
                CodeEditorControl edit = ((CodeTab) Manager.ActiveDocument).Editor;
                edit.Copy();
            }
        }

        /// <summary>
        /// Pastes text to the editor
        /// </summary>
        public void Paste()
        {
            if (IsActiveTabSpecial())
                return;
            if (IsCodeTab((DockableWindow) Manager.ActiveDocument))
            {
                CodeEditorControl edit = ((CodeTab) Manager.ActiveDocument).Editor;
                edit.Paste();
            }
        }

        /// <summary>
        /// Deletes the currently selected text in the editor
        /// </summary>
        public void Delete()
        {
            if (IsActiveTabSpecial())
                return;
            if (IsCodeTab((DockableWindow) Manager.ActiveDocument))
            {
                CodeEditorControl edit = ((CodeTab) Manager.ActiveDocument).Editor;
                edit.Delete();
            }
        }

        /// <summary>
        /// Selects all text in the editor
        /// </summary>
        public void SelectAll()
        {
            if (IsActiveTabSpecial())
                return;
            if (IsCodeTab((DockableWindow) Manager.ActiveDocument))
            {
                CodeEditorControl edit = ((CodeTab) Manager.ActiveDocument).Editor;
                edit.SelectAll();
            }
        }

        /// <summary>
        /// Displays a find dialog
        /// </summary>
        public void FindDialog()
        {
        }

        /// <summary>
        /// Displays a find dialog with pre-entered text in the textbox
        /// </summary>
        /// <param name="input">The text to have displayed</param>
        // Apparently the editor control doesn't support this
        // A quit edit in the SE library can change this
        public void FindDialog(string input)
        {
        }

        /// <summary>
        /// Displays the replace dialog
        /// </summary>
        public void ReplaceDialog()
        {
            //// TODO: REPLACE DIALOG
        }


        public void Find()
        {
            FindDialog();
        }

        public void Find(String findStr)
        {
        }

        public void Replace()
        {
            ReplaceDialog();
        }

        public void GenerateInfo()
        {
            if (!IsProjectOpen()) return;
            var sfd = new SaveFileDialog
                          {
                              AddExtension = true,
                              DefaultExt = ".txt",
                              FileName = "info.txt",
                              Filter = "Info Files (info.txt)|info.txt",
                              InitialDirectory = Project.Path,
                              Title = "Save Info File..."
                          };

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            InfoGenerator.GenerateInfo(sfd.FileName, Project);
        }

        // Blame P90 for all bugs related to this.
        public void ShowAbout()
        {
            //new AboutBox().Show();
        }

        public void ShowSettings()
        {
        }

        public void ShowProjectExplorer()
        {
            _explorer.Show();
        }

        public void HideProjectExplorer()
        {
            _explorer.Hide();
        }

        public void ShowOutputWindow()
        {
            if (_output == null)
                return;
            _output.Show();
        }

        public void ShowTaskList()
        {
            if (_taskList == null)
                return;
            _taskList.Show();
        }

        public void ReportBug()
        {
            _bug.Show(Manager);
        }

        private void TreeViewNodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (TreeView.SelectedNode == null)
                return;

            //if (treeView.SelectedNode.Tag.GetType().Name == "ProjectFile")
            //{
            //    MessageBox.Show(((ProjectFile)treeView.SelectedNode.Tag).FullName);
            //}
        }

        #region "Tasks"

        public void AddTask()
        {
            var taskEdit = new frmAddEditTask();
            if (taskEdit.ShowDialog() != DialogResult.OK) return;
            var task = new Task();
            if (taskEdit.cmbPriority.SelectedIndex == -1)
                taskEdit.cmbPriority.SelectedIndex = 2;

            task.Priority = (Task.TaskPriority) taskEdit.cmbPriority.SelectedIndex;
            task.Text = taskEdit.txtTaskName.Text;
            Project.Tasks.Add(task);
            _taskList.Reload();
        }

        public void EditTask(ListViewItem task)
        {
            Task currTask = null;

            foreach (Task taskk in Project.Tasks)
            {
                if (taskk.lvm == task)
                    currTask = taskk;
            }

            if (currTask == null)
                return;

            var taskEdit = new frmAddEditTask
                               {
                                   txtTaskName = {Text = currTask.Text},
                                   cmbPriority = {SelectedIndex = (int) currTask.Priority}
                               };

            if (taskEdit.ShowDialog() == DialogResult.OK)
            {
                currTask.Text = taskEdit.txtTaskName.Text;
                if (taskEdit.cmbPriority.SelectedIndex == -1)
                    taskEdit.cmbPriority.SelectedIndex = 2;

                currTask.Priority = (Task.TaskPriority) taskEdit.cmbPriority.SelectedIndex;
                _taskList.Reload();
            }
        }

        public void DeleteTask(ListView.SelectedListViewItemCollection tasks)
        {
            if (Util.ShowQuestion("Do you want to delete these tasks?") == DialogResult.Yes)
                foreach (ListViewItem ttask in tasks)
                {
                    foreach (Task task in Project.Tasks)
                    {
                        if (task.lvm == ttask)
                        {
                            Project.Tasks.Remove(task);
                        }
                    }
                }
            _taskList.Reload();
        }

        #endregion
    }
}