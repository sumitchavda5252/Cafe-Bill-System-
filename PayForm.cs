using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NewPOS
{
    public partial class PayForm : Form
    {
        Database1Entities dbe = new Database1Entities();

        public delegate void PayedEvent();

        public event PayedEvent PayedEv;
        public PayForm()
        {
            InitializeComponent();
        }

        private decimal amountToPay;
        public decimal AmountToPay
        {
            get { return amountToPay; }
            set
            {
                amountToPay = value;
                txtAmountToPay.Text = String.Format("{0:c}", amountToPay);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtPaymentAmount.Text == "")
                {
                    MessageBox.Show("Fill out the given amount");
                    return;
                }
                decimal total = 0;
                string RemovedCurrency = (txtAmountToPay.Text).Remove(0,1);
            
                total = decimal.Parse(RemovedCurrency) - decimal.Parse(txtPaymentAmount.Text);
                //MessageBox.Show(total.ToString());
                //return;
                if (total > 0)
                {
                    txtAmountToPay.Text = String.Format("{0:c}", total);
                }
                else
                {
                    MessageBox.Show("Change to give: " + String.Format("{0:c}", -total));
                    this.Dispose();
                    PayedEv();
                }
            }
            catch 
            {
                //MessageBox.Show("An Error Occured");
            }
}

    }
    
}
