using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceQuoteUI.Models
{
    public class QuoteResponse
    {
        public Guid QuoteId { get; set; }
        public int Term { get; set; }
        public decimal SumInsured { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CompanyQuote> CompanyQuotes { get; set; } = new List<CompanyQuote>();
    }
}
