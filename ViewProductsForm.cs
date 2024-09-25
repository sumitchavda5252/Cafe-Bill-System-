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

namespace NewPOS
{
    public partial class ViewProductsForm : Form
    {
        public delegate void AddToViewProductsForm();

        public event AddToViewProductsForm AddProductsEvent;

        public event AddToViewProductsForm AddCategoryEvent;

        public event AddToViewProductsForm AddButtonsOnClosingViewProductsFormEvent; // add category buttons to main form when view products form is closed

        Database1Entities dbe = new Database1Entities();

        byte[] dataProduct;

        byte[] dataCategory;
        public ViewProductsForm()
        {
            InitializeComponent();

            dataGridView1.DataSource = dbe.tblProduct.ToList();
         
            dataGridView1.Columns["categoryId"].Visible = false;
            dataGridView1.Columns["tblCategory"].Visible = false;
            dataGridView1.Columns["tblTransactionItem"].Visible = false;
            dataGridView1.Columns["productId"].Visible = false;

            cmbFilterCategory.DataSource = dbe.tblCategory.ToList();
            cmbFilterCategory.DisplayMember = "CategoryName";
            cmbFilterCategory.ValueMember = "categoryId";

            cmbSelectCategoryAddProduct.DataSource = dbe.tblCategory.ToList();
            cmbSelectCategoryAddProduct.DisplayMember = "CategoryName";
            cmbSelectCategoryAddProduct.ValueMember = "categoryId";
        }

        private void btnViewAllProducts_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = dbe.tblProduct.ToList();
        }

        private void cmbFilterCategory_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var data = from p in dbe.tblProduct where p.categoryId == (int)cmbFilterCategory.SelectedIndex + 1 select p;

            var dataList = data.ToList();

            dataGridView1.DataSource = dataList;
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            try
            {
                tblProduct pro = new tblProduct();

                pro.productName = txtProductName.Text;

                pro.productPrice = decimal.Parse(txtProductPrice.Text);

                pro.categoryId = (int)cmbSelectCategoryAddProduct.SelectedValue;

                pro.productImage = dataProduct;

                dbe.tblProduct.Add(pro);

                dbe.SaveChanges();

                MessageBox.Show("Product Saved");

                AddProductsEvent += ViewProductsForm_AddProductsEvent;

                AddProductsEvent();
            }
            catch
            {
                MessageBox.Show("Something went wrong. Please, fill out all of the fields.");
            }
        }

        void ViewProductsForm_AddProductsEvent()
        {
            dataGridView1.DataSource = dbe.tblProduct.ToList();
        }

        private void btnUploadProductImage_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                dataProduct = new byte[fs.Length];

                fs.Read(dataProduct, 0, dataProduct.Length);

                fs.Close();

                MemoryStream ms = new MemoryStream(dataProduct);

                pbProductImage.Image = Image.FromStream(ms);

                pbProductImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoryName.Text == "")
                {
                    MessageBox.Show("Please fill out all the fields");
                    return;
                }

                tblCategory cat = new tblCategory();

                cat.CategoryName = txtCategoryName.Text;

                cat.categoryImage = dataCategory;

                dbe.tblCategory.Add(cat);

                dbe.SaveChanges();

                MessageBox.Show("Category Saved");

                AddCategoryEvent += ViewProductsForm_AddCategoryEvent;

                AddCategoryEvent();
            }
            catch { }

        }

        void ViewProductsForm_AddCategoryEvent()
        {
            cmbFilterCategory.DataSource = dbe.tblCategory.ToList();
            cmbSelectCategoryAddProduct.DataSource = dbe.tblCategory.ToList();
        }

        private void btnUIploadCategoryImage_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();

            if (dr == DialogResult.OK)
            {
                FileStream fs = new FileStream(openFileDialog1.FileName, FileMode.Open, FileAccess.Read);

                dataCategory = new byte[fs.Length];

                fs.Read(dataCategory, 0, dataCategory.Length);

                fs.Close();

                MemoryStream ms = new MemoryStream(dataCategory);

                pbCategoryImage.Image = Image.FromStream(ms);

                pbCategoryImage.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void ViewProductsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            AddButtonsOnClosingViewProductsFormEvent();
        }



    }
}
