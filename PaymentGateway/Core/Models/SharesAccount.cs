using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Core.Models
{
    public class SharesAccount : Account
    {
        public string Share { get; set; }

        public string bonds { get; set; }
        
        public int amount { get; set; } 

        public int ShareholderPercentage { get; set; }  
    }
}
