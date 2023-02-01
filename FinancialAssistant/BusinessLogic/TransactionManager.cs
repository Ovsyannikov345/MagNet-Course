using Common;
using System.Collections.Generic;

namespace BusinessLogic
{
    public class TransactionManager : ITransactionManager
    {
        private readonly User currentUser;

        public List<Income> IncomeList { get; private set; }

        public List<Expense> ExpenseList { get; private set; }

        public double ProfitValue { get; private set; }

        public double TaxValue { get; private set; }

        private int incomeIdCounter;

        private int expenseIdCounter;

        private readonly IDataManager dataProvider;

        public TransactionManager(User user, IDataManager dataProvider)
        {
            currentUser = user;
            IncomeList = user.Incomes;
            ExpenseList = user.Expenses;
            ProfitValue = user.Profit;
            TaxValue = user.Tax;
            incomeIdCounter = IncomeList.Count;
            expenseIdCounter = ExpenseList.Count;

            this.dataProvider = dataProvider;
        }

        public void AddIncome(double amount, string comment)
        {
            IncomeList.Add(new Income(incomeIdCounter, amount, comment, TaxValue));

            CalculateIncomeParameters(incomeIdCounter);

            ProfitValue += IncomeList[incomeIdCounter].Amount;

            incomeIdCounter++;
            SaveData();
        }

        public void AddExpense(double amount, string comment)
        {
            ExpenseList.Add(new Expense(expenseIdCounter, amount, comment));

            ProfitValue -= ExpenseList[expenseIdCounter].Amount;

            expenseIdCounter++;
            SaveData();
        }

        public void DeleteIncome(int id)
        {
            if (IncomeList.Count != 0)
            {
                ProfitValue -= IncomeList[id].Amount;

                IncomeList[id].IsDeleted = true;
            }

            SaveData();
        }

        public void DeleteExpense(int id)
        {
            if (ExpenseList.Count != 0)
            {
                ProfitValue += ExpenseList[id].Amount;

                ExpenseList[id].IsDeleted = true;
            }

            SaveData();
        }

        public void EditIncome(int id, double amount, string comment)
        {
            ProfitValue += amount * (1 - TaxValue / 100.0) - IncomeList[id].Amount;

            IncomeList[id].NominalAmount = amount;

            IncomeList[id].Comment = comment;

            CalculateIncomeParameters(id);
            SaveData();
        }

        public void EditExpense(int id, double amount, string comment)
        {
            ProfitValue -= amount - ExpenseList[id].Amount;

            ExpenseList[id].Amount = amount;

            ExpenseList[id].Comment = comment;
            SaveData();
        }

        public void CalculateIncomeParameters(int id)
        {
            IncomeList[id].Amount = IncomeList[id].NominalAmount * (1 - TaxValue / 100.0);
            IncomeList[id].TaxAmount = IncomeList[id].NominalAmount * TaxValue / 100;
        }

        public void EditTax(double newTax)
        {
            TaxValue = newTax;
            SaveData();
        }

        public void SaveData()
        {
            List<User> userList = dataProvider.LoadUsers<List<User>>();

            int currentUserIndex = userList.FindIndex(user => user.Login == currentUser.Login);

            currentUser.Incomes = IncomeList;
            currentUser.Expenses = ExpenseList;
            currentUser.Profit = ProfitValue;
            currentUser.Tax = TaxValue;

            userList[currentUserIndex] = currentUser;
            dataProvider.SaveUsers(userList);
        }
    }
}
