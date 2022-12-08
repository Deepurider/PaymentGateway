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
            throw new NotImplementedException();
        }

        public bool sell(User user, GoodsAccount account)
        {
            throw new NotImplementedException();
        }
    }
}
