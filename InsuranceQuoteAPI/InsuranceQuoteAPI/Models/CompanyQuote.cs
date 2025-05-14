namespace InsuranceQuoteAPI.Models
{
    public class CompanyQuote
    {
        public string CompanyCode { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public decimal Premium { get; set; }
    }
}
