using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Novel
{
    public partial class Form2 : Form
    {
        private Color foreColor;
        private Font font;
        private Color backColor;
        public Form2()
        {
            InitializeComponent();
            this.richTextBox1.ForeColor = foreColor = Form1.form1.NovelBox.ForeColor;
            this.richTextBox1.Font = font = Form1.form1.NovelBox.Font;
            this.richTextBox1.BackColor = backColor = Form1.form1.NovelBox.BackColor;
        }

        private void confirm_btn_Click(object sender, EventArgs e)
        {
            RSS.Default.font = Form1.form1.NovelBox.Font = this.richTextBox1.Font;//将当前选定的文字改变字体
            RSS.Default.fontColor = Form1.form1.NovelBox.ForeColor = this.richTextBox1.ForeColor;
            RSS.Default.backColor = Form1.form1.NovelBox.BackColor = this.richTextBox1.BackColor;
            RSS.Default.Save();
            this.Hide();
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void fontbtn_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Color = foreColor;
            fontDialog.ShowColor = true;
            fontDialog.Font = font;
            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                foreColor = fontDialog.Color;
                font = fontDialog.Font;
                this.richTextBox1.Font = font;//将当前选定的文字改变字体
                this.richTextBox1.ForeColor = foreColor;
            }
        }

        private void backColorBtn_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = backColor;//初始化当前文本框中的字体颜色，当用户在ColorDialog对话框中点击"取消"按钮恢复原来的值
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                backColor = colorDialog.Color;
                this.richTextBox1.BackColor = colorDialog.Color;
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }



        private void verticalSpacingText_TextChanged(object sender, EventArgs e)
        {
            //String str = (this.verticalSpacingText.Text.Length) > 0 ? this.verticalSpacingText.Text:"0";
            //int i = int.Parse(str);
            //Form1.form1.SetLineSpace(this.richTextBox1, i);
        }

        private void verticalSpacingText_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }
    }
}
