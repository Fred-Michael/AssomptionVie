using InsuranceQuoteAPI.Models;

namespace InsuranceQuoteAPI.Services
{
    public interface IQuoteService
    {
        Guid CreateQuote(QuoteRequest request);
        QuoteResponse GetQuote(Guid quoteId);
    }
}
