using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Core.Models
{
    public class SharesAccount : Account
    {
        public int TotalShare { get; set; }

        public int Totalbonds { get; set; }
        
        public int TotalBalance { get; set; } 

        public int ShareholderPercentage { get; set; }  
    }
}
