using System;

namespace UserAccountNamespace
{
    // --- USER ACCOUNT CLASS ---
    public abstract class UserAccount
    {
        protected string full_name;
        protected string department;
        protected string user_name;
        protected string user_password;

        public UserAccount(string name, string dept, string uName, string uPassword)
        {
            this.full_name = name;
            this.department = dept;
            this.user_name = uName;
            this.user_password = uPassword;
        }

        public abstract bool validateLogin(string uName, string uPassword);
    }

    // --- CASHIER CLASS ---
    public class Cashier : UserAccount
    {
        // Constructor that passes credentials up to the base UserAccount
        public Cashier(string name, string dept, string uName, string uPassword)
            : base(name, dept, uName, uPassword)
        {
        }

        // Returns true if both username and password match perfectly
        public override bool validateLogin(string uName, string uPassword)
        {
            return (this.user_name == uName && this.user_password == uPassword);
        }

        // Helper properties to safely access information for the main form layout display
        public string GetFullName() => this.full_name;
        public string GetDepartment() => this.department;
    }
}