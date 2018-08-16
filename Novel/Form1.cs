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
using System.Runtime.InteropServices;

namespace Novel
{
    public partial class Form1 : Form
    {
        Tools.RAR rar = new Tools.RAR();
        Tools.TXT txt = new Tools.TXT();
        static bool flag = true;
        static bool flag1 = true;
        Color windowBackColor;
        //static string path = Application.StartupPath + "\\ReadingRecord.txt";
        //static string recordPath = null;
        //static int recordLine = 0;

        // 发送消息
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        public static int EM_SCROLL = 0xB5;//控制鼠标滚轮
        public static int WM_KILLFOCUS = 0x08;

        public Form1()
        {
            InitializeComponent();
            notifyIcon1.Visible = true;
            this.StartPosition = FormStartPosition.CenterScreen;//窗口居中
            this.Size = new Size(RSS.Default.windowWidth, RSS.Default.windowHeight);//读取历史窗口大小
            this.windowBackColor = this.BackColor;//暂时保存一下toolstrip的背景色，防止隐藏后重新显示时toolstrip出现透明的现象
            //读取历史样式
            this.NovelBox.Font = RSS.Default.font;
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
            if(RSS.Default.lastTextPath != "")  //读取上次阅读进度
            {
                this.openFile(RSS.Default.lastTextPath, RSS.Default.lastTextIndex);
            }
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
                hideNovel(flag1);   //隐藏窗口
            }
            if (e.KeyCode == Keys.F7)
            {
                this.Hide();    //最小化窗口
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();   //关闭窗口
            }
            if (e.KeyCode == Keys.Down)
            {
                //Console.WriteLine( this.getCurrentLine(this.NovelBox));
                //turnRowsId(this.getCurrentLine(this.NovelBox), this.NovelBox);
                //this.myScroll(this.NovelBox, "nextLine");
                //this.NovelBox.SelectionStart = getCurrentIndex(this.NovelBox);
                //this.NovelBox.Focus();
                //Console.WriteLine("KeyDown");
                //e.Handled = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                //Console.WriteLine(this.getCurrentLine(this.NovelBox));
                //turnRowsId(this.getCurrentLine(this.NovelBox), this.NovelBox);
                //this.myScroll(this.NovelBox, "lastLine");
                //this.NovelBox.SelectionStart = getCurrentIndex(this.NovelBox);
                //this.NovelBox.Focus();
                //Console.WriteLine("KeyDown");
                //e.Handled = true;
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                //Console.WriteLine( this.getCurrentLine(this.NovelBox));
                //turnRowsId(this.getCurrentLine(this.NovelBox), this.NovelBox);
                this.myScroll(this.NovelBox, "nextLine");
                //Console.WriteLine("KeyUp");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                //Console.WriteLine(this.getCurrentLine(this.NovelBox));
                //turnRowsId(this.getCurrentLine(this.NovelBox), this.NovelBox);
                this.myScroll(this.NovelBox, "lastLine");
                //Console.WriteLine("KeyUp");
                e.Handled = true;
            }
        }

        private void NovelBox_MouseWheel(object sender, MouseEventArgs e)
        {
            RSS.Default.lastTextLine = this.getCurrentLine(this.NovelBox);
            RSS.Default.Save();
            if (!flag1) // 隐藏模式下使用鼠标滚轮，每次滚动一行
            {
                if (e.Delta > 0)//滚轮向上滑动
                {
                    this.myScroll(this.NovelBox, "lastLine");
                }
                else
                {
                    this.myScroll(this.NovelBox, "nextLine");
                }
            }
        }
        /// <summary>
        /// 修改窗口大小时
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)    //最小化到系统托盘
            {
                this.Hide();    //隐藏窗口
            }
            else
            {
                //如果不是最小化的操作，那么需要记录一下修改后的窗体大小
                RSS.Default.windowHeight = this.Bottom - this.Top;
                RSS.Default.windowWidth = this.Right - this.Left;
                RSS.Default.Save();
            }

        }
        /// <summary>
        /// 拖拽文件到文本框中
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NovelBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All; //重要代码：表明是所有类型的数据，比如文件路径
            else
                e.Effect = DragDropEffects.None;
        }
        /// <summary>
        /// 拖拽文件到文本框中，并释放鼠标时，获取文件路径，并打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NovelBox_DragDrop(object sender, DragEventArgs e)
        {
            this.NovelBox.Text = "";
            string filePath = ((System.Array)e.Data.GetData(DataFormats.FileDrop)).GetValue(0).ToString();  //获得路径
            this.openFile(filePath,0);//打开文件

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
                this.closeWindow();//关闭窗口
            }
        }
        /// <summary>
        /// 双击windows右下角的icon图标
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            WindowState = FormWindowState.Normal;
            //this.Focus();
            NovelBox.Select();
        }

        /// <summary>
        /// 窗体右上角红色叉叉事件
        /// </summary>
        /// <param name="msg"></param>
        protected override void WndProc(ref Message msg)
        {
            
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            try
            {
                if (msg.Msg == WM_SYSCOMMAND && ((int)msg.WParam == SC_CLOSE))
                {
                    // 点击winform右上关闭按钮 
                    // 加入想要的逻辑处理
                    this.closeWindow();
                    //return;阻止了窗体关闭
                }
                base.WndProc(ref msg);
            }
            catch
            {
                MessageBox.Show("错误编码："+msg.Msg.ToString());
                //this.closeWindow();
            }
        }

        /// <summary>
        /// 隐藏模式
        /// </summary>
        /// <param name="f"></param>
        private void hideNovel(bool f)
        {
            if (f)
            {
                RSS.Default.lastTextIndex = this.getCurrentIndex(this.NovelBox);
                RSS.Default.Save();
                this.FormBorderStyle = FormBorderStyle.None;
                this.NovelBox.ScrollBars = RichTextBoxScrollBars.None;
                this.BackColor = Color.FromArgb(255,255,254);
                this.TransparencyKey = this.BackColor;
                this.NovelBox.BackColor = this.BackColor;
                this.toolStrip1.Visible = false;
                //this.NovelBox.Focus();
                turnIndexId(RSS.Default.lastTextIndex, this.NovelBox);
                flag1 = false;
            }
            else
            {
                RSS.Default.lastTextIndex = this.getCurrentIndex(this.NovelBox);
                RSS.Default.Save();
                this.FormBorderStyle = FormBorderStyle.Sizable;
                this.NovelBox.ScrollBars = RichTextBoxScrollBars.Vertical;
                this.BackColor = this.windowBackColor;
                this.TransparencyKey = Color.White;
                this.NovelBox.BackColor = RSS.Default.backColor;
                this.toolStrip1.Visible = true;
                this.toolStrip1.BackColor = Color.FromArgb(255, 255, 254);
                turnIndexId(RSS.Default.lastTextIndex, this.NovelBox);
                //this.NovelBox.Focus();
                flag1 = true;
            }
        }

        /// <summary>
        /// 并关闭窗口：保存当前阅读进度后，关闭程序
        /// </summary>
        private void closeWindow()
        {
            RSS.Default.lastTextIndex = this.getCurrentIndex(this.NovelBox);
            RSS.Default.Save();
            notifyIcon1.Dispose();//释放notifyIcon1的所有资源，以保证托盘图标在程序关闭时立即消失，且必须得在执行退出前，先执行图标清除才有效
            System.Environment.Exit(System.Environment.ExitCode);
            this.Dispose();
            this.Close();
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
        /// <param name="index">打开文件后跳转到第index个字符的位置</param>
        private void openFile(string filePath,int index)
        {
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string unRarPath = Application.StartupPath + "\\Books\\" + fileName;//解压到的目标路径

            if (filePath.ToLower().IndexOf(".txt") != -1 || filePath.ToLower().IndexOf(".rar") != -1 || filePath.ToLower().IndexOf(".zip") != -1)
            {
                if (filePath.ToLower().IndexOf(".txt") != -1)
                {
                    this.NovelBox.Text = txt.ResumeTxt(filePath).ToString();//在文本框中显示过滤后的文件
                }
                else
                {
                    rar.unCompressRAR(unRarPath, filePath);
                    //读取文件显示在textbox里
                    string[] fileInUnRarPath = Directory.GetFiles(unRarPath);
                    this.NovelBox.Text = txt.ResumeTxt(fileInUnRarPath[0]).ToString();//在文本框中显示过滤后的文件
                }
                this.turnIndexId(index, this.NovelBox);//跳转到第index个字符位置处（初次打开时index=0，有历史阅读进度时index!=0
                RSS.Default.lastTextPath = filePath;//保存当前打开的文件位置
                RSS.Default.Save();
            }
            else
            {
                MessageBox.Show("文件格式错误！");
            }
        }

        /// <summary>
        /// 获取当前行的位置（与光标所在位置无关）
        /// </summary>
        /// <param name="rich"></param>
        /// <returns></returns>
        private int getCurrentLine(RichTextBox rich)
        {
            //获得当前坐标信息
            Point p = rich.Location;
            int positionIndex = rich.GetCharIndexFromPosition(p);
            int positionLine = rich.GetLineFromCharIndex(positionIndex);
            return positionLine;
        }

        /// <summary>
        /// 跳转到第n行的位置
        /// </summary>
        /// <param name="line">当前行</param>
        /// <param name="rich"></param>
        private void turnRowsId(int line, RichTextBox rich)
        {
            rich.SelectionStart = rich.GetFirstCharIndexFromLine(line);
            rich.SelectionLength = 0;
            rich.Focus();
            rich.ScrollToCaret();

        }
        /// <summary>
        /// 获取当前行第一个字符的位置（与光标所在位置无关）
        /// </summary>
        /// <param name="rich"></param>
        /// <returns></returns>
        private int getCurrentIndex(RichTextBox rich)
        {
            //获得当前坐标信息
            Point p = rich.Location;
            int positionIndex = rich.GetCharIndexFromPosition(p);
            return positionIndex;
        }
        /// <summary>
        /// 跳转到第n个位置
        /// </summary>
        /// <param name="index"></param>
        /// <param name="rich"></param>
        private void turnIndexId(int index, RichTextBox rich)
        {
            rich.SelectionStart = index;
            rich.SelectionLength = 0;
            rich.Focus();
            rich.ScrollToCaret();
        }



        /// <summary>
        /// 滚动焦点
        /// </summary>
        /// <param name="rich"></param>
        /// <param name="command">
        /// 滚动到下一行:nextLine
        /// 滚动到上一行:lastLine
        /// 滚动到下一页:nextPage
        /// 滚动到上一页:lastPage
        /// </param>
        private void myScroll(RichTextBox rich,String command)
        {
            switch (command)
            {
                case "nextLine":
                    SendMessage(rich.Handle, EM_SCROLL, 1, 0); // 滚动到下一行
                    break;
                case "lastLine":
                    SendMessage(rich.Handle, EM_SCROLL, 0, 0);//滚动到上一行
                    break;
                case "nextPage":
                    SendMessage(rich.Handle, EM_SCROLL, 3, 0);//滚动到下一页
                    break;
                case "lastPage":
                    SendMessage(rich.Handle, EM_SCROLL, 2, 0);//滚动到上一页
                    break;
                default:
                    Console.WriteLine("非法命令");
                    break;
            }
            
        }
        /// <summary>
        /// 弃用
        /// 获取当前光标的位置
        /// </summary>
        /// <param name="rich"></param>
        /// <returns></returns>
        private int _getCurrentIndex(RichTextBox rich)
        {
            /*  得到光标行第一个字符的索引，
             *  即从第1个字符开始到光标行的第1个字符索引*/
            int row = rich.GetFirstCharIndexOfCurrentLine();
            /*得到光标行的行号,第1行从0开始计算，习惯上我们是从1开始计算，所以+1。 */
            //int line = rich.GetLineFromCharIndex(index) + 1;
            int column = rich.SelectionStart - row;
            return row + column;
        }


    }
}
