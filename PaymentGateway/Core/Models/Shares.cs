using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentGateway.Core.Models
{
    public class Shares
    {
        public int Id { get; set; }

        public string Name { get; set; }        

        public int Amount { get; set; } 

        public int HolderPercentage { get; set; }   
    }
}
