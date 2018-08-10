using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace Tools
{
    public class TXT
    {
        /// <summary>
        /// 读取txt文件
        /// </summary>
        /// <param name="path">txt文件的绝对路径</param>
        /// <returns>txt文件的内容保存到stringbuilder中返回</returns>
        public StringBuilder ResumeTxt(string path)
        {
            StringBuilder str = new StringBuilder();
            str.Length = 0;
            str.Remove(0, str.Length);
            
            StreamReader reader = new StreamReader(path, Tools.FileHelper.GetType(path));
            str.Append(reader.ReadToEnd());
            fliter(str);
            //str = reader.ReadToEnd();

            //再通过查询解析出来的的字符串有没有GB2312 的字段，来判断是否是GB2312格式的，如果是，则重新以GB2312的格式解析
            Regex reGB = new Regex("GB2312", RegexOptions.IgnoreCase);
            //Match mcGB = reGB.Match(str);
            Match mcGB = reGB.Match(str.ToString());
            if (mcGB.Success)
            {
                StreamReader reader2 = new StreamReader(path, System.Text.Encoding.GetEncoding("GB2312"));
                str.Append(reader2.ReadToEnd());
                fliter(str);
            }
            return str;
        }

        /// <summary>
        /// 过滤器
        /// </summary>
        /// <param name="str"></param>
        public void fliter(StringBuilder str)
        {
            str.Replace("☆、", "");
        }
    }
}
