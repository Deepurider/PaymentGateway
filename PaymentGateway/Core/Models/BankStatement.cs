using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Core.Models
{
    public class BankStatement
    {
        public int Id { get; set; }

        public int AccountId { get; set; }

        public int CreditAmount { get; set; }  
        
        public int DebitAmount { get; set; } 

        public DateTime TransactionTime { get; set; }   
    }
}
