namespace NewPOS
{
    partial class Form1
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
            this.flpProducts = new System.Windows.Forms.FlowLayoutPanel();
            this.flpCategories = new System.Windows.Forms.FlowLayoutPanel();
            this.lbProductsToBuy = new System.Windows.Forms.ListBox();
            this.txtDisplay = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnViewProducts = new System.Windows.Forms.Button();
            this.lblHello = new System.Windows.Forms.Label();
            this.btnPay = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flpProducts
            // 
            this.flpProducts.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flpProducts.Location = new System.Drawing.Point(16, 118);
            this.flpProducts.Margin = new System.Windows.Forms.Padding(4);
            this.flpProducts.Name = "flpProducts";
            this.flpProducts.Size = new System.Drawing.Size(727, 317);
            this.flpProducts.TabIndex = 0;
            // 
            // flpCategories
            // 
            this.flpCategories.BackColor = System.Drawing.SystemColors.ControlDark;
            this.flpCategories.Location = new System.Drawing.Point(16, 443);
            this.flpCategories.Margin = new System.Windows.Forms.Padding(4);
            this.flpCategories.Name = "flpCategories";
            this.flpCategories.Size = new System.Drawing.Size(727, 201);
            this.flpCategories.TabIndex = 1;
            // 
            // lbProductsToBuy
            // 
            this.lbProductsToBuy.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lbProductsToBuy.FormattingEnabled = true;
            this.lbProductsToBuy.ItemHeight = 16;
            this.lbProductsToBuy.Location = new System.Drawing.Point(767, 118);
            this.lbProductsToBuy.Margin = new System.Windows.Forms.Padding(4);
            this.lbProductsToBuy.Name = "lbProductsToBuy";
            this.lbProductsToBuy.Size = new System.Drawing.Size(509, 388);
            this.lbProductsToBuy.TabIndex = 2;
            this.lbProductsToBuy.SelectedIndexChanged += new System.EventHandler(this.lbProductsToBuy_SelectedIndexChanged);
            this.lbProductsToBuy.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.lbProductsToBuy_Format);
            // 
            // txtDisplay
            // 
            this.txtDisplay.Font = new System.Drawing.Font("Courier New", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtDisplay.Location = new System.Drawing.Point(767, 27);
            this.txtDisplay.Margin = new System.Windows.Forms.Padding(4);
            this.txtDisplay.Multiline = true;
            this.txtDisplay.Name = "txtDisplay";
            this.txtDisplay.Size = new System.Drawing.Size(509, 71);
            this.txtDisplay.TabIndex = 3;
            this.txtDisplay.Text = "Product";
            // 
            // txtTotal
            // 
            this.txtTotal.Font = new System.Drawing.Font("Courier New", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(767, 523);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotal.Multiline = true;
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(261, 80);
            this.txtTotal.TabIndex = 4;
            this.txtTotal.Text = "Total";
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnDelete.Location = new System.Drawing.Point(1036, 523);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(112, 81);
            this.btnDelete.TabIndex = 5;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnViewProducts
            // 
            this.btnViewProducts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnViewProducts.Location = new System.Drawing.Point(471, 27);
            this.btnViewProducts.Margin = new System.Windows.Forms.Padding(4);
            this.btnViewProducts.Name = "btnViewProducts";
            this.btnViewProducts.Size = new System.Drawing.Size(272, 71);
            this.btnViewProducts.TabIndex = 6;
            this.btnViewProducts.Text = "View Products or Add a New One";
            this.btnViewProducts.UseVisualStyleBackColor = false;
            this.btnViewProducts.Click += new System.EventHandler(this.btnViewProducts_Click);
            // 
            // lblHello
            // 
            this.lblHello.AutoSize = true;
            this.lblHello.BackColor = System.Drawing.Color.AntiqueWhite;
            this.lblHello.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblHello.Location = new System.Drawing.Point(12, 9);
            this.lblHello.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHello.Name = "lblHello";
            this.lblHello.Size = new System.Drawing.Size(0, 21);
            this.lblHello.TabIndex = 7;
            // 
            // btnPay
            // 
            this.btnPay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnPay.Location = new System.Drawing.Point(1156, 523);
            this.btnPay.Margin = new System.Windows.Forms.Padding(4);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(120, 81);
            this.btnPay.TabIndex = 8;
            this.btnPay.Text = "Pay";
            this.btnPay.UseVisualStyleBackColor = false;
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(31, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(410, 35);
            this.label1.TabIndex = 9;
            this.label1.Text = "Welcome to the New Cafe !";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkGray;
            this.ClientSize = new System.Drawing.Size(1295, 666);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.lblHello);
            this.Controls.Add(this.btnViewProducts);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtDisplay);
            this.Controls.Add(this.lbProductsToBuy);
            this.Controls.Add(this.flpCategories);
            this.Controls.Add(this.flpProducts);
            this.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Cafe";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpProducts;
        private System.Windows.Forms.FlowLayoutPanel flpCategories;
        private System.Windows.Forms.ListBox lbProductsToBuy;
        private System.Windows.Forms.TextBox txtDisplay;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnViewProducts;
        public System.Windows.Forms.Label lblHello;
        private System.Windows.Forms.Button btnPay;
        private System.Windows.Forms.Label label1;
    }
}

