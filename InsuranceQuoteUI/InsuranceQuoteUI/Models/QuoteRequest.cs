using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceQuoteUI.Models
{
    public class QuoteRequest
    {
        public int Term { get; set; } // Insurance term in months
        public decimal SumInsured { get; set; }
    }
}
