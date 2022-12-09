using PaymentGateway.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Core.Interfaces
{
    public interface ISharesAccountTransaction
    {
        public bool buy(User user, SharesAccount account);

        public bool sell(User user, SharesAccount account);

        public bool transfer(User user, SharesAccount account);

        public bool printStatement(User user, SharesAccount account);
    }
}
