namespace BusinessLogic
{
    public class Income : Transaction
    {
        public double NominalAmount { get; set; }

        public double TransactionTax { get; set; }

        public double TaxAmount { get; set; }

        public Income()
        {
            
        }

        public Income(int id, double amount, string comment, double currentTax)
        {
            Id = id;

            NominalAmount = amount;

            Comment = comment;

            TransactionTax = currentTax;
        }
    }
}
