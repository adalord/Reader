using System.Windows.Forms;

namespace Novel
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.openButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.fontButton = new System.Windows.Forms.ToolStripButton();
            this.backColorButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.hideButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exitButton = new System.Windows.Forms.ToolStripButton();
            this.NovelBox = new Tools.MyRichTextBox();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.toolStripButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Window;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openButton,
            this.toolStripSeparator1,
            this.fontButton,
            this.backColorButton,
            this.toolStripButton2,
            this.hideButton,
            this.toolStripSeparator3,
            this.toolStripSeparator2,
            this.exitButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(484, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // openButton
            // 
            this.openButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.openButton.Image = ((System.Drawing.Image)(resources.GetObject("openButton.Image")));
            this.openButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(36, 22);
            this.openButton.Text = "打开";
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // fontButton
            // 
            this.fontButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.fontButton.Image = ((System.Drawing.Image)(resources.GetObject("fontButton.Image")));
            this.fontButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fontButton.Name = "fontButton";
            this.fontButton.Size = new System.Drawing.Size(36, 22);
            this.fontButton.Text = "字体";
            this.fontButton.Click += new System.EventHandler(this.fontButton_Click);
            // 
            // backColorButton
            // 
            this.backColorButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.backColorButton.Image = ((System.Drawing.Image)(resources.GetObject("backColorButton.Image")));
            this.backColorButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.backColorButton.Name = "backColorButton";
            this.backColorButton.Size = new System.Drawing.Size(36, 22);
            this.backColorButton.Text = "背景";
            this.backColorButton.Click += new System.EventHandler(this.backColorButton_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(60, 22);
            this.toolStripButton2.Text = "视图设置";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // hideButton
            // 
            this.hideButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.hideButton.Image = ((System.Drawing.Image)(resources.GetObject("hideButton.Image")));
            this.hideButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.hideButton.Name = "hideButton";
            this.hideButton.Size = new System.Drawing.Size(36, 22);
            this.hideButton.Text = "隐藏";
            this.hideButton.Click += new System.EventHandler(this.hideButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // exitButton
            // 
            this.exitButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exitButton.Image = ((System.Drawing.Image)(resources.GetObject("exitButton.Image")));
            this.exitButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(36, 22);
            this.exitButton.Text = "退出";
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // NovelBox
            // 
            this.NovelBox.AcceptsTab = true;
            this.NovelBox.AllowDrop = true;
            this.NovelBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NovelBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.NovelBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NovelBox.Location = new System.Drawing.Point(0, 25);
            this.NovelBox.Name = "NovelBox";
            this.NovelBox.ReadOnly = true;
            this.NovelBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.NovelBox.Size = new System.Drawing.Size(484, 236);
            this.NovelBox.TabIndex = 1;
            this.NovelBox.Text = "";
            this.NovelBox.DragDrop += new System.Windows.Forms.DragEventHandler(this.NovelBox_DragDrop);
            this.NovelBox.DragEnter += new System.Windows.Forms.DragEventHandler(this.NovelBox_DragEnter);
            this.NovelBox.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.NovelBox_MouseWheel);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "Novel";
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(48, 22);
            this.toolStripButton1.Text = "间距";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.NovelBox);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private Tools.MyRichTextBox NovelBox;
        //private System.Windows.Forms.RichTextBox NovelBox;
        private System.Windows.Forms.ToolStripButton openButton;
        private System.Windows.Forms.ToolStripButton hideButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton backColorButton;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton exitButton;
        private ToolStripButton fontButton;
        private ToolStripSplitButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripSeparator toolStripSeparator3;
    }
}

