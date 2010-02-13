using System;
using System.Windows.Forms;
using Fireball.Docking;
using GLuaR.Classes;
using GLuaR.Classes.Workspace;

namespace GLuaR.Windows.DockingWindows
{
    public partial class TaskWindow : DockableWindow
    {
        private readonly Workspace _myWorkspace;

        public TaskWindow(Workspace workspace)
        {
            InitializeComponent();

            _myWorkspace = workspace;
        }

        private void TaskWindow_Load(object sender, EventArgs e)
        {
            //this.DockState = DockState.DockBottomAutoHide;
        }

        private void btnAddTask_Click(object sender, EventArgs e)
        {
            _myWorkspace.AddTask();
        }

        private void btnEditTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItems.Count > 0)
                if (lstTasks.SelectedItems.Count > 1)
                    Util.ShowError("You can only edit 1 task at a time!");
                else
                    _myWorkspace.EditTask(lstTasks.SelectedItems[0]);
            else
                Util.ShowError("You need to select a task to edit!");
        }

        private void btnDeleteTask_Click(object sender, EventArgs e)
        {
            if (lstTasks.SelectedItems.Count > 0)
                _myWorkspace.DeleteTask(lstTasks.SelectedItems);
            else
                Util.ShowError("You need to select a task to delete!");
        }

        public void Reload()
        {
            lstTasks.Items.Clear();
            foreach (Task task in _myWorkspace.Project.Tasks)
                lstTasks.Items.Add(task.lvm);
        }

        private void lstTasks_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            foreach (Task task in _myWorkspace.Project.Tasks)
            {
                if (task.lvm == e.Item)
                {
                    task.Done = e.Item.Checked;
                    break;
                }
            }
        }
    }
}