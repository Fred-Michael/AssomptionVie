using InsuranceQuoteAPI.Models;
using System.Collections.Concurrent;
using System.Globalization;

namespace InsuranceQuoteAPI.Services
{
    public class QuoteService : IQuoteService
    {
        private readonly ConcurrentDictionary<Guid, QuoteResponse> _quotes = new ConcurrentDictionary<Guid, QuoteResponse>();
        private readonly Random _random = new Random();

        // List of mock insurance companies
        private readonly List<(string code, string name, double baseFactor, double termFactor, double sumFactor)> _companies = new List<(string, string, double, double, double)>
        {
            ("ACME", "Acme Insurance", 1.2, 0.08, 0.0045),
            ("GLOB", "Global Insurers", 1.0, 0.10, 0.0050),
            ("SAFE", "SafeGuard Insurance", 1.5, 0.07, 0.0040),
            ("PROT", "Protector Co.", 1.3, 0.09, 0.0055)
        };

        public Guid CreateQuote(QuoteRequest request)
        {
            var quoteId = Guid.NewGuid();
            var quoteResponse = new QuoteResponse
            {
                QuoteId = quoteId,
                Term = request.Term,
                SumInsured = request.SumInsured,
                CreatedAt = DateTime.Now,
                CompanyQuotes = GenerateCompanyQuotes(request.Term, request.SumInsured)
            };

            _quotes[quoteId] = quoteResponse;
            return quoteId;
        }

        public QuoteResponse GetQuote(Guid quoteId)
        {
            if (_quotes.TryGetValue(quoteId, out var quote))
            {
                return quote;
            }
            return null;
        }

        private List<CompanyQuote> GenerateCompanyQuotes(int term, decimal sumInsured)
        {
            var quotes = new List<CompanyQuote>();
            //var usCulture = new CultureInfo("en-US");

            // Calculate a base premium for each company using slightly different formulas
            foreach (var company in _companies)
            {
                // Base calculation with some randomness to simulate different pricing models
                var basePremium = (double)sumInsured * company.sumFactor * (1 + term * company.termFactor / 100) * company.baseFactor;

                // Add some random variation (±10%)
                var variation = 0.9 + (_random.NextDouble() * 0.2);
                var premium = Math.Round(basePremium * variation, 2);

                quotes.Add(new CompanyQuote
                {
                    CompanyCode = company.code,
                    CompanyName = company.name,
                    Premium = (decimal)premium
                });
            }

            return quotes;
        }
    }
}
