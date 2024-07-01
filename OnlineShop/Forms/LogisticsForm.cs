using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShop.Forms
{
    public partial class LogisticsForm : Form
    {
        string html;
        public LogisticsForm(string html)
        {
            InitializeComponent();
            this.html=html; 
            InitBrowser();
        }

        private async void InitBrowser()
        {
            await webView21.EnsureCoreWebView2Async(); // 初始化webView21
            Thread.Sleep(1000);
            webView21.CoreWebView2.NavigateToString(html);
            this.Show();
        }

        private void DoneLogistics_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void SendLogistics_Click()
        {

        }
    }
}
