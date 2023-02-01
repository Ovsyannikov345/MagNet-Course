namespace BusinessLogic
{
    public abstract class Transaction
    {
        public int Id { get; set; }

        public double Amount { get; set; }

        public string Comment { get; set; }

        public bool IsDeleted { get; set; }
    }
}
