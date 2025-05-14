using InsuranceQuoteAPI.Models;
using InsuranceQuoteAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InsuranceQuoteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuoteService _quoteService;

        public QuotesController(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpPost]
        public IActionResult SubmitQuote([FromBody] QuoteRequest request)
        {
            if (request.Term <= 0)
            {
                return BadRequest("Term must be greater than 0");
            }

            if (request.SumInsured <= 0)
            {
                return BadRequest("Sum insured must be greater than 0");
            }

            var quoteId = _quoteService.CreateQuote(request);
            return Ok(new { QuoteId = quoteId });
        }

        [HttpGet("{id}")]
        public IActionResult GetQuote(Guid id)
        {
            var quote = _quoteService.GetQuote(id);
            if (quote == null)
            {
                return NotFound($"Quote with ID {id} not found");
            }

            return Ok(quote);
        }
    }
}
