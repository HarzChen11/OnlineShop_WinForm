namespace OnlineShop.Forms
{
    partial class ShopCarForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
<<<<<<< HEAD
            this.menuBar1 = new OnlineShop.Components.MenuBarComponent.MenuBar();
=======
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            this.SuspendLayout();
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(12, 72);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
<<<<<<< HEAD
            this.flowLayoutPanel1.Size = new System.Drawing.Size(793, 526);
=======
            this.flowLayoutPanel1.Size = new System.Drawing.Size(766, 526);
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("微軟正黑體", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
<<<<<<< HEAD
            this.button1.Location = new System.Drawing.Point(703, 604);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 33);
=======
            this.button1.Location = new System.Drawing.Point(696, 614);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            this.button1.TabIndex = 1;
            this.button1.Text = "送出訂單";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.GetOrder);
            // 
<<<<<<< HEAD
            // menuBar1
            // 
            this.menuBar1.Location = new System.Drawing.Point(12, 11);
            this.menuBar1.Name = "menuBar1";
            this.menuBar1.Size = new System.Drawing.Size(778, 55);
            this.menuBar1.TabIndex = 2;
            // 
=======
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            // ShopCarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
<<<<<<< HEAD
            this.ClientSize = new System.Drawing.Size(1006, 660);
            this.Controls.Add(this.menuBar1);
=======
            this.ClientSize = new System.Drawing.Size(790, 660);
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Name = "ShopCarForm";
            this.Text = "ShopCarForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseCar);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button button1;
<<<<<<< HEAD
        private Components.MenuBarComponent.MenuBar menuBar1;
=======
>>>>>>> 8101e26593e1c25fcacf35b07ec8373dd546f8f2
    }
}