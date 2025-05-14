using InsuranceQuoteAPI.Models;
using InsuranceQuoteAPI.Services;

namespace InsuranceQuote.Tests.UnitTests
{
    public class InsuranceQuotesServiceTests
    {
        private readonly QuoteService _quoteService;

        public InsuranceQuotesServiceTests()
        {
            // Create a new instance of the service for each test
            _quoteService = new QuoteService();
        }

        [Fact]
        public void CreateQuote_ReturnsValidGuid()
        {
            // Arrange
            var request = new QuoteRequest
            {
                Term = 12,
                SumInsured = 100000
            };

            // Act
            var quoteId = _quoteService.CreateQuote(request);

            // Assert
            Assert.NotEqual(Guid.Empty, quoteId);
        }

        [Fact]
        public void GetQuote_ReturnsNull_ForNonExistentQuote()
        {
            // Arrange
            var nonExistentQuoteId = Guid.NewGuid();

            // Act
            var result = _quoteService.GetQuote(nonExistentQuoteId);

            // Assert
            Assert.Null(result);
        }

        [Fact]
        public void GetQuote_ReturnsCorrectQuote_AfterCreation()
        {
            // Arrange
            var request = new QuoteRequest
            {
                Term = 24,
                SumInsured = 250000
            };

            // Act
            var quoteId = _quoteService.CreateQuote(request);
            var retrievedQuote = _quoteService.GetQuote(quoteId);

            // Assert
            Assert.NotNull(retrievedQuote);
            Assert.Equal(quoteId, retrievedQuote.QuoteId);
            Assert.Equal(request.Term, retrievedQuote.Term);
            Assert.Equal(request.SumInsured, retrievedQuote.SumInsured);
        }

        [Fact]
        public void CreateQuote_GeneratesFourCompanyQuotes()
        {
            // Arrange
            var request = new QuoteRequest
            {
                Term = 12,
                SumInsured = 100000
            };

            // Act
            var quoteId = _quoteService.CreateQuote(request);
            var retrievedQuote = _quoteService.GetQuote(quoteId);

            // Assert
            Assert.Equal(4, retrievedQuote.CompanyQuotes.Count);
            Assert.Contains(retrievedQuote.CompanyQuotes, q => q.CompanyCode == "ACME");
            Assert.Contains(retrievedQuote.CompanyQuotes, q => q.CompanyCode == "GLOB");
            Assert.Contains(retrievedQuote.CompanyQuotes, q => q.CompanyCode == "SAFE");
            Assert.Contains(retrievedQuote.CompanyQuotes, q => q.CompanyCode == "PROT");
        }

        [Fact]
        public void CreateQuote_AllPremiumsArePositive()
        {
            // Arrange
            var request = new QuoteRequest
            {
                Term = 36,
                SumInsured = 500000
            };

            // Act
            var quoteId = _quoteService.CreateQuote(request);
            var retrievedQuote = _quoteService.GetQuote(quoteId);

            // Assert
            Assert.All(retrievedQuote.CompanyQuotes, q => Assert.True(q.Premium > 0));
        }

        [Theory]
        [InlineData(12, 100000)]  // 1-year term, 100K coverage
        [InlineData(60, 250000)]  // 5-year term, 250K coverage
        [InlineData(120, 1000000)] // 10-year term, 1M coverage
        public void CreateQuote_DifferentParameters_GeneratesValidPremiums(int term, decimal sumInsured)
        {
            // Arrange
            var request = new QuoteRequest
            {
                Term = term,
                SumInsured = sumInsured
            };

            // Act
            var quoteId = _quoteService.CreateQuote(request);
            var retrievedQuote = _quoteService.GetQuote(quoteId);

            // Assert
            Assert.NotNull(retrievedQuote);
            Assert.Equal(4, retrievedQuote.CompanyQuotes.Count);
            Assert.All(retrievedQuote.CompanyQuotes, q => Assert.True(q.Premium > 0));
        }

        [Fact]
        public void MultipleQuotes_StoreAndRetrieveCorrectly()
        {
            // Arrange
            var request1 = new QuoteRequest { Term = 12, SumInsured = 100000 };
            var request2 = new QuoteRequest { Term = 24, SumInsured = 200000 };

            // Act
            var quoteId1 = _quoteService.CreateQuote(request1);
            var quoteId2 = _quoteService.CreateQuote(request2);

            var retrievedQuote1 = _quoteService.GetQuote(quoteId1);
            var retrievedQuote2 = _quoteService.GetQuote(quoteId2);

            // Assert
            Assert.Equal(request1.Term, retrievedQuote1.Term);
            Assert.Equal(request1.SumInsured, retrievedQuote1.SumInsured);

            Assert.Equal(request2.Term, retrievedQuote2.Term);
            Assert.Equal(request2.SumInsured, retrievedQuote2.SumInsured);

            // Ensure they're different quotes
            Assert.NotEqual(quoteId1, quoteId2);
        }

        [Fact]
        public void PremiumCalculation_HigherTermMeansHigherPremium()
        {
            // Arrange
            var lowTermRequest = new QuoteRequest { Term = 12, SumInsured = 100000 };
            var highTermRequest = new QuoteRequest { Term = 60, SumInsured = 100000 }; // Same sum insured, higher term

            // Act
            var lowTermQuoteId = _quoteService.CreateQuote(lowTermRequest);
            var highTermQuoteId = _quoteService.CreateQuote(highTermRequest);

            var lowTermQuote = _quoteService.GetQuote(lowTermQuoteId);
            var highTermQuote = _quoteService.GetQuote(highTermQuoteId);

            // Get average premium for each quote to account for random variations
            var lowTermAvgPremium = lowTermQuote.CompanyQuotes.Average(q => (double)q.Premium);
            var highTermAvgPremium = highTermQuote.CompanyQuotes.Average(q => (double)q.Premium);

            // Assert
            Assert.True(highTermAvgPremium > lowTermAvgPremium);
        }

        [Fact]
        public void PremiumCalculation_HigherSumInsuredMeansHigherPremium()
        {
            // Arrange
            var lowSumRequest = new QuoteRequest { Term = 24, SumInsured = 100000 };
            var highSumRequest = new QuoteRequest { Term = 24, SumInsured = 500000 }; // Same term, higher sum insured

            // Act
            var lowSumQuoteId = _quoteService.CreateQuote(lowSumRequest);
            var highSumQuoteId = _quoteService.CreateQuote(highSumRequest);

            var lowSumQuote = _quoteService.GetQuote(lowSumQuoteId);
            var highSumQuote = _quoteService.GetQuote(highSumQuoteId);

            // Get average premium for each quote to account for random variations
            var lowSumAvgPremium = lowSumQuote.CompanyQuotes.Average(q => (double)q.Premium);
            var highSumAvgPremium = highSumQuote.CompanyQuotes.Average(q => (double)q.Premium);

            // Assert
            Assert.True(highSumAvgPremium > lowSumAvgPremium);
        }
    }
}