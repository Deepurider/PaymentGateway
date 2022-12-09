using PaymentGateway.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Core.Interfaces
{
    public interface IGoodsAccountTransaction
    {
        public bool buy(User user, GoodsAccount account);

        public bool sell(User user, GoodsAccount account);

        public bool printStatement(User user, GoodsAccount account);
    }
}
