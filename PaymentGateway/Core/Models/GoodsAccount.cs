using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Core.Models
{
    public class GoodsAccount : Account
    {
        public int TotalGoods { get; set; }   

        public int TotalBalance { get; set; } 

        public string TradingUnit { get; set; }
    }
}
