using PaymentGateway.Core.DataContext;
using PaymentGateway.Core.Interfaces;
using PaymentGateway.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Core.Classes
{
    public class GoodsAccountTransaction : IGoodsAccountTransaction
    {
        private readonly PaymentGatewayContext _context;

        public GoodsAccountTransaction(PaymentGatewayContext context)
        {
            _context = context;
        }

        public bool buy(User user , GoodsAccount account)
        {
            int goodsCount = 0;
            int goodsAmount = 0;
            Console.WriteLine("Enter buy count:");
            goodsCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Amount:");
            goodsAmount = Convert.ToInt32(Console.ReadLine());

            GoodsAccount goodsAccount = _context.GoodsAccount.Where(x => x.UserId == user.UserId).FirstOrDefault();
            goodsAccount.TotalGoods = goodsAccount.TotalGoods + goodsCount;
            goodsAccount.TotalBalance = goodsAccount.TotalBalance + goodsAmount;

            GoodsStatement goodsStatement = new GoodsStatement() { AccountId = goodsAccount.AccountId, BuyCount = goodsCount, SellCount = 0, TransactionTime = DateTime.Now };
            _context.goodsStatements.Add(goodsStatement);
            _context.SaveChanges();
            Console.WriteLine("Your Current Balance:" + account.TotalBalance);
            Console.WriteLine("Your Total Goods:" + account.TotalGoods);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            return true;
        }

        public bool sell(User user, GoodsAccount account)
        {
            int sellCount = 0;
            int goodsAmount = 0;
            Console.WriteLine("Enter sell count:");
            sellCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Amount:");
            goodsAmount = Convert.ToInt32(Console.ReadLine());

            GoodsAccount goodsAccount = _context.GoodsAccount.Where(x => x.UserId == user.UserId).FirstOrDefault();
            goodsAccount.TotalGoods = goodsAccount.TotalGoods - sellCount;
            goodsAccount.TotalBalance = goodsAccount.TotalBalance - goodsAmount;

            GoodsStatement goodsStatement = new GoodsStatement() { AccountId = goodsAccount.AccountId, BuyCount = 0, SellCount = sellCount, TransactionTime = DateTime.Now };
            _context.goodsStatements.Add(goodsStatement);
            _context.SaveChanges();
            Console.WriteLine("Your Current Balance:" + account.TotalBalance);
            Console.WriteLine("Your Total Goods:" + account.TotalGoods);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            return true;
        }

        public bool printStatement(User user, GoodsAccount account)
        {
            Console.WriteLine("*********************** Goods Account Statement ****************** AccountId: " + account.AccountId + " ***********************");
            List<GoodsStatement> goodsStatements = _context.goodsStatements.Where(x => x.AccountId == account.AccountId).ToList();
            Console.WriteLine("Account Id\t\tBuyCount\t\tSellCount\t\tTransactionTime");

            foreach (GoodsStatement goodsStatement in goodsStatements)
            {
                Console.WriteLine(goodsStatement.AccountId + "\t\t\t" + goodsStatement.BuyCount + "\t\t\t" + goodsStatement.SellCount + "\t\t\t" + goodsStatement.TransactionTime.ToString());
            }
            Console.WriteLine("Total Goods Balance : " + account.TotalGoods);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
            return true;    
        }
    }
}
