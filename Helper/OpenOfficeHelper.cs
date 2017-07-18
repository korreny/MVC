#region 说明
/* ===============================
* 
* Author：dlli5 Time：2014/9/2 15:28:24 
* File name：OpenOfficeHelper 
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
using com.artofsolving.jodconverter.openoffice.connection;
using com.artofsolving.jodconverter.openoffice.converter;
using com.artofsolving.jodconverter;
using java.io;

namespace Com.Iflysse.Helper
{
    /// <summary>
    /// 
    /// </summary>
    public class OpenOfficeHelper
    {
        /// <summary>
        /// 文章转换为PDF格式
        /// </summary>
        /// <param name="OpenOffice_HOME">OpenOffice安装目录</param>
        /// <param name="docPath">文件目录</param>
        /// <param name="pdfPath">pdfPath输入目录</param>
        public static void DocToPdf(string OpenOffice_HOME, string docPath, string pdfPath)
        {
            OpenOfficeConnection connection = null;
            DocumentConverter converter = null;
            Process p = null;
            try
            {
                System.Diagnostics.Process[] processList = System.Diagnostics.Process.GetProcesses();
                foreach (System.Diagnostics.Process process in processList)
                {
                    if (process.ProcessName.Contains("soffice"))
                    {
                        p = process;
                        break;
                    }
                }
                if (p == null)
                {
                    ProcessStartInfo FilestartInfo = new ProcessStartInfo(OpenOffice_HOME);
                    FilestartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                    FilestartInfo.Arguments = " -headless -accept=\"socket,host=127.0.0.1,port=8101;urp;\"";
                    //转换
                    p = Process.Start(FilestartInfo);
                }
                File inputFile = new File(docPath);
                File outputFile = new File(pdfPath);
                connection = new SocketOpenOfficeConnection("127.0.0.1", 8101);
                connection.connect();
                converter = new OpenOfficeDocumentConverter(connection);
                converter.convert(inputFile, outputFile);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (connection != null)
                {
                    try
                    {
                        connection.disconnect();
                    }
                    catch (Exception)
                    {
                    }
                }
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
