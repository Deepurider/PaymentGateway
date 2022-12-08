using PaymentGateway.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Core.Interfaces
{
    public interface IConnection
    {
        public User connect(string userName, string Password);

        public void disConnect();
    }
}
