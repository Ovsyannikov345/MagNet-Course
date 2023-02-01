using System.Collections.Generic;

namespace BusinessLogic
{
    public interface ITransactionManager
    {
        public List<Income> IncomeList { get; }

        public List<Expense> ExpenseList { get; }
        
        double ProfitValue { get; }

        double TaxValue { get; }

        void AddIncome(double amount, string comment);

        void AddExpense(double amount, string comment);

        void DeleteIncome(int id);

        void DeleteExpense(int id);

        void EditIncome(int id, double amount, string comment);

        void EditExpense(int id, double amount, string comment);
        
        void EditTax(double newTax);
    }
}
