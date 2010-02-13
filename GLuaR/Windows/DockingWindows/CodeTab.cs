using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Fireball.CodeEditor.SyntaxFiles;
using Fireball.Docking;
using Fireball.Syntax;
using Fireball.Windows.Forms;
using Fireball.Windows.Forms.CodeEditor;
using Fireball.Windows.Forms.CodeEditor.TextDraw;
using GLuaR.Classes.Workspace;

namespace GLuaR.Windows.DockingWindows
{
    internal class CodeTab : DockableWindow
    {
        private IContainer components;
        public SyntaxDocument Document;
        public CodeEditorControl Editor;

        public CodeTab(OpenedFile file)
        {
            InitializeComponent();

            switch (GetFileType(file.Name))
            {
                case "txt":
                    CodeEditorSyntaxLoader.SetSyntax(Editor, SyntaxLanguage.Text);
                    break;

                default:
                    CodeEditorSyntaxLoader.SetSyntax(Editor, SyntaxLanguage.Lua);
                    break;
            }
            Editor.Open(file.FullName);
            Tag = file;
        }

        private static string GetFileType(string filename)
        {
            return filename.Substring(filename.Length - 3, 3).ToLower();
        }

        public void InitializeComponent()
        {
            components = new Container();
            var lineMarginRender1 = new LineMarginRender();
            Editor = new CodeEditorControl();
            Document = new SyntaxDocument(components);
            SuspendLayout();
            // 
            // editor
            // 
            Editor.ActiveView = ActiveView.BottomRight;
            Editor.AllowBreakPoints = false;
            Editor.AutoListPosition = null;
            Editor.AutoListSelectedText = "a123";
            Editor.AutoListVisible = false;
            Editor.ChildBorderStyle = ControlBorderStyle.None;
            Editor.CopyAsRTF = false;
            Editor.Dock = DockStyle.Fill;
            Editor.Document = Document;
            Editor.InfoTipCount = 1;
            Editor.InfoTipPosition = null;
            Editor.InfoTipSelectedIndex = 1;
            Editor.InfoTipVisible = false;
            lineMarginRender1.Bounds = new Rectangle(19, 0, 19, 16);
            Editor.LineMarginRender = lineMarginRender1;
            Editor.Location = new Point(0, 0);
            Editor.LockCursorUpdate = false;
            Editor.Name = "editor";
            Editor.ParseOnPaste = true;
            Editor.Saved = false;
            Editor.ShowScopeIndicator = false;
            Editor.ShowTabGuides = true;
            Editor.Size = new Size(680, 383);
            Editor.SmoothScroll = true;
            Editor.SplitView = false;
            Editor.SplitviewH = -4;
            Editor.SplitviewV = -4;
            Editor.TabGuideColor = Color.FromArgb(244, 243, 234);
            Editor.TabIndex = 0;
            Editor.TextDrawStyle = TextDrawType.SingleBorder;
            Editor.WhitespaceColor = SystemColors.ControlDark;
            Editor.Click += editor_Click;
            Editor.TextChanged += EditorTextChanged;

            Editor.FontName = "Courier New";
            Editor.FontSize = 10;
            // 
            // document
            // 
            Document.Lines = new[]{ "" };
            Document.MaxUndoBufferSize = 1000;
            Document.Modified = false;
            Document.UndoStep = 0;
            // 
            // CodeTab
            // 
            ClientSize = new Size(680, 383);
            Controls.Add(Editor);
            DockableAreas = DockAreas.Document;
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "CodeTab";
            ShowIcon = false;
            ShowInTaskbar = false;
            TabText = "[ Document ]";
            Text = "[ Document ]";
            Load += CodeTab_Load;
            ResumeLayout(false);
        }

        private void CodeTab_Load(object sender, EventArgs e)
        {
        }

        private void EditorTextChanged(object sender, EventArgs e)
        {
            TabText = Editor.FileName + "*";


            /*if (this.Tag.GetType().Name == "OpenedFile")
            {
                this.TabText = "SHIT CHANGED";
           
                if (((OpenedFile)this.Tag).Saved == true)
                    this.TabText = this.TabText + "*";
                ((OpenedFile)this.Tag).Saved = false;
            }*/
        }

        private void editor_Click(object sender, EventArgs e)
        {
        }
    }
}