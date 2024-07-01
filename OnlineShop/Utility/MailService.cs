using OnlineShop.Models;
using OnlineShop.Models.Entities;
using OnlineShop.Utility.Templates;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;

namespace OnlineShop.Utility
{
    public class MailService
    {
        private static void mailInfo(string htmlTemplate, string subject, string customerMail)
        {
            // 使用 Google Mail Server 發信
            string GoogleID = "qwe07081259@gmail.com"; //Google 發信帳號
            string TempPwd = "htfa mhai mgvh kvla"; //應用程式密碼
            //string ReceiveMail = CustomerMail; //接收信箱

            string SmtpServer = "smtp.gmail.com";
            int SmtpPort = 587;
            MailMessage mms = new MailMessage();
            mms.From = new MailAddress(GoogleID);
            mms.Subject = subject;
            mms.Body = htmlTemplate;
            mms.IsBodyHtml = true;
            mms.SubjectEncoding = Encoding.UTF8;
            mms.To.Add(new MailAddress(customerMail));
            using (SmtpClient client = new SmtpClient(SmtpServer, SmtpPort))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(GoogleID, TempPwd);//寄信帳密 
                client.Send(mms); //寄出信件
            }
        }

        public static void mailInfo(string htmlTemplate, string subject, List<string> Emails)
        {
            // 使用 Google Mail Server 發信
            string GoogleID = "qwe07081259@gmail.com"; //Google 發信帳號
            string TempPwd = "htfa mhai mgvh kvla"; //應用程式密碼
            //string ReceiveMail = CustomerMail; //接收信箱

            string SmtpServer = "smtp.gmail.com";
            int SmtpPort = 587;
            MailMessage mms = new MailMessage();
            mms.From = new MailAddress(GoogleID);
            mms.Subject = subject;
            mms.Body = htmlTemplate;
            mms.IsBodyHtml = true;
            mms.SubjectEncoding = Encoding.UTF8;
            foreach (var email in Emails)
            {
                mms.To.Add(new MailAddress(email));
            }
            using (SmtpClient client = new SmtpClient(SmtpServer, SmtpPort))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(GoogleID, TempPwd);//寄信帳密 
                client.Send(mms); //寄出信件
            }
        }

        public static void SendInvoiceMail(string CustomerMail, string InvoiceUrl)
        {
            string htmlTemplate = MailTemplates.InvoiceMail;
            htmlTemplate = htmlTemplate.Replace("{InvoiceUrl}", InvoiceUrl);
            htmlTemplate = htmlTemplate.Replace("{OrderId}", OrderModel.OrderId.ToString());

            mailInfo(htmlTemplate, "發票開立通知", CustomerMail);
        }

        public static void SendNumberMail(string CustomerMail, string password)
        {

            string htmlTemplate = MailTemplates.pickUpMail;
            htmlTemplate = htmlTemplate.Replace("{OrderId}", password);

            mailInfo(htmlTemplate, "驗證碼認證", CustomerMail);


        }

        public static void SendPickUpMail(Dictionary<string, string> orderInfo)
        {
            var phone = orderInfo.Keys.FirstOrDefault();
            var orderId = orderInfo[phone];
            DataBase data = new DataBase();
            var cus = data.Customer.Where(x => x.Phone == phone).FirstOrDefault();
            string htmlTemplate = MailTemplates.pickUpMail;

            htmlTemplate = htmlTemplate.Replace("{OrderId}", orderId.ToString());


            mailInfo(htmlTemplate, "到貨通知", cus.Email);
        }
    }
}
