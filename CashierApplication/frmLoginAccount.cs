using System;
using System.Windows.Forms;
using UserAccountNamespace;

namespace CashierApplication
{
    public partial class frmLoginAccount : Form
    {
        private Cashier defaultCashier;

        public frmLoginAccount()
        {
            InitializeComponent();
            defaultCashier = new Cashier("CJ Flores", "Finance", "cj123", "cj12345");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string enteredUser = txtUsername.Text;
            string enteredPass = txtPassword.Text;

            if (defaultCashier.validateLogin(enteredUser, enteredPass))
            {
                MessageBox.Show($"Welcome, {defaultCashier.GetFullName()} of {defaultCashier.GetDepartment()} department!",
                                "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                frmPurchaseDiscountedItem contextWindow = new frmPurchaseDiscountedItem(defaultCashier, this);
                contextWindow.Show();
                this.Hide(); 

                txtUsername.Clear();
                txtPassword.Clear();
            }
            else
            {
                MessageBox.Show("Invalid username or password. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmLoginAccount_Load(object sender, EventArgs e)
        {

        }
    }
}