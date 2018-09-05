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
using System.Drawing.Drawing2D;

namespace Novel
{
    public partial class Form1 : Form
    {
        Tools.RAR rar = new Tools.RAR();
        Tools.TXT txt = new Tools.TXT();
        static bool displayMenu = true; //displayMenu：true显示菜单，false不显示菜单
        static bool opaqueMode = true;  //opaqueMode：true不透明模式，false透明模式
        Color windowBackColor;

        // 发送消息
        [DllImport("user32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        [DllImport("user32", EntryPoint = "HideCaret")]
        private static extern bool HideCaret(IntPtr hWnd);

        public static int EM_SCROLL = 0xB5;//文本垂直滚动。第三个参数*控制滚动方向:SB_LINEDOWN(1)向下滚动一行，SB_LINEUP(0)向上滚动一行，SB_PAGEDOWN(3)向下滚动一页，SB_PAGEUP(2)向上滚动一页
        public static int WM_KILLFOCUS = 0x08;
        public static int EM_GETFIRSTVISIBLEINE = 0xCE;//获得文本控件中处于可见位置的最顶部的文本所在的行号
        public static int EM_LINEINDEX = 0xBB;//获取指定行(或:-1,0 表示光标所在行)首字符在文本中的位置（以字节数表示）
        public static int EM_SETREADONLY = 0xCF;
        public Form1()
        {
            InitializeComponent();
            DoubleBuffered = true;//双缓存处理
            notifyIcon1.Visible = true;
            this.StartPosition = FormStartPosition.CenterScreen;//窗口居中
            this.Size = new Size(RSS.Default.windowWidth, RSS.Default.windowHeight);//读取历史窗口大小
            this.windowBackColor = this.BackColor;//暂时保存一下toolstrip的背景色，防止隐藏后重新显示时toolstrip出现透明的现象
            //读取历史样式
            this.NovelBox.Font = RSS.Default.font;
            this.NovelBox.ForeColor = RSS.Default.fontColor;
            this.NovelBox.BackColor = RSS.Default.backColor;


            this.Text = "隐藏/恢复菜单【F5】,隐藏/恢复【F6】,最小化【F7】";

            if(RSS.Default.lastTextPath != "")  //读取上次阅读进度
            {
                this.openFile(RSS.Default.lastTextPath, RSS.Default.lastTextIndex);
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                if (displayMenu)    //当前显示菜单，则变为不显示菜单
                {
                    this.TransparencyKey = BackColor;
                    this.toolStrip1.Visible = false;
                    this.NovelBox.Focus();
                    displayMenu = false;
                }
                else    //当前不显示菜单，则变为不显示菜单
                {
                    this.TransparencyKey = Color.Snow;
                    this.toolStrip1.Visible = true;
                    displayMenu = true;
                }
            }
            if (e.KeyCode == Keys.F6)
            {
                hideNovel();   //隐藏窗口
            }
            if (e.KeyCode == Keys.F7)
            {
                this.Hide();    //最小化窗口
            }
            if (e.KeyCode == Keys.Escape)
            {
                //this.Close();   //关闭窗口
                this.closeWindow();
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                this.myScroll(this.NovelBox, "nextLine");
                e.Handled = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                this.myScroll(this.NovelBox, "lastLine");
                e.Handled = true;
            }
        }

        private void NovelBox_MouseWheel(object sender, MouseEventArgs e)
        {
            RSS.Default.lastTextLine = this.getCurrentLine(this.NovelBox);
            RSS.Default.Save();
            if (!opaqueMode) // 隐藏模式下使用鼠标滚轮，每次滚动一行
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
            hideNovel();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否直接关闭？", "关闭", MessageBoxButtons.YesNo,
                          MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);
            if (result == DialogResult.Yes)
            {
                this.closeWindow();//关闭窗口
            }
            else
            {
                this.Hide();    //隐藏窗口
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
        /// 透明模式
        /// </summary>
        /// <param name="">全局变量opaqueMode：true正常显示窗口，false透明窗口</param>
        private void hideNovel()
        {
            if (opaqueMode)    //当前为正常显示窗口，则变为透明窗口
            {
                RSS.Default.lastTextIndex = this.getCurrentIndex(this.NovelBox);
                RSS.Default.Save();
                this.FormBorderStyle = FormBorderStyle.None;
                this.NovelBox.ScrollBars = RichTextBoxScrollBars.None;
                this.BackColor = Color.FromArgb(255, 255, 254);
                this.TransparencyKey = this.BackColor;
                this.NovelBox.BackColor = this.BackColor;
                this.toolStrip1.Visible = false;
                turnIndexId(RSS.Default.lastTextIndex, this.NovelBox);
                opaqueMode = false;
            }
            else    //当前为透明窗口，则变为正常模式
            {
                RSS.Default.lastTextIndex = this.getCurrentIndex(this.NovelBox);
                RSS.Default.Save();
                this.toolStrip1.Visible = true;
                this.toolStrip1.BackColor = Color.FromArgb(255, 255, 254);
                this.NovelBox.BackColor = RSS.Default.backColor;
                this.TransparencyKey = Color.White;
                this.BackColor = this.windowBackColor;
                this.NovelBox.ScrollBars = RichTextBoxScrollBars.Vertical;
                this.FormBorderStyle = FormBorderStyle.Sizable;
                turnIndexId(RSS.Default.lastTextIndex, this.NovelBox);
                opaqueMode = true;
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
            Application.Exit();
        }

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
            //Point p = rich.Location;
            //int positionIndex = rich.GetCharIndexFromPosition(p);
            //int positionLine = rich.GetLineFromCharIndex(positionIndex);
            //return positionLine;
            return SendMessage(rich.Handle, EM_GETFIRSTVISIBLEINE, 0, 0);
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
            //Point p = rich.Location;
            //int positionIndex = rich.GetCharIndexFromPosition(p);
            //return positionIndex;
            return SendMessage(rich.Handle, EM_LINEINDEX, getCurrentLine(rich), 0);
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
        /// <summary>滚动到下一行:nextLine</summary>
        /// <summary>滚动到上一行:lastLine</summary>
        /// <summary>滚动到下一页:nextPage</summary>
        /// <summary>滚动到上一页:lastPage</summary>
        /// </param>
        private void myScroll(RichTextBox rich,String command)
        {
            switch (command)
            {
                case "nextLine":
                    PostMessage(rich.Handle, EM_SCROLL, 1, 0); // 滚动到下一行
                    break;
                case "lastLine":
                    PostMessage(rich.Handle, EM_SCROLL, 0, 0);//滚动到上一行
                    break;
                case "nextPage":
                    PostMessage(rich.Handle, EM_SCROLL, 3, 0);//滚动到下一页
                    break;
                case "lastPage":
                    PostMessage(rich.Handle, EM_SCROLL, 2, 0);//滚动到上一页
                    break;
                default:
                    Console.WriteLine("非法命令");
                    break;
            }
            
        }

        
    }
}
