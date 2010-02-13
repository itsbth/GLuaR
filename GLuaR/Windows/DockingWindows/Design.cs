using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Fireball.Docking;
using GLuaR.Windows.Designer;

namespace GLuaR.Windows.DockingWindows
{
    public partial class Design : DockableWindow
    {
        // These are some basic colours

        public static readonly Color defBGColor = Color.FromArgb(255, 90, 90, 90);
        public static readonly Color defBGColorSleep = Color.FromArgb(240, 60, 60, 60);
        public static readonly Color defBGColorDark = Color.FromArgb(255, 50, 50, 50);
        public static readonly Color defControlColour = Color.FromArgb(255, 110, 110, 110);
        public static readonly Color defControlColourHi = Color.FromArgb(255, 130, 130, 130);
        public static readonly Color defControlColourActive = Color.FromArgb(255, 110, 150, 200);
        public static readonly Color defControlColourBright = Color.FromArgb(255, 255, 200, 100);


        // End Basic Colours

        public Control currentlyActiveControl = null;

        public Design()
        {
            InitializeComponent();
            this.BackColor = defBGColor;
        }

        private void Design_Activated(object sender, EventArgs e)
        {
            currentlyActiveControl = this;
        }

        public void SetActiveControl(BaseDermaControl control)
        {
            label1.Text = "Active Derma Control: " + control.Name;
            currentlyActiveControl = control;
        }
    }
}
