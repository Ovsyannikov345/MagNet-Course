using System.Collections.Generic;

namespace BusinessLogic
{
    public class User
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public List<Income> Incomes { get; set; }

        public List<Expense> Expenses { get; set; }

        public double Tax { get; set; }

        public double Profit {get; set;}

        public User()
        {
            
        }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
            Incomes = new List<Income>();
            Expenses = new List<Expense>();
            Tax = 13;
        }
    }
}
