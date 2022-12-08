using PaymentGateway.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Core.Interfaces
{
    public interface IUserAccount
    {
        public BankAccount CheckBankAccount(int UserId);

        public GoodsAccount CheckGoodsAccount(int UserId);

        public SharesAccount CheckSharesAccount(int UserId);
    }
}
