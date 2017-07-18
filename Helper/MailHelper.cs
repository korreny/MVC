using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Net.Mail;
using System.Net;
using System.IO;

namespace com.iflysse.helper
{
    public class MailRequestAttachments
    {
        public string FileName { set; get; }

        public byte[] FileData { set; get; }
    }

    /// <summary>
    /// 发送邮件请求
    /// </summary>
    public class MailRequest
    {
        /// <summary>
        /// 发送人，多个人以分号;间隔
        /// </summary>
        public string From { set; get; }

        /// <summary>
        /// 收件人，多个人以分号;间隔
        /// </summary>
        public string To { set; get; }

        /// <summary>
        /// 抄送人，多个人以分号;间隔
        /// </summary>
        public string CC { set; get; }

        /// <summary>
        /// 秘密抄送人，多个人以分号;间隔
        /// </summary>
        public string Bcc { set; get; }

        /// <summary>
        /// 主题
        /// </summary>
        public string Subject { set; get; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Body { set; get; }

        /// <summary>
        /// 附件列表
        /// </summary>
        public List<MailRequestAttachments> Attachments { set; get; }

        /// <summary>
        /// 附件列表
        /// </summary>
        public List<string> AttachPaths { set; get; }
    }

    /// <summary>
    /// FileName: MailHelper.cs
    /// CLRVersion: 4.0.30319.18408
    /// Author: dlli5
    /// Corporation: 
    /// Description: 
    /// DateTime: 2014/5/19 15:02:11
    /// </summary>
    public class MailHelper
    {
        public string From { set; get; }
        public string Pwd { set; get; }
        public string Smtp { set; get; }
        public int Port { set; get; }

        public MailRequest MailRequest { set; get; }

        /// <summary>
        /// 配置文件需要配置邮箱地址
        /// </summary>
        /// <param name="mailRequest"></param>
        public MailHelper(MailRequest mailRequest)
        {
            this.Smtp = ConfigHelper.GetValue("Smtp");
            this.From = ConfigHelper.GetValue("From"); ;
            this.Pwd = ConfigHelper.GetValue("Pwd"); ;
            this.Port = ConfigHelper.GetValueOfInt("Port");
            this.MailRequest = mailRequest;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Psmtp"></param>
        /// <param name="Pfrom"></param>
        /// <param name="Ppwd"></param>
        /// <param name="mailRequest"></param>
        public MailHelper(string Psmtp, string Pfrom, string Ppwd, MailRequest mailRequest)
        {
            this.Smtp = Psmtp;
            this.From = Pfrom;
            this.Pwd = Ppwd;
            this.MailRequest = mailRequest;
        }

        /// <summary>
        /// 调用NetMail的发送邮件方法
        /// </summary>
        /// <returns></returns>
        public void SendNetMail()
        {
            SmtpClient client = new SmtpClient();
            client.Host = this.Smtp;
            client.Port = this.Port;
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(this.From, this.Pwd);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            MailMessage message = new MailMessage(this.From, this.MailRequest.To);
            message.Subject = this.MailRequest.Subject;
            message.Body = this.MailRequest.Body;
            message.IsBodyHtml = true;
            message.BodyEncoding = Encoding.UTF8;

            //附件地址
            if (this.MailRequest.AttachPaths != null && this.MailRequest.AttachPaths.Count != 0)
            {
                foreach (string str in this.MailRequest.AttachPaths)
                {
                    Attachment item = new Attachment(str, "application/octet-stream");
                    message.Attachments.Add(item);
                }
            }

            //附件对象
            if (this.MailRequest.Attachments != null && this.MailRequest.Attachments.Count != 0)
            {
                foreach (MailRequestAttachments att in this.MailRequest.Attachments)
                {
                    Attachment item = new Attachment(ByteArrayToStream(att.FileData), att.FileName);
                    message.Attachments.Add(item);
                }
            }
            client.Send(message);
        }

        #region 私有辅助函数

        /// <summary>
        /// 字节数组转换为流
        /// </summary>
        /// <param name="byteArray">字节数组</param>
        /// <returns>Stream</returns>
        private static Stream ByteArrayToStream(byte[] byteArray)
        {
            MemoryStream mstream = new MemoryStream(byteArray);

            return mstream;
        }

        #endregion
    }
}
