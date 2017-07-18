#region 说明
/* ===============================
* 
* Author：dlli5 Time：2014/8/26 16:54:50 
* File name：FileHelper 
* Version：V1.0.1
* Company: Iflysse 
* ================================
*/
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Com.Iflysse.Helper
{
    /// <summary>
    /// 文件帮助类
    /// </summary>
    public class FileHelper
    {
        /// <summary>
        /// 读取文件内容
        /// 一次性读取
        /// 针对文件内容很少的
        /// </summary>
        /// <param name="filePath">文件全路径</param>
        /// <returns>文件内容</returns>
        public static string ReadContent(string filePath)
        {
            return File.ReadAllText(filePath);
        }
    }
}
