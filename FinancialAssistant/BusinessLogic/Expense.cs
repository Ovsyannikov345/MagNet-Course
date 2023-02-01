namespace BusinessLogic
{
    public class Expense : Transaction
    {
        public Expense()
        {

        }

        public Expense(int id, double amount, string comment)
        {
            Id = id;

            Amount = amount;

            Comment = comment;
        }
    }
}
