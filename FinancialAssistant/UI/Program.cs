using BusinessLogic;
using Common;
using DataLayer;
using System.Timers;

namespace UI
{
    public static class Program
    {
        readonly static IConsoleManager consoleProvider = new ConsoleManager();

        readonly static IReportManager reportProvider = new ReportManager();

        readonly static IDataManager dataProvider = new DataManager();

        readonly static IAuthService userProvider = new AuthService(dataProvider);

        private static ITransactionManager transactionsProvider;

        readonly static Timer timer = new Timer(dataProvider.LoadConfig());

        private static bool isProgramRunning = true;

        private static bool isUserLogged = true;

        static void Main()
        {
            timer.Elapsed += LogOut;

            SetCurrentUser(string.Empty);

            timer.Start();

            while (isProgramRunning)
            {
                if (!isUserLogged)
                {
                    SetCurrentUser("You`ve been logged out.");
                }
                
                ProcessAction();
            }
        }

        private static void ProcessAction()
        {
            consoleProvider.PrintInfo("\n1) Show table\n" +
                                     "2) Add income\n" +
                                     "3) Add expense\n" +
                                     "4) Delete income\n" +
                                     "5) Delete expense\n" +
                                     "6) Edit income\n" +
                                     "7) Edit expense\n" +
                                     "8) Print report to file\n" +
                                     "9) Change tax\n" +
                                     "10) Log out\n" +
                                     "11) Close program");

            int action = consoleProvider.GetUserInt("Choose action: ", 1, 11);

            consoleProvider.Clear();

            switch ((ProgramOptions)action)
            {
                case ProgramOptions.PrintToConsole:
                    consoleProvider.PrintInfo(TableConverter.ConvertToTable(transactionsProvider.IncomeList) +
                                              TableConverter.ConvertToTable(transactionsProvider.ExpenseList) +
                                              $"\n\t\tPROFIT AMOUNT: {transactionsProvider.ProfitValue:f2}\n");
                    break;
                case ProgramOptions.AddIncome:
                    transactionsProvider.AddIncome(GetAmount(), GetComment());
                    break;
                case ProgramOptions.AddExpense:
                    transactionsProvider.AddExpense(GetAmount(), GetComment());
                    break;
                case ProgramOptions.DeleteIncome:
                    transactionsProvider.DeleteIncome(GetId(TransactionType.Income));
                    break;
                case ProgramOptions.DeleteExpense:
                    transactionsProvider.DeleteExpense(GetId(TransactionType.Expense));
                    break;
                case ProgramOptions.EditIncome:
                    transactionsProvider.EditIncome(GetId(TransactionType.Income), GetAmount(), GetComment());
                    break;
                case ProgramOptions.EditExpense:
                    transactionsProvider.EditExpense(GetId(TransactionType.Expense), GetAmount(), GetComment());
                    break;
                case ProgramOptions.PrintToFile:
                    reportProvider.PrintInfo(TableConverter.ConvertToTable(transactionsProvider.IncomeList) +
                                           TableConverter.ConvertToTable(transactionsProvider.ExpenseList) +
                                           $"\n\t\tPROFIT AMOUNT: {transactionsProvider.ProfitValue:f2}\n");
                    consoleProvider.PrintInfo("|REPORT HAS BEEN CREATED ON THE DESKTOP|");
                    break;
                case ProgramOptions.ChangeTax:
                    transactionsProvider.EditTax(consoleProvider.GetUserDouble($"Enter new tax(current tax = {transactionsProvider.TaxValue}): ", 0, 100));
                    break;
                case ProgramOptions.LogOut:
                    isUserLogged = false;
                    break;
                case ProgramOptions.CloseProgram:
                    isProgramRunning = false;
                    break;
            }

            timer.Restart();
        }

        private static void SetCurrentUser(string message)
        {
            consoleProvider.Clear();
            consoleProvider.PrintInfo(message);
            consoleProvider.PrintInfo("1) Log in\n" +
                                     "2) Register");

            int choice = consoleProvider.GetUserInt("Choose action: ", 1, 2);

            switch ((AuthorizationOptions)choice)
            {
                case AuthorizationOptions.LogIn:
                    transactionsProvider = new TransactionManager(AuthorizeUser(), dataProvider);
                    break;
                case AuthorizationOptions.Register:
                    transactionsProvider = new TransactionManager(RegisterUser(), dataProvider);
                    break;
            }

            isUserLogged = true;
        }

        private static void LogOut(object source, ElapsedEventArgs e)
        {
            isUserLogged = false;
        }

        private static User AuthorizeUser()
        {
            string login = consoleProvider.GetUserString("Login: ");

            while (!userProvider.CheckLogin(login))
            {
                login = consoleProvider.GetUserString("Wrong login. Try again: ");
            }

            string password = consoleProvider.GetUserString("Password: ");

            User user = userProvider.Authorize(login, password);

            while (user == default(User))
            {
                password = consoleProvider.GetUserString("Wrong password. Try again: ");
                user = userProvider.Authorize(login, password);
            }

            return user;
        }

        private static User RegisterUser()
        {
            string login = consoleProvider.GetUserString("Login: ");

            while (userProvider.CheckLogin(login))
            {
                login = consoleProvider.GetUserString("Login is taken. Try again: ");
            }

            string password = consoleProvider.GetUserString("Password: ");

            return userProvider.Register(login, password);
        }

        private static int GetId(TransactionType type)
        {
            return type switch
            {
                TransactionType.Income => consoleProvider.GetUserInt("Enter id: ", 0, transactionsProvider.IncomeList.Count - 1),
                TransactionType.Expense => consoleProvider.GetUserInt("Enter id: ", 0, transactionsProvider.ExpenseList.Count - 1),
                _ => -1,
            };
        }

        private static double GetAmount() => consoleProvider.GetUserDouble("Enter amount: ", 0);

        private static string GetComment() => consoleProvider.GetUserString("Enter comment: ");

        public static void Restart(this Timer timer)
        {
            timer.Stop();
            timer.Start();
        }
    }
}
