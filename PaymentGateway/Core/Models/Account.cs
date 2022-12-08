using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Core.Models
{
    public abstract class Account
    {
        [Key]
        public int AccountId { get; set; } 

        public int UserId { get; set; } 

        public int AccountType { get; set; }    
  
    }
}
