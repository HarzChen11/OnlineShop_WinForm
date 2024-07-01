namespace LogisticsControl
{
    partial class Search
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.PickUP_Button = new System.Windows.Forms.Button();
            this.Store_Button = new System.Windows.Forms.Button();
            this.Center_Button = new System.Windows.Forms.Button();
            this.UnPickUp = new System.Windows.Forms.Button();
            this.Send_Button = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.Location = new System.Drawing.Point(111, 486);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 19);
            this.label2.TabIndex = 12;
            this.label2.Text = "結果：";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(248, 377);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(424, 27);
            this.textBox1.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.Location = new System.Drawing.Point(111, 380);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 19);
            this.label1.TabIndex = 10;
            this.label1.Text = "物流狀態查詢：";
            // 
            // PickUP_Button
            // 
            this.PickUP_Button.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.PickUP_Button.Location = new System.Drawing.Point(666, 139);
            this.PickUP_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PickUP_Button.Name = "PickUP_Button";
            this.PickUP_Button.Size = new System.Drawing.Size(126, 89);
            this.PickUP_Button.TabIndex = 9;
            this.PickUP_Button.Text = "消費者成功取件";
            this.PickUP_Button.UseVisualStyleBackColor = true;
            this.PickUP_Button.Click += new System.EventHandler(this.PickUp_Button_Click);
            // 
            // Store_Button
            // 
            this.Store_Button.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Store_Button.Location = new System.Drawing.Point(466, 139);
            this.Store_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Store_Button.Name = "Store_Button";
            this.Store_Button.Size = new System.Drawing.Size(150, 89);
            this.Store_Button.TabIndex = 8;
            this.Store_Button.Text = "商品已送達門市";
            this.Store_Button.UseVisualStyleBackColor = true;
            this.Store_Button.Click += new System.EventHandler(this.Store_Button_Click);
            // 
            // Center_Button
            // 
            this.Center_Button.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Center_Button.Location = new System.Drawing.Point(304, 139);
            this.Center_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Center_Button.Name = "Center_Button";
            this.Center_Button.Size = new System.Drawing.Size(112, 89);
            this.Center_Button.TabIndex = 7;
            this.Center_Button.Text = "抵達物流中心";
            this.Center_Button.UseVisualStyleBackColor = true;
            this.Center_Button.Click += new System.EventHandler(this.Center_Button_Click);
            // 
            // UnPickUp
            // 
            this.UnPickUp.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.UnPickUp.Location = new System.Drawing.Point(843, 139);
            this.UnPickUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UnPickUp.Name = "UnPickUp";
            this.UnPickUp.Size = new System.Drawing.Size(165, 89);
            this.UnPickUp.TabIndex = 13;
            this.UnPickUp.Text = "消費者七天未取件";
            this.UnPickUp.UseVisualStyleBackColor = true;
            this.UnPickUp.Click += new System.EventHandler(this.UnPickUp_Click);
            // 
            // Send_Button
            // 
            this.Send_Button.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Send_Button.Location = new System.Drawing.Point(141, 139);
            this.Send_Button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Send_Button.Name = "Send_Button";
            this.Send_Button.Size = new System.Drawing.Size(112, 89);
            this.Send_Button.TabIndex = 14;
            this.Send_Button.Text = "已出貨";
            this.Send_Button.UseVisualStyleBackColor = true;
            this.Send_Button.Click += new System.EventHandler(this.Send_Button_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.button1.Location = new System.Drawing.Point(753, 368);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(69, 43);
            this.button1.TabIndex = 15;
            this.button1.Text = "查詢";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label3.Location = new System.Drawing.Point(300, 486);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 19);
            this.label3.TabIndex = 16;
            this.label3.Text = "-";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1191, 747);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Send_Button);
            this.Controls.Add(this.UnPickUp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PickUP_Button);
            this.Controls.Add(this.Store_Button);
            this.Controls.Add(this.Center_Button);
            this.Font = new System.Drawing.Font("微軟正黑體", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Search";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button PickUP_Button;
        private System.Windows.Forms.Button Store_Button;
        private System.Windows.Forms.Button Center_Button;
        private System.Windows.Forms.Button UnPickUp;
        private System.Windows.Forms.Button Send_Button;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
    }
}

