using System.Collections.Generic;
using System.Text;

namespace BusinessLogic
{
    public static class TableConverter
    {
        public static string ConvertToTable(List<Income> incomes)
        {
            StringBuilder sb = new StringBuilder();

            if (incomes.Count != 0)
            {
                sb.AppendLine("\t\t|YOUR INCOME LIST|\n");
                sb.AppendLine($"{"Id",5}" +
                              $"{"Amount",20}" +
                              $"{"Tax",20}" +
                              $"{"Real Amount",20}" +
                              "\t\tComment\n");

                for (var i = 0; i < incomes.Count; i++)
                {
                    if (incomes[i] != null && !incomes[i].IsDeleted)
                    {
                        sb.AppendLine($"{incomes[i].Id,5}" +
                                      $"{incomes[i].NominalAmount,20:f2}" +
                                      $"{incomes[i].TaxAmount,15:f2}" +
                                      $"({incomes[i].TransactionTax}%)" +
                                      $"{incomes[i].Amount,20:f2}" +
                                      $"\t\t{incomes[i].Comment}");
                    }
                }
            }
            else
            {
                sb.AppendLine("\n\t\t|YOUR INCOME LIST IS EMPTY|\n");
            }

            return sb.ToString();
        }

        public static string ConvertToTable(List<Expense> expenses)
        {
            StringBuilder sb = new StringBuilder();

            if (expenses.Count != 0)
            {
                sb.AppendLine("\n\t\t|YOUR EXPENSE LIST|\n");
                sb.AppendLine($"{"Id",5}" +
                              $"{"Amount",20}" +
                              "\t\tComment\n");

                for (var i = 0; i < expenses.Count; i++)
                {
                    if (!expenses[i].IsDeleted)
                    {
                        sb.AppendLine($"{expenses[i].Id,5}" +
                                      $"{expenses[i].Amount,20:f2}" +
                                      $"\t\t{expenses[i].Comment}");
                    }
                }
            }
            else
            {
                sb.AppendLine("\n\t\t|YOUR EXPENSE LIST IS EMPTY|\n");
            }

            return sb.ToString();
        }
    }
}
