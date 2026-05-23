using System;
using System.Windows.Forms;
using UserAccountNamespace;

namespace CashierApplication
{
    public partial class frmLoginAccount : Form
    {
        // Seeded account object representing standard cashier credentials
        private Cashier defaultCashier;

        public frmLoginAccount()
        {
            InitializeComponent();
            // Seed a sample account: Full Name, Department, Username, Password
            defaultCashier = new Cashier("CJ Flores", "Finance", "cj123", "cj12345");
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string enteredUser = txtUsername.Text;
            string enteredPass = txtPassword.Text;

            // Validate using the abstract signature logic
            if (defaultCashier.validateLogin(enteredUser, enteredPass))
            {
                MessageBox.Show($"Welcome, {defaultCashier.GetFullName()} of {defaultCashier.GetDepartment()} department!",
                                "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Pass the logged-in Cashier entity over to the main execution window
                frmPurchaseDiscountedItem contextWindow = new frmPurchaseDiscountedItem(defaultCashier, this);
                contextWindow.Show();
                this.Hide(); // Hide login instead of closing to prevent the execution thread from crashing

                // Clear input boxes for security when returning back later
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