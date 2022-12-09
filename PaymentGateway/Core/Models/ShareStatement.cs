using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Core.Models
{
    public class ShareStatement
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public int BuyCount { get; set; }

        public int SellCount { get; set; }

        public int Amount { get; set; } 

        public DateTime TransactionTime { get; set; }
    }
}
