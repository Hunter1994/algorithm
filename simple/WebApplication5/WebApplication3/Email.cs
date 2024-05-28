using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net.Mail;
using System.Net;

namespace WebApplication3
{
    public class Email : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            //实例化一个发送邮件类。
            MailMessage mailMessage = new MailMessage
            {
                //发件人邮箱地址，方法重载不同，可以根据需求自行选择。
                From = new MailAddress("alarm1@ousutec.com.cn")
            };
            //收件人邮箱地址。
            mailMessage.To.Add(new MailAddress(email));
            //邮件标题。
            mailMessage.Subject = subject;
            //邮件内容。
            mailMessage.Body = htmlMessage;
            //实例化一个SmtpClient类。
            SmtpClient client = new SmtpClient();
            //在这里我使用的是qq邮箱，所以是smtp.qq.com，如果你使用的是126邮箱，那么就是smtp.126.com。
            client.Host = "smtp.exmail.qq.com";
            client.Port = 587;
            //使用安全加密连接。
            client.EnableSsl = true;
            //不和请求一块发送。
            client.UseDefaultCredentials = false;
            //验证发件人身份(发件人的邮箱，邮箱里的生成授权码);
            client.Credentials = new NetworkCredential("alarm1@ousutec.com.cn", "Hw0330");
            //发送
            client.Send(mailMessage);
        }
    }
}
