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
            throw new NotImplementedException();
        }

        public bool sell(User user, SharesAccount account)
        {
            throw new NotImplementedException();
        }

        public bool transfer(User user, SharesAccount account)
        {
            throw new NotImplementedException();
        }
    }
}
