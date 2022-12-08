using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Core.Models
{
    public class BankAccount : Account
    {
        public int BalanceAmount { get; set; }  

        public string Currency { get; set; }    
    }
}
