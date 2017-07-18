#region 说明
/* ===============================
* 
* Author：dlli5 Time：2014/9/1 10:33:02 
* File name：VideoConvertHelper 
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
using com.iflysse.helper;

namespace Com.Iflysse.Helper
{
    /// <summary>
    /// 视频转换辅助类
    /// </summary>
    public class VideoConvertHelper
    {
        //文件路径
        public static string ffmpegtool = ConfigHelper.GetValue("ffmpeg");
        public static string mencodertool = ConfigHelper.GetValue("mencoder");
        public static string mplayertool = ConfigHelper.GetValue("mplayer");
        public static string upFile = ConfigHelper.GetValue("upfile") + "/";
        public static string imgFile = ConfigHelper.GetValue("imgfile") + "/";
        public static string playFile = ConfigHelper.GetValue("playfile") + "/";
        //文件图片大小
        public static string sizeOfImg = ConfigHelper.GetValue("CatchFlvImgSize");
        //文件大小
        public static string widthOfFile = ConfigHelper.GetValue("widthSize");
        public static string heightOfFile = ConfigHelper.GetValue("heightSize");

        /// <summary>
        /// 转换成flv命令
        /// {0} 需要转换的文件全路径
        /// {1}宽度 {2}高度 {3}转换后的flv文件全路径
        /// </summary>
        public static string ConvertVideoArgs = @" -i {0} -ab 128 -ar 22050 -b 500 -r 15 -s {1}x{2} {3}";

        /// <summary>
        /// 转换截图的命令
        /// {0}视频文件全路径
        /// {1}
        /// </summary>
        public static string ConvertVideoImageArgs = @" -i {0} -y -f image2 -ss 2 -vframes 1 -s {1} {2}";

        // // //获取文件的名字
        public static string GetFileName(string fileName)
        {
            int i = fileName.LastIndexOf("\\") + 1;
            string Name = fileName.Substring(i);
            return Name;
        }

        //获取文件扩展名
        public static string GetExtension(string fileName)
        {
            int i = fileName.LastIndexOf(".") + 1;

            string Name = fileName.Substring(i);

            return Name;
        }

        /// <summary>
        /// 获取视频时长
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public static long GetTime(string filePath)
        {
            return Int64.MaxValue;
        }

        /// <summary>
        /// 是否有ffmpeg转换服务在运行
        /// </summary>
        /// <returns></returns>
        public static bool HaveJobRuning()
        {
            System.Diagnostics.Process[] processList = System.Diagnostics.Process.GetProcesses();
            foreach (System.Diagnostics.Process process in processList)
            {
                if (process.ProcessName.Contains("ffmpeg"))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 转换文件并保存在指定文件夹下面(这里是绝对路径)
        /// 运行FFMpeg的视频解码，(这里是绝对路径)
        /// </summary>
        /// <param name="fileName">上传视频文件的路径（原文件）</param>
        /// <param name="playFile">转换后的文件的路径（网络播放文件）</param>
        /// <param name="imgFile">从视频文件中抓取的图片路径</param>
        /// <returns>成功:返回图片虚拟地址; 失败:返回空字符串</returns>
        public static void ToFlv(string fileName, string playFile, string imgFile)
        {
            string ffmpeg = ffmpegtool;
            if (!System.IO.File.Exists(ffmpeg))
            {
                throw new Exception("转换工具未找到！");
            }
            if (!System.IO.File.Exists(fileName))
            {
                throw new Exception("待转换的视频未找到！");
            }
            ProcessStartInfo FilestartInfo = new ProcessStartInfo(ffmpeg);
            FilestartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            FilestartInfo.Arguments = string.Format(ConvertVideoArgs, fileName, widthOfFile, heightOfFile, playFile);
            try
            {
                //转换
                Process videoProcess = Process.Start(FilestartInfo);
                //截图
                CatchImg(fileName, imgFile);
                //System.Diagnostics.Process.Start(ImgstartInfo);
                videoProcess.WaitForExit();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="imgFile"></param>
        /// <returns></returns>
        public static string CatchImg(string fileName, string imgFile)
        {
            string ffmpeg = ffmpegtool;
            string flv_img = imgFile + ".jpg";
            string FlvImgSize = sizeOfImg;
            ProcessStartInfo ImgstartInfo = new ProcessStartInfo(ffmpeg);
            ImgstartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            ImgstartInfo.Arguments = " -i " + fileName + " -y -f image2 -ss 2 -vframes 1 -s " + FlvImgSize + " " + flv_img;
            try
            {
                System.Diagnostics.Process.Start(ImgstartInfo);
            }
            catch
            {
                return "";
            }

            //
            if (System.IO.File.Exists(flv_img))
            {
                return flv_img;
            }
            return "";
        }

        /// <summary>
        /// 转换文件并保存在指定文件夹下面(这里是相对路径)
        /// 运行FFMpeg的视频解码，(这里是(虚拟)相对路径)
        /// </summary>
        /// <param name="fileName">上传视频文件的路径（原文件）</param>
        /// <param name="playFile">转换后的文件的路径（网络播放文件）</param>
        /// <param name="imgFile">从视频文件中抓取的图片路径</param>
        /// <returns>成功:返回图片虚拟地址; 失败:返回空字符串</returns>
        public static string ChangeFileVir(string fileName, string playFile, string imgFile)
        {
            //取得ffmpeg.exe的路径,路径配置在Web.Config中,

            //如:<add key="ffmpeg" value="E:\51aspx\ffmpeg.exe" />

            string ffmpeg = ffmpegtool;

            if ((!System.IO.File.Exists(ffmpeg)) || (!System.IO.File.Exists(fileName)))
            {
                return "";
            }

            //获得图片和(.flv)文件相对路径/最后存储到数据库的路径,如:/Web/User1/00001.jpg

            string flv_img = System.IO.Path.ChangeExtension(imgFile, ".jpg");

            string flv_file = System.IO.Path.ChangeExtension(playFile, ".flv");

            //截图的尺寸大小,配置在Web.Config中,如:<add key="CatchFlvImgSize" value="240x180" />

            string FlvImgSize = sizeOfImg;

            ProcessStartInfo FilestartInfo = new ProcessStartInfo(ffmpeg);

            ProcessStartInfo ImgstartInfo = new ProcessStartInfo(ffmpeg);

            FilestartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            ImgstartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;

            //此处组合成ffmpeg.exe文件需要的参数即可,此处命令在ffmpeg 0.4.9调试通过

            //ffmpeg -i F:\01.wmv -ab 56 -ar 22050 -b 500 -r 15 -s 320x240 f:\test.flv

            FilestartInfo.Arguments = " -i " + fileName + " -ab 56 -ar 22050 -b 500 -r 15 -s " + widthOfFile + "x" + heightOfFile + " " + flv_file;

            ImgstartInfo.Arguments = " -i " + fileName + " -y -f image2 -t 0.001 -s " + FlvImgSize + " " + flv_img;

            try
            {
                System.Diagnostics.Process.Start(FilestartInfo);
                System.Diagnostics.Process.Start(ImgstartInfo);
            }
            catch
            {
                return "";
            }

            /**/

            ///注意:图片截取成功后,数据由内存缓存写到磁盘需要时间较长,大概在3,4秒甚至更长;

            ///这儿需要延时后再检测,我服务器延时8秒,即如果超过8秒图片仍不存在,认为截图失败;

            ///此处略去延时代码.如有那位知道如何捕捉ffmpeg.exe截图失败消息,请告知,先谢过!

            if (System.IO.File.Exists(flv_img))
            {
                return flv_img;
            }
            return "";
        }

        /// <summary>
        /// //运行mencoder的视频解码器转换(这里是(绝对路径))
        /// </summary>
        /// <param name="vFileName"></param>
        /// <param name="playFile"></param>
        /// <param name="imgFile"></param>
        /// <returns></returns>
        public static string MChangeFilePhy(string vFileName, string playFile, string imgFile)
        {
            string tool = mencodertool;
            //string mplaytool = Server.MapPath(PublicMethod.ffmpegtool);
            if ((!System.IO.File.Exists(tool)) || (!System.IO.File.Exists(vFileName)))
            {
                return "";
            }
            string flv_file = System.IO.Path.ChangeExtension(playFile, ".flv");
            //截图的尺寸大小,配置在Web.Config中,如:<add key="CatchFlvImgSize" value="240x180" />
            string FlvImgSize = sizeOfImg;
            ProcessStartInfo FilestartInfo = new ProcessStartInfo(tool);
            FilestartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            FilestartInfo.Arguments = " " + vFileName + " -o " +
                flv_file + " -of lavf -lavfoptsi_certify_that_my" +
                "_video_stream_does_not_use_b_frames -oac mp3lame " +
                "-lameopts abr:br=56 -ovc lavc" +
                "-lavcopts vcodec=flv:vbitrate=200:mbd=2:mv0:trell:" +
                "v4mv:cbp:last_pred=1:dia=-1:cmp=0:vb_strategy=1" +
                "-vf scale=" + widthOfFile + ":" + heightOfFile +
                " -ofps 12 -srate 22050";
            try
            {
                System.Diagnostics.Process.Start(FilestartInfo);
                CatchImg(flv_file, imgFile);
            }
            catch
            {
                return "";
            }
            return "";
        }
    }
}
