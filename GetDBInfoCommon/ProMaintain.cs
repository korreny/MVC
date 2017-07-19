using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;
using System.Reflection;

namespace GetDBInfo.Common
{
    //用于提供维护程序的一些操作

    static public class ProMaintain
    {
        #region 写日志
        /// <summary>
        /// 用于写日志
        /// </summary>
        /// <param name="content">日志的内容</param>
        public static void Writelog(string content)
        {
            string path = ConfigurationManager.AppSettings["LogPath"];
            FileStream fs = new FileStream(path, FileMode.Append);
            StreamWriter sw = new StreamWriter(fs);
            //开始写入
            sw.Write(content+"\r\n");
            //清空缓冲区
            sw.Flush();
            //关闭流
            sw.Close();
            fs.Close();
        }
        #endregion

        #region 修改app.config

        /// <summary>
        /// 修改app.config文件
        /// </summary>
        /// <param name="key"></param>
        /// <param name="values"></param>
        public static void ChangeConfiguration(string key, string values)
        {

            //读取程序集的配置文件
            string assemblyConfigFile = Assembly.GetEntryAssembly().Location;
            string appDomainConfigFile = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile;

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            //获取appSettings节点
            AppSettingsSection appSettings = (AppSettingsSection)config.GetSection("appSettings");

            //删除name，然后添加新值
            appSettings.Settings.Remove(key);
            appSettings.Settings.Add(key, values);

            //保存配置文件
            config.Save();
            ConfigurationManager.RefreshSection("system.serviceModel/behaviors");

            ConfigurationManager.RefreshSection("system.serviceModel/bindings");

            ConfigurationManager.RefreshSection("system.serviceModel/client");

            ConfigurationManager.RefreshSection("system.serviceModel/services");
        }
        #endregion

    }
}
