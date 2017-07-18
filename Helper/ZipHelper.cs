using System;
using System.Collections.Generic;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;
using System.IO;
using ICSharpCode.SharpZipLib.Checksums;

namespace com.iflysse.helper
{
    /// <summary>
    /// FileName: ZipHelper.cs
    /// CLRVersion: 4.0.30319.18408
    /// Author: dlli5
    /// Corporation: 
    /// Description: 
    /// DateTime: 2014/5/19 16:19:29
    /// </summary>
   public class ZipHelper
    {
        public static void GetFileToZip(string filepath, string zippath, string zipName)
        {
            FileStream fs = File.OpenRead(filepath);
            byte[] buffer = new byte[fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            fs.Close();

            FileStream ZipFile = File.Create(zippath);
            ZipOutputStream ZipStream = new ZipOutputStream(ZipFile);
            ZipEntry ZipEntry = new ZipEntry(zipName);
            ZipStream.PutNextEntry(ZipEntry);
            ZipStream.SetLevel(6);

            ZipStream.Write(buffer, 0, buffer.Length);
            ZipStream.Finish();
            ZipStream.Close();
        }

        /// <summary>
        /// 文件压缩为ZIP
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="zipPath">zip路径</param>
        public static void FileToZip(string filePath, string zipPath)
        {
            FileToZip(filePath, zipPath, Path.GetFileName(filePath));
        }

        /// <summary>
        /// 文件转换为ZIP
        /// </summary>
        /// <param name="filePath">文件路径</param>
        /// <param name="zipPath">ZIP路径</param>
        /// <param name="fileName">文件名称</param>
        public static void FileToZip(string filePath, string zipPath, string fileName)
        {
            FileStream StreamToZip = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            FileStream ZipFile = File.Create(zipPath);
            ZipOutputStream ZipStream = new ZipOutputStream(ZipFile);
            //压缩文件
            ZipEntry ZipEntry = new ZipEntry(fileName);
            ZipStream.PutNextEntry(ZipEntry);
            ZipStream.SetLevel(6);
            byte[] buffer = new byte[StreamToZip.Length];
            StreamToZip.Read(buffer, 0, Convert.ToInt32(StreamToZip.Length));
            ZipStream.Write(buffer, 0, Convert.ToInt32(StreamToZip.Length));
            ZipStream.Finish();
            ZipStream.Close();
            StreamToZip.Close();
        }

        /// <summary>
        /// Zip解压为文件
        /// </summary>
        /// <param name="zipPath">zip路径</param>
        /// <param name="uZipPath">解压目录</param>
        public static void ZipToFile(string zipPath, string uZipPath)
        {
            ZipInputStream s = new ZipInputStream(File.OpenRead(zipPath));
            ZipEntry fileEntry;
            while ((fileEntry = s.GetNextEntry()) != null)
            {
                string filename = Path.GetFileName(fileEntry.Name);
                if (filename != "")
                {
                    filename = uZipPath + "\\" + filename;
                    FileStream streamWriter = File.Create(filename);
                    int size = 2048;
                    byte[] buffer = new byte[s.Length];
                    while ((size = s.Read(buffer, 0, size)) != 0)
                    {
                        streamWriter.Write(buffer, 0, size);
                    }
                    streamWriter.Close();
                }
            }
            s.Close();
        }

        /// <summary>
        /// 压缩文件夹
        /// </summary>
        /// <param name="directoryPath">文件夹路径</param>
        /// <param name="zipPath">zip路径</param>
        public static void DirectoryToZip(string directoryPath, string zipPath)
        {
            //获取当前文件夹中所有的文件
            string[] filenames = Directory.GetFiles(directoryPath);
            Crc32 crc = new Crc32();
            //创建输出文件(ZIP格式的文件)
            ZipOutputStream zos = new ZipOutputStream(File.Create(zipPath));
            zos.SetLevel(6);
            //遍历所有的文件
            foreach (string name in filenames)
            {
                FileStream fs = File.OpenRead(name);
                byte[] buffer = new byte[fs.Length];
                //读取文件
                fs.Read(buffer, 0, Convert.ToInt32(fs.Length));
                //获取文件的文件名称和后缀名
                string file = Path.GetFileName(name);
                //输出文件的名称
                ZipEntry entry = new ZipEntry(file);
                crc.Reset();
                crc.Update(buffer);
                entry.Crc = crc.Value;
                zos.PutNextEntry(entry);
                zos.Write(buffer, 0, Convert.ToInt32(fs.Length));
                fs.Close();
            }
            zos.Finish();
            zos.Close();
        }

        //     【【【【【【【【C#读取压缩文件(将压缩文件转换为二进制)】】】】】】】】
        //private void GetZipToByte()
        //{
        //    string path = @"C:\Documents and Settings\Administrator\桌面\文件.rar";
        //    FileStream fs = new FileStream(path, FileMode.Open);
        //    bytes = new byte[fs.Length];
        //    int count = Convert.ToInt32(fs.Length);
        //    fs.Read(bytes, 0, count);
        //}

        ////【【【【【【【【C#将二进制转换为压缩文件】】】】】】】】
        //private void GetByteToZip()
        //{
        //    string path = @"F:\dom.rar";//压缩文件的地址
        //    File.WriteAllBytes(path, bytes);
        //}
    }
}
