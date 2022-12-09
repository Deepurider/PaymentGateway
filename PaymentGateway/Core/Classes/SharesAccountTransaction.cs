using PaymentGateway.Core.DataContext;
using PaymentGateway.Core.Interfaces;
using PaymentGateway.Core.Models;

namespace PaymentGateway.Core.Classes
{
    public class SharesAccountTransaction : ISharesAccountTransaction
    {
        private readonly PaymentGatewayContext _context;

        public SharesAccountTransaction(PaymentGatewayContext context)
        {
            _context = context;
        }

        public bool buy(User user, SharesAccount account)
        {
            int buyCount = 0;
            int ShareAmount = 0;
            Console.WriteLine("Enter buy count:");
            buyCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Amount:");
            ShareAmount = Convert.ToInt32(Console.ReadLine());

            SharesAccount sharesAccount = _context.SharesAccount.Where(x => x.AccountId == account.AccountId).FirstOrDefault();
            sharesAccount.TotalShare = sharesAccount.TotalShare + buyCount;
            sharesAccount.TotalBalance = sharesAccount.TotalBalance + ShareAmount;

            ShareStatement shareStatement = new ShareStatement() { AccountId = sharesAccount.AccountId, BuyCount = buyCount, SellCount = 0, TransactionTime = DateTime.Now };
            _context.shareStatements.Add(shareStatement);
            _context.SaveChanges();
            Console.WriteLine("Your Current Balance:" + account.TotalBalance);
            Console.WriteLine("Your Total Shares:" + account.TotalShare);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            return true;
        }

        public bool sell(User user, SharesAccount account)
        {
            int sellCount = 0;
            int ShareAmount = 0;
            Console.WriteLine("Enter buy count:");
            sellCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Amount:");
            ShareAmount = Convert.ToInt32(Console.ReadLine());

            SharesAccount sharesAccount = _context.SharesAccount.Where(x => x.AccountId == account.AccountId).FirstOrDefault();
            sharesAccount.TotalShare = sharesAccount.TotalShare - sellCount;
            sharesAccount.TotalBalance = sharesAccount.TotalBalance - ShareAmount;

            ShareStatement shareStatement = new ShareStatement() { AccountId = sharesAccount.AccountId, BuyCount = 0, SellCount = sellCount, TransactionTime = DateTime.Now };
            _context.shareStatements.Add(shareStatement);
            _context.SaveChanges();
            Console.WriteLine("Your Current Balance:" + account.TotalBalance);
            Console.WriteLine("Your Total Shares:" + account.TotalShare);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            return true;
        }

        public bool transfer(User user, SharesAccount account)
        {
            int AccountId = 0;
            int TransferCount = 0;

            Console.WriteLine("Enter Account ShareAccount Id:");
            AccountId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Share count:");
            TransferCount = Convert.ToInt32(Console.ReadLine());

            SharesAccount TransferShareAccount = _context.SharesAccount.Where(x => x.AccountId == AccountId).FirstOrDefault();

            if (TransferShareAccount == null) {
                Console.WriteLine("ShareAccount dose not exist...");
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return false;
            }

            SharesAccount sharesAccount = _context.SharesAccount.Where(x => x.AccountId == account.AccountId).FirstOrDefault();
            sharesAccount.TotalShare = sharesAccount.TotalShare - TransferCount;
            TransferShareAccount.TotalShare = TransferShareAccount.TotalShare + TransferCount;

            ShareStatement shareStatement = new ShareStatement() { AccountId = sharesAccount.AccountId, SellCount = TransferCount, BuyCount = 0, TransactionTime = DateTime.Now };
            ShareStatement transferShareStatement = new ShareStatement() { AccountId = TransferShareAccount.AccountId, BuyCount = TransferCount, SellCount = 0, TransactionTime = DateTime.Now };
            _context.shareStatements.Add(shareStatement);
            _context.shareStatements.Add(transferShareStatement);
            _context.SaveChanges();
            Console.WriteLine("Total Account Balance : " + sharesAccount.TotalBalance);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            return true;

        }

        public bool printStatement(User user, SharesAccount account)
        {
            Console.WriteLine("*********************** Share Account Statement ****************** AccountId: " + account.AccountId + " ***********************");
            List<ShareStatement> shareStatements = _context.shareStatements.Where(x => x.AccountId == account.AccountId).ToList();
            Console.WriteLine("Account Id\t\tBuyCount\t\tSellCount\t\tTransactionTime");

            foreach (ShareStatement shareStatement in shareStatements)
            {
                Console.WriteLine(shareStatement.AccountId + "\t\t\t" + shareStatement.BuyCount + "\t\t\t" + shareStatement.SellCount + "\t\t\t" + shareStatement.TransactionTime.ToString());
            }
            Console.WriteLine("Total Shares: " + account.TotalShare);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            return true;
        }
    }
}
