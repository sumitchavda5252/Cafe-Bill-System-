using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Printing;

namespace NewPOS
{
    public partial class Form1 : Form
    {
        Database1Entities dbe = new Database1Entities();

        BindingList<tblProduct> products = new BindingList<tblProduct>();

        byte[] dataProduct;

        byte[] dataCategory;
        public Form1()
        {
            InitializeComponent();

            lbProductsToBuy.DataSource = products;

            AddButtons();
        }

        private decimal total;

        public decimal Total
        {
            get { return total; }
            set
            {
                total = value;
                txtTotal.Text = String.Format("{0:c}", total);
            }
        }

        private void AddButtons()
        {
            try
            {
                foreach (tblCategory cat in dbe.tblCategory)
                {
                    Button btn = new Button();
                    btn.Text = cat.CategoryName;
                    btn.Size = new System.Drawing.Size(100, 100);
                    btn.ForeColor = Color.White;
                    

                    dataCategory = cat.categoryImage;
                    MemoryStream ms = new MemoryStream(dataCategory);
                    btn.Image = Image.FromStream(ms);
                    btn.Image = ResizeImage(btn.Image, btn.Size);

                    btn.Tag = cat.categoryId;
                    flpCategories.Controls.Add(btn);
                    this.Controls.Add(flpCategories);
                    btn.Click += btn_Click;
                }
            }
            catch 
            {
            }

        }

        private static Image ResizeImage(Image image, Size size)
        {
            Image img = new Bitmap(image, size);

            return img;
        }

        void btn_Click(object sender, EventArgs e)
        {
            try
            {
                List<Control> listControls = flpProducts.Controls.Cast<Control>().ToList();

                foreach (Control control in listControls)
                {
                    flpProducts.Controls.Remove(control);
                    control.Dispose();
                }

                Button b = (Button)sender;

                int categoryID = (int)b.Tag;

                var query = from p in dbe.tblProduct where p.categoryId == categoryID select p;

                var queryList = query.ToList();

                if (query == null)
                {
                    MessageBox.Show("Test");
                }
                else
                {
                    foreach (tblProduct pro in queryList)
                    {
                        Button btn = new Button();
                        btn.Text = pro.productName;
                        btn.Size = new System.Drawing.Size(100, 100);
                        btn.ForeColor = Color.White;

                        dataProduct = pro.productImage;
                        MemoryStream ms = new MemoryStream(dataProduct);
                        btn.Image = Image.FromStream(ms);
                        btn.Image = ResizeImage(btn.Image, btn.Size);

                        flpProducts.Controls.Add(btn);
                        this.Controls.Add(flpProducts);
                        btn.Click += btn_Click2;
                        btn.Tag = pro;
                    }
                }
            }
            catch { }
        }

        void btn_Click2(object sender, EventArgs e)
        {
            try
            {
                Button b = (Button)sender;

                tblProduct tp = (tblProduct)b.Tag;

                string product = tp.productName;

                txtDisplay.Text = product;

                products.Add(tp);

                total += (decimal)tp.productPrice;

                txtTotal.Text = String.Format("{0:c}", total);
            }
            catch { }
        }

        private void lbProductsToBuy_Format(object sender, ListControlConvertEventArgs e)
        {
            try
            {
                if (((tblProduct)e.ListItem) == null)
                    return;
                string ProductName = ((tblProduct)e.ListItem).productName;

                string Price = String.Format("{0:c}", ((tblProduct)e.ListItem).productPrice);

                string ProductNamePadded = ProductName.PadRight(45);

                e.Value = ProductNamePadded + Price;
            }
            catch
            {
            }
        }

        private void lbProductsToBuy_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string selectedItem = lbProductsToBuy.GetItemText(lbProductsToBuy.SelectedItem);

                txtDisplay.Text = selectedItem.Remove(selectedItem.Length - 15);
            }
            catch
            { 
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                tblProduct selected = (tblProduct)(lbProductsToBuy.SelectedItem);
                if (selected == null)
                    return;
                Total -= (decimal)selected.productPrice;

                products.Remove(selected);
            }
            catch
            {
                MessageBox.Show("Nothing to delete !");
            }
        }

        private void btnViewProducts_Click(object sender, EventArgs e)
        {
            ViewProductsForm vpf1 = new ViewProductsForm();

            vpf1.AddButtonsOnClosingViewProductsFormEvent += vpf1_AddButtonsOnClosingViewProductsFormEvent;

            vpf1.Show();
        }

        void vpf1_AddButtonsOnClosingViewProductsFormEvent()
        {
            List<Control> listControls = flpCategories.Controls.Cast<Control>().ToList();

            foreach (Control control in listControls)
            {
                flpCategories.Controls.Remove(control);
                control.Dispose();
            }

            AddButtons();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (Total == 0)
                {
                    MessageBox.Show("Nothing to pay!");
                    return;
                }
                PayForm pf1 = new PayForm();

                pf1.AmountToPay = Total;

                pf1.PayedEv += pf1_PayedEv;

                pf1.ShowDialog();
            }
            catch { }
        }

        void pf1_PayedEv()
        {
            tblTransaction transaction = new tblTransaction();

            transaction.transactionDate = System.DateTime.Now;

            foreach (tblProduct prod in products)
            {
                transaction.tblTransactionItem.Add(new tblTransactionItem() { productId = prod.productId });
            }

            dbe.tblTransaction.Add(transaction);

            dbe.SaveChanges();

            //MessageBox.Show("Success");

            Print();
            txtTotal.Text = "Total";
            lbProductsToBuy.DataSource = null;
            lbProductsToBuy.Items.Clear();
        }

        private void Print()
        {
            try
            {
                PrintDialog pDialog = new PrintDialog();

                PrintDocument pDocument = new PrintDocument();

                pDialog.Document = pDocument;

                pDocument.PrintPage += pDocument_PrintPage;

                DialogResult dr = pDialog.ShowDialog();

                if (dr == DialogResult.OK)
                {
                    pDocument.Print();
                }
            }
            catch { }
        }

        void pDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            try
            {
                Graphics graph = e.Graphics;

                Font fontWelcome = new Font("Courier New", 18);

                Font fontProducts = new Font("Courier New", 12);

                SolidBrush sb = new SolidBrush(Color.DarkGray);

                int x = 10;
                int y = 10;
                int spacing = 40;

                graph.DrawString("Welcome to the New Caffe", fontWelcome, sb, x, y);

                string message = lblHello.Text;

                graph.DrawString(message, fontProducts, sb, x, y + 30);

                foreach (tblProduct pr in products)
                {
                    string product = pr.productName.PadRight(30);
                    string price = String.Format("{0:c}", pr.productPrice);
                    string together = product + price;

                    graph.DrawString(together, fontProducts, sb, x, y + spacing + 30);

                    spacing = spacing + 20;
                }

                spacing = spacing + 20;

                string totalToPay = ("Total:".PadRight(30) + String.Format("{0:c}", Total));

                graph.DrawString(totalToPay, fontProducts, sb, x, y + spacing + 20);
            }
            catch { }
        }

    }
}
