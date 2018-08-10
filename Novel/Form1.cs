using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Novel;

namespace Novel
{
    public partial class Form1 : Form
    {
        Tools.RAR rar = new Tools.RAR();
        Tools.TXT txt = new Tools.TXT();
        static bool flag = true;
        static bool flag1 = true;
        //static string path = Application.StartupPath + "\\ReadingRecord.txt";
        //static string recordPath = null;
        //static int recordLine = 0;

        public Form1()
        {
            InitializeComponent();
            notifyIcon1.Visible = true;
            this.StartPosition = FormStartPosition.CenterScreen;//窗口居中
            //Color foreColor = Color.FromArgb(0, 0, 0);
            //Font font = new Font(FontFamily.GenericMonospace, 12, FontStyle.Regular);

            this.NovelBox.Font = RSS.Default.font;//将当前选定的文字改变字体
            this.NovelBox.ForeColor = RSS.Default.fontColor;
            this.NovelBox.BackColor = RSS.Default.backColor;

            this.Text = "隐藏/恢复菜单【F5】,隐藏/恢复【F6】,最小化【F7】";

            //System.IO.StreamReader file = new System.IO.StreamReader(path);
            //recordPath = file.ReadLine();
            //recordLine = Convert.ToInt32(file.ReadLine());
            //int width = Convert.ToInt32(file.ReadLine());
            //int height = Convert.ToInt32(file.ReadLine());
            //file.Close();

            ////阅读记录
            //if (recordPath != "")
            //{
            //    this.NovelBox.Text = txt.ResumeTxt(recordPath).ToString();
            //    int start = this.NovelBox.GetFirstCharIndexFromLine(recordLine);
            //    this.NovelBox.SelectionStart = start;
            //    this.NovelBox.ScrollToCaret();
            //    this.Width = width;
            //    this.Height = height;
            //}
            if(RSS.Default.lastTextPath != "")
                this.openFile(RSS.Default.lastTextPath,RSS.Default.lastTextIndex);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (flag)
                {
                    this.TransparencyKey = BackColor;
                    this.toolStrip1.Visible = false;
                    this.NovelBox.Focus();
                    flag = false;
                }
                else
                {
                    this.TransparencyKey = Color.Snow;
                    this.toolStrip1.Visible = true;
                    flag = true;
                }
            }
            if (e.KeyCode == Keys.F6)
            {
                hideNovel(flag1);
            }
            if (e.KeyCode == Keys.F7)
            {
                this.Hide();    //隐藏窗口
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)    //最小化到系统托盘
            {
                this.Hide();    //隐藏窗口
            }
        }

        private void NovelBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;                                                              //重要代码：表明是所有类型的数据，比如文件路径
            else
                e.Effect = DragDropEffects.None;
        }
        private void NovelBox_DragDrop(object sender, DragEventArgs e)
        {
            this.NovelBox.Text = "";
            string filePath = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();       //获得路径
            this.openFile(filePath,0);

        }

        private void openButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Multiselect = false;
            fileDialog.Title = "请选择文件";
            fileDialog.Filter = "小说文件(*.rar,*.zip,*.txt)|*.rar;*.zip;*.txt";
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = fileDialog.FileName;
                this.openFile(filePath,0);
                
            }
        }


        private void fontButton_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog = new FontDialog();
            fontDialog.Color = this.NovelBox.ForeColor;
            fontDialog.ShowColor = true;
            if (fontDialog.ShowDialog() != DialogResult.Cancel)
            {
                RSS.Default.font = this.NovelBox.Font = fontDialog.Font;//将当前选定的文字改变字体
                RSS.Default.fontColor = this.NovelBox.ForeColor = fontDialog.Color;
                RSS.Default.Save();
            }
        }

        private void backColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.AllowFullOpen = true;
            colorDialog.FullOpen = true;
            colorDialog.ShowHelp = true;
            colorDialog.Color = Color.White;//初始化当前文本框中的字体颜色，当用户在ColorDialog对话框中点击"取消"按钮恢复原来的值
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                RSS.Default.backColor = this.NovelBox.BackColor = colorDialog.Color;
                RSS.Default.Save();
            }

        }

        private void hideButton_Click(object sender, EventArgs e)
        {
            hideNovel(flag1);
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("最小化到托盘？", "退出", MessageBoxButtons.YesNo,
                          MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            if (result == DialogResult.Yes)
            {
                this.Hide();    //隐藏窗口
            }
            else
            {
                this.closeWindow();
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            this.Focus();
            NovelBox.Select();
        }

        /// <summary>
        /// 隐身模式
        /// </summary>
        /// <param name="f"></param>
        private void hideNovel(bool f)
        {
            if (f)
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.NovelBox.ScrollBars = RichTextBoxScrollBars.None;
                this.BackColor = Color.FromArgb(255,255,255);
                this.TransparencyKey = this.BackColor;
                this.NovelBox.BackColor = this.BackColor;
                this.toolStrip1.Visible = false;
                this.NovelBox.Focus();
                flag1 = false;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.NovelBox.ScrollBars = RichTextBoxScrollBars.Vertical;
                this.TransparencyKey = Color.White;
                this.toolStrip1.Visible = true;
                this.NovelBox.BackColor = RSS.Default.backColor;
                this.NovelBox.Focus();
                flag1 = true;
            }
        }



        //private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        //{
        //    recordLine = this.NovelBox.GetLineFromCharIndex(this.NovelBox.SelectionStart);
        //    //recordLine = 1000;
        //    FileStream fst = new FileStream(path, FileMode.Create);
        //    //写数据到txt
        //    StreamWriter swt = new StreamWriter(fst, System.Text.Encoding.GetEncoding("utf-8"));
        //    //写入
        //    swt.WriteLine(recordPath);
        //    swt.WriteLine(recordLine);
        //    swt.WriteLine(this.Width);
        //    swt.WriteLine(this.Height);
        //    swt.Close();
        //    fst.Close();
        //}

        

        /// <summary>
        /// 打开txt|rar|zip文件
        /// </summary>
        /// <param name="filePath">文件路径</param>
        private void openFile(string filePath,int index)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string unRarPath = Application.StartupPath + "\\Books\\" + fileName;//解压到的目标路径

            if (filePath.ToLower().IndexOf(".txt") != -1 || filePath.ToLower().IndexOf(".rar") != -1 || filePath.ToLower().IndexOf(".zip") != -1)
            {
                if (filePath.ToLower().IndexOf(".txt") != -1)
                {
                    this.NovelBox.Text = txt.ResumeTxt(filePath).ToString();//在文本框中显示过滤后的文件
                                                                            //recordPath = filePath;
                }
                else
                {
                    rar.unCompressRAR(unRarPath, filePath);

                    //读取文件显示在textbox里
                    string[] fileInUnRarPath = Directory.GetFiles(unRarPath);
                    this.NovelBox.Text = txt.ResumeTxt(fileInUnRarPath[0]).ToString();//在文本框中显示过滤后的文件
                                                                                      //recordPath = fileInUnRarPath[0];
                    
                }

                turnRowsId(index, this.NovelBox);
                RSS.Default.lastTextPath = filePath;
                RSS.Default.Save();
            }
            else
            {
                MessageBox.Show("文件格式错误！");
            }
        }

        /// <summary>
        /// 跳转到第n个位置
        /// </summary>
        /// <param name="index"></param>
        /// <param name="rich"></param>
        private void turnRowsId(int index, RichTextBox rich)
        {
            rich.SelectionStart = index;
            rich.SelectionLength = 0;
            rich.Focus();
            rich.ScrollToCaret();

        }

        /// <summary>
        /// 获取当前光标的位置
        /// </summary>
        /// <param name="rich"></param>
        /// <returns></returns>
        private int getCurrentIndex(RichTextBox rich)
        {
            /*  得到光标行第一个字符的索引，
             *  即从第1个字符开始到光标行的第1个字符索引*/
            int row = rich.GetFirstCharIndexOfCurrentLine();
            /*得到光标行的行号,第1行从0开始计算，习惯上我们是从1开始计算，所以+1。 */
            //int line = rich.GetLineFromCharIndex(index) + 1;
            int column = rich.SelectionStart - row;
            return row + column;
        }

        /// <summary>
        /// 保存当前光标位置，并关闭窗口
        /// </summary>
        private void closeWindow()
        {
            RSS.Default.lastTextIndex = this.getCurrentIndex(this.NovelBox);
            RSS.Default.Save();
            System.Environment.Exit(System.Environment.ExitCode);
            this.Dispose();
            this.Close();
        }

        /// <summary>
        /// 窗体右上角红色叉叉事件
        /// </summary>
        /// <param name="msg"></param>
        protected override void WndProc(ref Message msg)
        {
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;

            if (msg.Msg == WM_SYSCOMMAND && ((int)msg.WParam == SC_CLOSE))
            {
                // 点击winform右上关闭按钮 
                // 加入想要的逻辑处理
                this.closeWindow();
                //return;阻止了窗体关闭
            }
            base.WndProc(ref msg);
        }

        private void NovelBox_MouseWheel(object sender, MouseEventArgs e)
        {

        }
    }
}
