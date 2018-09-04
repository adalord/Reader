using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Tools
{
    public class MyRichTextBox:System.Windows.Forms.RichTextBox
    {

        public MyRichTextBox()
        {
            this.GetType().GetProperty("DoubleBuffered", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic).SetValue(this, true, null);
            this.Cursor = Cursors.Arrow;//设置鼠标样式  
        }
        //只读模式，可以屏蔽光标，但是无法解决在透明模式下无法选中的问题
        //protected override void WndProc(ref Message m)
        //{
        //    if (m.Msg == 0x7 || m.Msg == 0x201 || m.Msg == 0x202 || m.Msg == 0x203 || m.Msg == 0x204 || m.Msg == 0x205 || m.Msg == 0x206 || m.Msg == 0x0100 || m.Msg == 0x0101)
        //    {
        //        return;
        //    }
        //    base.WndProc(ref m);
        //}

    }
}
