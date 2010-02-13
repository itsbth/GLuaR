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
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using GLuaR.Classes.Workspace;
using GLuaR.Properties;
using GLuaR.Windows.DockingWindows;

namespace GLuaR.Windows
{
    public partial class MainForm : Form
    {
        private readonly Workspace workspace;

        public MainForm()
        {
            InitializeComponent();

            imgList.Images.Add("root", Resources.project_root);
            imgList.Images.Add("code", Resources.project_code);
            imgList.Images.Add("tasklist_checkbox", Resources.tasklist_checkbox);
            imgList.Images.Add("server", Resources.function_server);
            imgList.Images.Add("client", Resources.function_client);
            imgList.Images.Add("shared", Resources.function_shared);
            imgList.Images.Add("library", Resources.library);
            imgList.Images.Add("keyword", Resources.keyword);
            imgList.Images.Add("folder_open", Resources.project_folder_open);
            imgList.Images.Add("folder_closed", Resources.project_folder_closed);
            imgList.Images.Add("file_lost", Resources.file_unavailable);

            workspace = new Workspace(mydc, new ContextMenuStrip(), new ContextMenuStrip(), null, null, null, imgList);
        }

        public MainForm(string proj)
            : this()
        {
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (workspace.Exit())
                Close();
        }

        private void newProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.NewProject();
        }

        private void openProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.OpenProject();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.OpenFile();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.CloseActiveTab();
        }

        private void closeProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.CloseProject();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.SaveActiveTab();
        }

        private void saveProjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.SaveProject();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.Redo();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.Paste();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.Delete();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.SelectAll();
        }

        private void findAndReplaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.Find();
        }

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.Replace();
        }

        private void addNewItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.AddNewItem();
        }

        private void addExistingItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.AddExistingItem();
        }

        private void generateInfoFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.GenerateInfo();
        }

        private void projectPropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.ShowProjectInfo();
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.ShowSettings();
        }

        private void garrysModLuaWikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://wiki.garrysmod.com/wiki/?title=Lua");
            }
            catch
            {
            }
        }

        private void facepunchLuaScriptingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://forums.facepunchstudios.com/forumdisplay.php?f=65");
            }
            catch
            {
            }
        }

        private void gLuaHomepageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("http://glua.net/");
            }
            catch
            {
            }
        }

        private void reportABugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.ReportBug();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            workspace.ShowAbout();
        }

        private void NewProject_Click(object sender, EventArgs e)
        {
            workspace.NewProject();
        }

        private void AddNewItem_Click(object sender, EventArgs e)
        {
            workspace.AddNewItem();
        }

        private void AddExistingItem_Click(object sender, EventArgs e)
        {
            workspace.AddExistingItem();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            workspace.OpenFile();
        }

        private void Save_Click(object sender, EventArgs e)
        {
            workspace.SaveActiveTab();
        }

        private void SaveProject_Click(object sender, EventArgs e)
        {
            workspace.SaveProject();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            workspace.Cut();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            workspace.Copy();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            workspace.Paste();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            workspace.Undo();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            workspace.Redo();
        }

        private void toolStripButton10_Click(object sender, EventArgs e)
        {
            workspace.Find(findbox.Text);
        }

        private void LockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LockPanel.Visible = true;
            LockPanel.Dock = DockStyle.Fill;
            LockPanel.BringToFront();
            toolStrip1.Enabled = false;
            menuStrip1.Enabled = false;
            var p = new Point();
            p.X = ((Width/2) + (pnlLock.Width/2)) - pnlLock.Width;
            p.Y = (Height/2) + (pnlLock.Height/2) - pnlLock.Height;
            pnlLock.Location = p;
            ControlBox = false;
        }

        [DllImport("KERNEL32.DLL", EntryPoint = "CloseHandle", SetLastError = true)]
        public static extern bool CloseHandle(int hObject);

        [DllImport("ADVAPI32.DLL", EntryPoint = "LogonUserW", SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern bool LogonUser(string Username, string Domain, string Password, int dwLogonType,
                                            int dwLogonProvider, out int hToken);

        private void btnUnlock_Click(object sender, EventArgs e)
        {
            int hToken = 0;
            try
            {
                if (LogonUser(Environment.UserName, Environment.UserDomainName, txtPassword.Text, 3, 0, out hToken))
                {
                    LockPanel.Visible = false;
                    txtPassword.Clear();
                    toolStrip1.Enabled = true;
                    menuStrip1.Enabled = true;
                    ControlBox = true;
                }
                else
                {
                    MessageBox.Show("Cannot Unlock... Invalid Windows Password...", "Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            finally
            {
                CloseHandle(hToken);
            }
        }

        private void LockPanel_KeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void LockPanel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void LockPanel_KeyUp(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }

        private void AddItems_Click(object sender, EventArgs e)
        {
            AddItems.ShowDropDown();
        }

        private void Output_Click(object sender, EventArgs e)
        {
            workspace.ShowOutputWindow();
        }

        private void ObjectBrowser_Click(object sender, EventArgs e)
        {
            workspace.ShowObjectBrowser();
        }

        private void TaskList_Click(object sender, EventArgs e)
        {
            workspace.ShowTaskList();
        }

        private void ProjectExplorer_Click(object sender, EventArgs e)
        {
            workspace.ShowProjectExplorer();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            new Design().Show(workspace.Manager);
        }
    }
}