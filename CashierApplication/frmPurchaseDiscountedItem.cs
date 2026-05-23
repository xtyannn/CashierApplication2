using System;
using System.Windows.Forms;
using ItemNamespace;
using UserAccountNamespace;

namespace CashierApplication
{
    public partial class frmPurchaseDiscountedItem : Form
    {
        private DiscountedItem item;
        private Cashier activeCashier;
        private Form loginFormInstance;

        public frmPurchaseDiscountedItem(Cashier user, Form backReference)
        {
            InitializeComponent();
            this.activeCashier = user;
            this.loginFormInstance = backReference;
        }

        private void frmPurchaseDiscountedItem_Load(object sender, EventArgs e)
        {
            if (activeCashier != null)
            {
                lblActiveUser.Text = $"Active User: {activeCashier.GetFullName()} ({activeCashier.GetDepartment()})";
            }
        }

        private void btnCompute_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtItem.Text;
                double price = Convert.ToDouble(txtPrice.Text);
                double discount = Convert.ToDouble(txtDiscount.Text);
                int quantity = Convert.ToInt32(txtQuantity.Text);

                item = new DiscountedItem(name, price, quantity, discount);
                lblTotalAmount.Text = item.getTotalPrice().ToString("F2");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please ensure numeric input configurations are correct.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (item == null)
                {
                    MessageBox.Show("Please compute the total amount first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                double paymentReceived = Convert.ToDouble(txtPayment.Text);
                if (paymentReceived < item.getTotalPrice())
                {
                    MessageBox.Show("Insufficient payment amount.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                item.setPayment(paymentReceived);
                lblChange.Text = item.getChange().ToString("F2");
            }
            catch (FormatException)
            {
                MessageBox.Show("Please enter a valid amount for payment received.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (loginFormInstance != null)
            {
                loginFormInstance.Show();
                this.Close();
            }
        }

        private void exitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmPurchaseDiscountedItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!loginFormInstance.Visible && e.CloseReason == CloseReason.UserClosing)
            {
                Application.Exit();
            }
        }
    }
}