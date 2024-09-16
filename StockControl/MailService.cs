using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace StockControl
{
    internal class MailService
    {
        private static void MailInfo(string htmlTemplate, string subject, string email)
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
            mms.To.Add(new MailAddress(email));

            using (SmtpClient client = new SmtpClient(SmtpServer, SmtpPort))
            {
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential(GoogleID, TempPwd);//寄信帳密 
                client.Send(mms); //寄出信件
            }
        }

        // 追蹤商品補貨通知
        public static void FollowMail(List<FollowModel> follows)
        {
            foreach(var data in follows)
            {
                string htmlTemplate = MailTemplates.FollowMail;
                MailInfo(htmlTemplate, "驗證碼認證", data.Email);
            }

        }

        static class MailTemplates { 
        // 已補貨通知
        public static string FollowMail = @"<!DOCTYPE html>
    <html lang='zh-TW'>
    <head>
    <meta charset='UTF-8'>
    <meta name='viewport' content='width=device-width, initial-scale=1.0'>
    <title>商品補貨通知</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            line-height: 1.6;
            color: #333;
            max-width: 600px;
            margin: 0 auto;
            padding: 20px;
        }
        .header {
            background-color: #f4f4f4;
            padding: 20px;
            text-align: center;
            border-radius: 5px 5px 0 0;
        }
        .content {
            background-color: #ffffff;
            padding: 20px;
            border: 1px solid #ddd;
            border-radius: 0 0 5px 5px;
        }
        .product-image {
            width: 100%;
            max-width: 300px;
            height: auto;
            margin: 20px 0;
            border: 1px solid #ddd;
        }
        .button {
            display: inline-block;
            padding: 10px 20px;
            background-color: #4CAF50;
            color: white;
            text-decoration: none;
            border-radius: 5px;
            margin-top: 20px;
        }
    </style>
    </head>
    <body>
    <div class='header'>
        <h1>您關注的商品已到貨</h1>
    </div>
    <div class='content'>
        <p>親愛的顧客，您好：</p>
        <p>很高興地通知您，您之前關注的商品已經到貨了！</p>
        <p> 數量有限，請盡快下單以免錯過這次機會！</p>
        <p> 如果您有任何問題或需要進一步的協助，請隨時與我們的客戶服務團隊聯繫。</p>
        <p> 感謝您的耐心等待和持續支持！</p>
        <p> 祝您購物愉快！</p>
     </div>
     </body>
     </html>";
    }}
}
