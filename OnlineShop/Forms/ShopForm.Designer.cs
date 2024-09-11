namespace OnlineShop
{
    partial class ShopForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
<<<<<<< HEAD
            this.menuBar2 = new OnlineShop.Components.MenuBarComponent.MenuBar();
=======
            this.menuBar1 = new OnlineShop.Components.MenuBarComponent.MenuBar();
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            this.pagenation1 = new OnlineShop.Components.PagenationComponent.Pagenation();
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
<<<<<<< HEAD
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 141);
=======
            this.flowLayoutPanel1.Location = new System.Drawing.Point(4, 107);
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(719, 635);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
<<<<<<< HEAD
            this.label1.Location = new System.Drawing.Point(9, 95);
=======
            this.label1.Location = new System.Drawing.Point(9, 73);
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "搜尋框 :";
            // 
            // textBox1
            // 
<<<<<<< HEAD
            this.textBox1.Location = new System.Drawing.Point(68, 93);
=======
            this.textBox1.Location = new System.Drawing.Point(68, 71);
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 22);
            this.textBox1.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
<<<<<<< HEAD
            this.button1.Location = new System.Drawing.Point(191, 89);
=======
            this.button1.Location = new System.Drawing.Point(191, 67);
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 30);
            this.button1.TabIndex = 4;
            this.button1.Text = "搜尋";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
<<<<<<< HEAD
            this.label2.Location = new System.Drawing.Point(251, 95);
=======
            this.label2.Location = new System.Drawing.Point(251, 73);
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 19);
            this.label2.TabIndex = 5;
            this.label2.Text = "類型:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "經典五折傘",
            "超輕細碳纖維折傘",
            "極致扁薄折傘",
            "入門款自動開收傘",
            "極穩固自動開收傘",
            "雙人大傘面自動開收傘",
            "安全機制自動開收傘",
            "手動式直立傘",
            "半自動直立傘",
            "托特包",
            "後背包",
            "肩背包",
            "皮夾/零錢/鑰匙包"});
<<<<<<< HEAD
            this.comboBox1.Location = new System.Drawing.Point(293, 95);
=======
            this.comboBox1.Location = new System.Drawing.Point(293, 73);
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(117, 20);
            this.comboBox1.TabIndex = 6;
            // 
<<<<<<< HEAD
            // menuBar2
            // 
            this.menuBar2.Location = new System.Drawing.Point(46, 12);
            this.menuBar2.Name = "menuBar2";
            this.menuBar2.Size = new System.Drawing.Size(807, 55);
            this.menuBar2.TabIndex = 8;
            // 
            // pagenation1
            // 
            this.pagenation1.Location = new System.Drawing.Point(106, 781);
=======
            // menuBar1
            // 
            this.menuBar1.Location = new System.Drawing.Point(591, 12);
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.Size = new System.Drawing.Size(300, 55);
            this.menuBar1.TabIndex = 7;
            // 
            // pagenation1
            // 
            this.pagenation1.Location = new System.Drawing.Point(106, 747);
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            this.pagenation1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pagenation1.Name = "pagenation1";
            this.pagenation1.Size = new System.Drawing.Size(510, 59);
            this.pagenation1.TabIndex = 0;
            // 
            // ShopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(947, 844);
            this.Controls.Add(this.menuBar2);
=======
            this.ClientSize = new System.Drawing.Size(913, 844);
            this.Controls.Add(this.menuBar1);
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.pagenation1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ShopForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Components.PagenationComponent.Pagenation pagenation1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
<<<<<<< HEAD
        private Components.MenuBarComponent.MenuBar menuBar2;
=======
        private Components.MenuBarComponent.MenuBar menuBar1;
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
    }
}

