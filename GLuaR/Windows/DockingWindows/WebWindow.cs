using System;
using System.Collections.Generic;
using System.Text;

using Fireball.Docking;

namespace GLuaR.Windows.DockingWindows
{
	class WebWindow : DockableWindow
	{
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.StatusStrip ss;
        private System.Windows.Forms.ToolStripStatusLabel lblstatus;
        private System.Windows.Forms.ToolStripProgressBar pb;
        private System.Windows.Forms.WebBrowser wb;

        public WebWindow(string url)
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.pnlContent = new System.Windows.Forms.Panel();
            this.ss = new System.Windows.Forms.StatusStrip();
            this.lblstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pb = new System.Windows.Forms.ToolStripProgressBar();
            this.wb = new System.Windows.Forms.WebBrowser();
            this.pnlContent.SuspendLayout();
            this.ss.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.ss);
            this.pnlContent.Controls.Add(this.wb);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(0, 0);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(710, 381);
            this.pnlContent.TabIndex = 1;
            // 
            // ss
            // 
            this.ss.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblstatus,
            this.pb});
            this.ss.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.ss.Location = new System.Drawing.Point(0, 359);
            this.ss.Name = "ss";
            this.ss.Size = new System.Drawing.Size(710, 22);
            this.ss.SizingGrip = false;
            this.ss.TabIndex = 2;
            this.ss.Text = "statusStrip1";
            // 
            // lblstatus
            // 
            this.lblstatus.Name = "lblstatus";
            this.lblstatus.Size = new System.Drawing.Size(36, 17);
            this.lblstatus.Text = "Done.";
            // 
            // pb
            // 
            this.pb.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.pb.Name = "pb";
            this.pb.Size = new System.Drawing.Size(100, 16);
            // 
            // wb
            // 
            this.wb.AllowWebBrowserDrop = false;
            this.wb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wb.IsWebBrowserContextMenuEnabled = false;
            this.wb.Location = new System.Drawing.Point(0, 0);
            this.wb.MinimumSize = new System.Drawing.Size(20, 20);
            this.wb.Name = "wb";
            this.wb.Size = new System.Drawing.Size(710, 381);
            this.wb.TabIndex = 1;
            this.wb.WebBrowserShortcutsEnabled = false;
            this.wb.ProgressChanged += new System.Windows.Forms.WebBrowserProgressChangedEventHandler(this.wb_ProgressChanged);
            this.wb.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.wb_Navigating);
            this.wb.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.wb_DocumentCompleted);
            this.wb.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.wb_Navigated);
            // 
            // WebWindow
            // 
            this.ClientSize = new System.Drawing.Size(710, 381);
            this.Controls.Add(this.pnlContent);
            this.DockableAreas = Fireball.Docking.DockAreas.Document;
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WebWindow";
            this.TabText = "Web";
            this.Text = "Web";
            this.ToolTipText = "Web";
            this.Load += new System.EventHandler(this.ReportBug_Load);
            this.Resize += new System.EventHandler(this.ReportBug_Resize);
            this.pnlContent.ResumeLayout(false);
            this.pnlContent.PerformLayout();
            this.ss.ResumeLayout(false);
            this.ss.PerformLayout();
            this.ResumeLayout(false);

        }

        private void ReportBug_Load(object sender, EventArgs e)
        {
            pnlContent.Location = new System.Drawing.Point(((this.Width / 2) - (pnlContent.Width / 2)), ((this.Height / 2) - (pnlContent.Height / 2)));
        }

        private void ReportBug_Resize(object sender, EventArgs e)
        {
            pnlContent.Location = new System.Drawing.Point(((this.Width / 2) - (pnlContent.Width / 2)), ((this.Height / 2) - (pnlContent.Height / 2)));
        }

        private void wb_Navigated(object sender, System.Windows.Forms.WebBrowserNavigatedEventArgs e)
        {
            this.ToolTipText = wb.Document.Title + " - " + wb.Url;
            this.TabText = wb.DocumentTitle;
            pb.Value = 0;
            lblstatus.Text = "Done.";
            pb.Visible = false;
        }

        private void wb_Navigating(object sender, System.Windows.Forms.WebBrowserNavigatingEventArgs e)
        {
            lblstatus.Text = "Loading: " + e.Url;
            pb.Value = 0;
            pb.Visible = true;
        }

        private void wb_ProgressChanged(object sender, System.Windows.Forms.WebBrowserProgressChangedEventArgs e)
        {
            pb.Maximum = ((int)e.MaximumProgress);
            pb.Value = ((int)e.CurrentProgress);
        }

        private void wb_DocumentCompleted(object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e)
        {

        }
    }
}
