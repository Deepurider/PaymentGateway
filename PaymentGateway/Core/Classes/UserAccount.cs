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
    public class UserAccount : IUserAccount
    {
        private readonly PaymentGatewayContext _context;

        public UserAccount(PaymentGatewayContext context)
        {
            _context = context;
        }

        public BankAccount CheckBankAccount(int UserId)
        {
           BankAccount bankAccount =  _context.BankAccount.Where(x => x.UserId == UserId).FirstOrDefault();
            if (bankAccount == null) return null;
            return bankAccount;
        }

        public GoodsAccount CheckGoodsAccount(int UserId)
        {
            GoodsAccount goodsAccount =  _context.GoodsAccount.Where(x => x.UserId == UserId).FirstOrDefault();
            if (goodsAccount == null) return null;
            return goodsAccount;    
        }

        public SharesAccount CheckSharesAccount(int UserId)
        {
            SharesAccount sharesAccount =  _context.SharesAccount.Where(x => x.UserId == UserId).FirstOrDefault();
            if (sharesAccount == null) return null;
            return sharesAccount;       
        }
    }
}
