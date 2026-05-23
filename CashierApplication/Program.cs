using System;
using System.Windows.Forms;

namespace CashierApplication
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Changed target to display the login screen initially
            Application.Run(new frmLoginAccount());
        }
    }
}