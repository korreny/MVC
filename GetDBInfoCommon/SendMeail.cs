using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
namespace GetDBInfo.Common
{
    /// <summary>
    /// 创建时间:2017年7月20日10:18:53
    /// 作者:hello
    /// 功能:提供发邮件
    /// </summary>
    public static class SendMeail
    {
        static string fromname = ConfigurationManager.AppSettings["fmName"];
        static string frompwd = ConfigurationManager.AppSettings["fmPwd"];
        static string toname = ConfigurationManager.AppSettings["toName"];
        public static int SendMsg(string content)
        {
            try
            {
                //确定smtp服务器地址。实例化一个Smtp客户端
                System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient("smtp.163.com");

                //构造一个发件人地址对象
                MailAddress from = new MailAddress(fromname, "hello", Encoding.UTF8);
                //构造一个收件人地址对象
                MailAddress to = new MailAddress(toname, "hello", Encoding.UTF8);

                //构造一个Email的Message对象
                MailMessage message = new MailMessage(from, to);

                //为 message 添加附件

                //添加邮件主题和内容
                message.Subject = "GetDBInfo";
                message.SubjectEncoding = Encoding.UTF8;
                message.Body = content;
                message.BodyEncoding = Encoding.UTF8;

                //设置邮件的信息
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = false;

                //如果服务器支持安全连接，则将安全连接设为true。
                //gmail支持，163不支持，如果是gmail则一定要将其设为true
                //if (cmbBoxSMTP.SelectedText == "smpt.163.com")
                //    client.EnableSsl = false;
                //else

                client.EnableSsl = true;

                //设置用户名和密码。
                //string userState = message.Subject;
                client.UseDefaultCredentials = false;
                //用户登陆信息
                client.UseDefaultCredentials = true;
                System.Net.NetworkCredential myCredentials = new NetworkCredential(fromname, frompwd);
                client.Credentials = myCredentials;
                //发送邮件
                client.Send(message);
                //提示发送成功
                return 1;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
    }
}
