using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnlineShop.Components.PagenationComponent
{
    public partial class Pagenation : UserControl
    {
        
        int PageIndex;
        PagenationService service = null;
        public EventHandler<int> ChangedPage;
        public int TotalCount
        {
            set
            {
                InitPagination(value);

            }
        }


        public Pagenation()
        {
            InitializeComponent();
            InitPagination(0);
            //Console.WriteLine(flowLayoutPanel1.Controls[0].Text);
        }


        private void InitPagination(int total)
        {
            if (total == 0)
                return;
            this.flowLayoutPanel1.Controls.Clear();
            service = new PagenationService(total);
            List<int> pages = service.RenderPages(PageAction.Init);
            foreach (int page in pages)
            {
                Label label = new Label();
                label.Text = page.ToString();
                label.Width = 20;
                this.flowLayoutPanel1.Controls.Add(label);
                label.Click += numberClick;
            }
            this.flowLayoutPanel1.Controls[0].ForeColor = Color.Red;
            PageIndex = int.Parse(this.flowLayoutPanel1.Controls[0].Text);

        }




        private void numberClick(object sender, EventArgs e)
        {
            Label label = (Label)sender;

            foreach (Label label1 in flowLayoutPanel1.Controls)
            {
                label1.ForeColor = Color.Black;
            }
            label.ForeColor = Color.Red;
            PageIndex = int.Parse(label.Text);
            service.ChangePageNumber(PageIndex);
            ChangedPage(this, PageIndex);
        }


        private void creatLabel(int i)
        {
            Label label = new Label();
            label.Text = i.ToString();
            label.Width = 20;
            flowLayoutPanel1.Controls.Add(label);
            label.Click += numberClick;
        }

        private void CheckPage(object sender, EventArgs e)
        {
            
            Button button = (Button)sender;
            if (button.Text == "下一頁")
            {

                var res = service.ChangePage(PageAction.Next);
                ChangedPage(this, res.Item2);
                if (res.Item1)
                {
                    List<int> pages = service.RenderPages(PageAction.Next);
                    flowLayoutPanel1.Controls.Clear();
                    foreach (int page in pages)
                    {
                        Label label = new Label();
                        label.Text = page.ToString();
                        label.Width = 20;
                        this.flowLayoutPanel1.Controls.Add(label);
                        label.Click += numberClick;
                    }
                    this.flowLayoutPanel1.Controls[0].ForeColor = Color.Red;
                }
                else
                {

                    foreach (Label label in flowLayoutPanel1.Controls)
                    {
                        label.ForeColor = Color.Black;

                    }

                    int number = (res.Item2 % 10 == 0) ? 9 : (res.Item2 % 10) - 1;
                    this.flowLayoutPanel1.Controls[number].ForeColor = Color.Red;


                    // 0 1 2 3 4 5 6 7 8  9

                    // 1 2 3 4 5 6 7 8 9 10
                    // 11 12 13 14 15 16 17 18 19 20
                    // 21 22 23 24 25 26 27 28 29 30
                    // 31 32 33 34 35 36 37 38 39 40


                }
            }
            else
            {
                if (button.Text == "上一頁")
                {
                    var res = service.ChangePage(PageAction.Previous);
                    ChangedPage(this, res.Item2);
                    if (res.Item1)
                    {
                        flowLayoutPanel1.Controls.Clear();
                        List<int> pages = service.RenderPages(PageAction.Previous);
                        foreach (var page in pages)
                        {
                            Label label = new Label();
                            label.Text = page.ToString();
                            label.Width = 20;
                            this.flowLayoutPanel1.Controls.Add(label);
                            label.Click += numberClick;
                        }
                        this.flowLayoutPanel1.Controls[9].ForeColor = Color.Red;
                    }
                    else
                    {
                        foreach (Label label in flowLayoutPanel1.Controls)
                        {
                            label.ForeColor = Color.Black;
                        }
                        int number = (res.Item2 % 10 == 0) ? 9 : (res.Item2 % 10) - 1;
                        this.flowLayoutPanel1.Controls[number].ForeColor = Color.Red;
                    }
                }


            }
        }


    }



}
