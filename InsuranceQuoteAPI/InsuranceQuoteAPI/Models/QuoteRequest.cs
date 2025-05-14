namespace InsuranceQuoteAPI.Models
{
    public class QuoteRequest
    {
        public int Term { get; set; } // Insurance term in months
        public decimal SumInsured { get; set; }
    }
}
