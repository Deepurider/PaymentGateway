using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Core.Models
{
    public class GoodsAccount : Account
    {
        public string Goods { get; set; }   

        public int Amount { get; set; } 

        public string TradingUnit { get; set; }
    }
}
