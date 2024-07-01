using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Utility.Templates
{
    internal static class MailTemplates
    {
        // 發票郵件
        public static string InvoiceMail = @"
        <!DOCTYPE html>
        <html lang='zh-TW'>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <title>您的電子發票</title>
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
                .invoice-image {
                    width: 100%;
                    max-width: 500px;
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
                <h1>您的電子發票已開立</h1>
            </div>
            <div class='content'>
                <p>親愛的顧客，您好：</p>
                <p>感謝您的購買。您的電子發票已成功開立，詳細資訊如下圖所示：</p>
                <a href='{InvoiceUrl}' class='button'>查看訂單詳情</a>
                <p>查詢物流請使用此筆訂單編號:{OrderId}。</p>
                <p>如果您有任何問題或需要進一步的協助，請隨時與我們的客戶服務團隊聯繫。</p>
            </div>
        </body>
        </html>";

        // 驗證碼郵件
        public static string NumberMail = @"
        <!DOCTYPE html>
        <html lang='zh-TW'>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <title>會員驗證碼</title>
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
                    background-color: #4a90e2;
                    color: white;
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
                .verification-code {
                    font-size: 36px;
                    font-weight: bold;
                    text-align: center;
                    letter-spacing: 5px;
                    margin: 20px 0;
                    padding: 10px;
                    background-color: #f0f0f0;
                    border-radius: 5px;
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
                <h1>會員驗證碼</h1>
            </div>
            <div class='content'>
                <p>親愛的會員，您好：</p>
                <p>感謝您註冊我們的服務。請使用以下驗證碼完成您的註冊流程：</p>
                <div class='verification-code'> {verificationCode} </div>
                <p>請在註冊頁面輸入此驗證碼以確認您的帳戶。</p>
                <p>如果您沒有嘗試註冊我們的服務，請忽略此郵件。</p>
                <p>驗證碼將在30分鐘後失效。如果您需要新的驗證碼，請重新申請。</p>
                <p>如有任何問題，請隨時與我們的客戶服務團隊聯繫。</p>
                <p>祝您使用愉快！</p>
            </div>
        </body>
        </html>";

        // 取貨通知郵件
        public static string pickUpMail = @"
        <!DOCTYPE html>
        <html lang='zh-TW'>
        <head>
            <meta charset='UTF-8'>
            <meta name='viewport' content='width=device-width, initial-scale=1.0'>
            <title>商品到貨通知</title>
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
                <h1>您的商品已到貨</h1>
            </div>
            <div class='content'>
                <p>親愛的顧客，您好：</p>
                <p>我們很高興地通知您，您訂購的商品已經到貨。</p>
                <p>取貨資訊如下：</p>
                <ul>
                    <li>訂單編號：{OrderId}</li>
                </ul>
                <p>感謝您的購買，期待您再次光臨！</p>
            </div>
        </body>
        </html>
        ";
     }
}
