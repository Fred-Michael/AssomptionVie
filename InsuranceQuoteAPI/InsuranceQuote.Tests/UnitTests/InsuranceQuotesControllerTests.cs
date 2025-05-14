using InsuranceQuoteAPI.Controllers;
using InsuranceQuoteAPI.Models;
using InsuranceQuoteAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceQuote.Tests.UnitTests
{
    public class InsuranceQuotesControllerTests
    {
        private readonly Mock<IQuoteService> _mockQuoteService;
        private readonly QuotesController _controller;

        public InsuranceQuotesControllerTests()
        {
            _mockQuoteService = new Mock<IQuoteService>();
            _controller = new QuotesController(_mockQuoteService.Object);
        }

        [Fact]
        public void SubmitQuote_ReturnsBadRequest_WhenTermIsZero()
        {
            // Arrange
            var request = new QuoteRequest
            {
                Term = 0,  // Invalid term
                SumInsured = 100000
            };

            // Act
            var result = _controller.SubmitQuote(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void SubmitQuote_ReturnsBadRequest_WhenSumInsuredIsZero()
        {
            // Arrange
            var request = new QuoteRequest
            {
                Term = 12,
                SumInsured = 0  // Invalid sum insured
            };

            // Act
            var result = _controller.SubmitQuote(request);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public void GetQuote_ReturnsOkResult_WithQuote()
        {
            // Arrange
            var quoteId = Guid.NewGuid();
            var expectedQuote = new QuoteResponse
            {
                QuoteId = quoteId,
                Term = 12,
                SumInsured = 100000,
                CreatedAt = DateTime.Now,
                CompanyQuotes = new List<CompanyQuote>
                {
                    new CompanyQuote { CompanyCode = "ACME", CompanyName = "Acme Insurance", Premium = 1000 },
                    new CompanyQuote { CompanyCode = "GLOB", CompanyName = "Global Insurers", Premium = 1200 }
                }
            };

            _mockQuoteService.Setup(service => service.GetQuote(quoteId))
                .Returns(expectedQuote);

            // Act
            var result = _controller.GetQuote(quoteId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedQuote = Assert.IsType<QuoteResponse>(okResult.Value);
            Assert.Equal(quoteId, returnedQuote.QuoteId);
            Assert.Equal(expectedQuote.Term, returnedQuote.Term);
            Assert.Equal(expectedQuote.SumInsured, returnedQuote.SumInsured);
            Assert.Equal(expectedQuote.CompanyQuotes.Count, returnedQuote.CompanyQuotes.Count);
        }

        [Fact]
        public void GetQuote_ReturnsNotFound_WhenQuoteDoesNotExist()
        {
            // Arrange
            var quoteId = Guid.NewGuid();
            _mockQuoteService.Setup(service => service.GetQuote(quoteId))
                .Returns((QuoteResponse)null);

            // Act
            var result = _controller.GetQuote(quoteId);

            // Assert
            Assert.IsType<NotFoundObjectResult>(result);
        }
    }
}
