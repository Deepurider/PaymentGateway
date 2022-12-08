using PaymentGateway.Core.DataContext;
using PaymentGateway.Core.Interfaces;
using PaymentGateway.Core.Models;

namespace PaymentGateway.Core.Classes
{
    public class UserLogin : IConnection
    {
        private readonly PaymentGatewayContext _context;

        public UserLogin(PaymentGatewayContext context)
        {
            _context = context;
        }

        public User connect(string userName, string Password)
        {
            User user = _context.Users.Where(x => x.Username == userName && x.Password == Password).FirstOrDefault();

            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }

        public void disConnect()
        {
            
        }
    }
}
