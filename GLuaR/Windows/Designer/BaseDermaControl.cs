using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

using GLuaR.Windows.DockingWindows;

namespace GLuaR.Windows.Designer
{
    public partial class BaseDermaControl : UserControl
    {
        Point clickLocation = new Point(0,0);

        public BaseDermaControl()
        {
            InitializeComponent();
            this.BackColor = Design.defControlColour;
        }

        private void BaseDermaControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int newX, newY = 0;
                int incrementX, incrementY = 0;

                newX = e.X - clickLocation.X;
                newY = e.Y - clickLocation.Y;

                incrementX = this.Location.X + newX;
                incrementY = this.Location.Y + newY;

                Location = new Point(incrementX, incrementY);
            }
        }

        private void BaseDermaControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Here set the location that we are clicking on the control
                clickLocation = e.Location;
            }
        }

        private void BaseDermaControl_Click(object sender, EventArgs e)
        {
            // We REALLY shouldn't be used on any other type of control... Just make sure
            if (Parent != null && Parent.GetType().Name == "Design")
            {
                ((Design)Parent).SetActiveControl(this);
            }
        }
    }
}
