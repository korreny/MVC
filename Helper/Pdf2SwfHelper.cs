#region 说明
/* ===============================
* 
* Author：dlli5 Time：2014/9/2 16:26:01 
* File name：Pdf2SwfHelper 
* Version：V1.0.1
* Company: Iflysse 
* ================================
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Com.Iflysse.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public class Pdf2SwfHelper
    {
        public static void Pdf2Swf(string Pdf2SwfPath, string pdfPath, string swfPath)
        {
            if (!File.Exists(Pdf2SwfPath))
            {
                throw new Exception("Pdf2SwfPath 不存在！");
            }
            if (!File.Exists(pdfPath))
            {
                throw new Exception(pdfPath + "不存在！");
            }
            string sourcePath = @"""" + pdfPath + @"""";
            string targetPath = @"""" + swfPath + @"""";
            //@"""" 四个双引号得到一个双引号，如果你所存放的文件所在文件夹名有空格的话，要在文件名的路径前后加上双引号，才能够成功
            // -t 源文件的路径
            // -s 参数化（也就是为pdf2swf.exe 执行添加一些窗外的参数(可省略)）
            string argsStr = "  -t " + sourcePath + " -s flashversion=9 -o " + targetPath;

            using (Process p = new Process())
            {
                try
                {
                    ProcessStartInfo psi = new ProcessStartInfo(Pdf2SwfPath, argsStr);
                    p.StartInfo = psi;
                    p.Start();
                    p.WaitForExit();
                }
                catch (Exception)
                {
                    throw;
                }
                finally
                {
                    try
                    {
                        p.Kill();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }
    }
}
