using PaymentGateway.Core.Classes;
using PaymentGateway.Core.DataContext;
using PaymentGateway.Core.Models;

namespace PaymentGatewayApi
{
    public class PaymentGateway
    {
        public static User LogggedUser { get; private set; }

        public static BankAccount BankAccount { get; private set; }

        public static GoodsAccount GoodsAccount { get; private set; }

        public static SharesAccount SharesAccount { get; private set; }

        public static void Main(string[] args)
        {
            PaymentGatewayContext context = new PaymentGatewayContext();
            Console.WriteLine("Loading ...");
            StoreData(context);
        start:
            Console.Clear();
            Console.WriteLine("*********************** Online Payment Gateway ***********************");
            if (UserAuthentication(context))
            {
                UserAccount userAccount = new UserAccount(context);
                if (userAccount.CheckBankAccount(LogggedUser.UserId) != null)
                {
                    BankAccount = userAccount.CheckBankAccount(LogggedUser.UserId);
                    BankAccountTransaction(context);
                    goto start;
                }
                else if (userAccount.CheckGoodsAccount(LogggedUser.UserId) != null)
                {
                    GoodsAccount = userAccount.CheckGoodsAccount(LogggedUser.UserId);
                    GoodsAccountTransactions(context);
                    goto start; 
                }
                else if (userAccount.CheckSharesAccount(LogggedUser.UserId) != null)
                {
                    SharesAccount = userAccount.CheckSharesAccount(LogggedUser.UserId);
                    SharesAccountTransaction(context);
                    goto start; 
                }
            }
            else {
                Console.WriteLine("User Credentials Invalid, Press any key to continue...");
                Console.ReadKey();
                goto start;
            }
        }

        public static void StoreData(PaymentGatewayContext context)
        {
            context.Users.Add(new User { UserId = 1, Name = "Test", Username = "Test", Password = "Test" });
            context.Users.Add(new User { UserId = 2, Name = "Test1", Username = "Test1", Password = "Test1" });
            context.Users.Add(new User { UserId = 3, Name = "Test2", Username = "Test2", Password = "Test2" });
            context.Users.Add(new User { UserId = 4, Name = "Test3", Username = "Test3", Password = "Test3" });
            context.Users.Add(new User { UserId = 5, Name = "Test4", Username = "Test4", Password = "Test4" });
            context.Users.Add(new User { UserId = 6, Name = "Test5", Username = "Test5", Password = "Test5" });

            context.BankAccount.Add(new BankAccount { AccountId = 1, AccountType = 1, UserId = 1, BalanceAmount = 1000, Currency = "USD" });
            context.BankAccount.Add(new BankAccount { AccountId = 2, AccountType = 2, UserId = 2, BalanceAmount = 2000, Currency = "USD" });

            context.GoodsAccount.Add(new GoodsAccount { AccountId = 3, AccountType = 3, TotalBalance = 1000, UserId = 3, TradingUnit = "gram", TotalGoods = 100 });
            context.GoodsAccount.Add(new GoodsAccount { AccountId = 4, AccountType = 3, TotalBalance = 5000, UserId = 4, TradingUnit = "gram", TotalGoods = 500 });

            context.SharesAccount.Add(new SharesAccount { AccountId = 5, AccountType = 1, TotalBalance = 500, UserId = 5, ShareholderPercentage = 76, TotalShare = 10, Totalbonds = 1 });
            context.SharesAccount.Add(new SharesAccount { AccountId = 6, AccountType = 1, TotalBalance = 1000, UserId = 6, ShareholderPercentage = 56, TotalShare = 100, Totalbonds = 3 });
            context.SaveChanges();
            Console.Clear();
        }

        public static bool UserAuthentication(PaymentGatewayContext context)
        {
            UserLogin userLogin = new UserLogin(context);

            Console.WriteLine("Enter your username:");
            string username = Console.ReadLine();

            Console.WriteLine("Enter your password:");
            string password = Console.ReadLine();

            User user = userLogin.connect(username, password);

            if (user != null)
            {
                LogggedUser = user;
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void GoodsAccountTransactions(PaymentGatewayContext context)
        {
            int userInput = 1;
            Console.Clear();
            Console.WriteLine("*********************** Goods Account Transaction ***********************");
            GoodsAccountTransaction transaction = new GoodsAccountTransaction(context);
            Console.WriteLine("Please select below option to continue");
            Console.WriteLine("1. Buy");
            Console.WriteLine("2. Sell");
            Console.WriteLine("3. Print Statement");
            Console.WriteLine("0. Exit");
            start:
            Console.WriteLine("Enter your choice:");
            userInput = Convert.ToInt32(Console.ReadLine());

            switch (userInput)
            {
                case 1:
                    transaction.buy(LogggedUser, GoodsAccount);
                    break;

                case 2:
                    transaction.sell(LogggedUser, GoodsAccount);
                    break;
                case 3:
                    transaction.printStatement(LogggedUser, GoodsAccount);
                    break;

                case 0:
                    break;

                default:
                    Console.WriteLine("You entered wrong option.");
                    goto start;
                    break;
            }
        }

        public static void BankAccountTransaction(PaymentGatewayContext context)
        {
            int userInput = 1;
            Console.Clear();
            Console.WriteLine("*********************** Bank Account Transaction ***********************");
            BankAccountTransactions transactions = new BankAccountTransactions(context);
            Console.WriteLine("Please select below option to continue");
            Console.WriteLine("1. Deposite Money");
            Console.WriteLine("2. Withdraw Money");
            Console.WriteLine("3. Transfer Money");
            Console.WriteLine("4. Account Statment");
            Console.WriteLine("0. Exit");
            start:
            Console.WriteLine("Enter your choice:");
            userInput = Convert.ToInt32(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    transactions.deposit(LogggedUser, BankAccount);
                    break;

                case 2:
                    transactions.withdraw(LogggedUser, BankAccount);
                    break;

                case 3:
                    transactions.transafer(LogggedUser, BankAccount);
                    break;
                case 4:
                    transactions.printStatement(LogggedUser, BankAccount);
                    break;
                case 0:
                    break;

                default:
                    Console.WriteLine("You entered wrong option.");
                    goto start;
                    break;
            }
        }

        public static void SharesAccountTransaction(PaymentGatewayContext context)
        {
            int userInput = 1;
            Console.Clear();
            Console.WriteLine("*********************** Shares Account Transaction ***********************");
            SharesAccountTransaction transactions = new SharesAccountTransaction(context);
            Console.WriteLine("Please select below option to continue");
            Console.WriteLine("1. Buy Share");
            Console.WriteLine("2. Sell Share");
            Console.WriteLine("3. Transfer Share");
            Console.WriteLine("4. Print Statement");
            Console.WriteLine("0. Exit");
        start:
            Console.WriteLine("Enter your choice:");
            userInput = Convert.ToInt32(Console.ReadLine());
            switch (userInput)
            {
                case 1:
                    transactions.buy(LogggedUser, SharesAccount);
                    break;

                case 2:
                    transactions.sell(LogggedUser, SharesAccount);
                    break;

                case 3:
                    transactions.transfer(LogggedUser, SharesAccount);
                    break;
                case 4:
                    transactions.printStatement(LogggedUser, SharesAccount);
                    break;
                case 0:
                    break;

                default:
                    Console.WriteLine("You entered wrong option.");
                    goto start;
                    break;
            }
        }
    }
}