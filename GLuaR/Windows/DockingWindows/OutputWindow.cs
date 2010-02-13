using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Fireball.Docking;

using GLuaR.Classes.Workspace;

namespace GLuaR.Windows.DockingWindows
{
    public partial class OutputWindow : DockableWindow
    {
        Workspace myWorkspace;
        public OutputWindow( Workspace workspace )
        {
            InitializeComponent();

            myWorkspace = workspace;


            //this.DockState = DockState.DockBottom;

        }

        private void OutputWindow_Load(object sender, EventArgs e)
        {
            //this.DockState = DockState.DockBottom;
        }


    }
}