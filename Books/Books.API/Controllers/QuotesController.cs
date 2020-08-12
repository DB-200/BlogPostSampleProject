using AutoMapper;
using Books.API.Models;
using Books.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    [ApiController]
    [Route("api/books/{bookId}/quotes")]
    public class QuotesController : ControllerBase
    {
        private ILogger<QuotesController> _logger;
        private readonly IMailService _mailService;
        private readonly IBookInfoRepository _bookInfoRepository;
        private readonly IMapper _mapper;

        public QuotesController(ILogger<QuotesController> logger, IMailService mailService, 
                                IBookInfoRepository bookInfoRepository,
                                IMapper mapper)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mailService= mailService ?? throw new ArgumentNullException(nameof(mailService));
            _bookInfoRepository = bookInfoRepository ?? throw new ArgumentNullException(nameof(bookInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }
        
        [HttpGet]
        public IActionResult GetQuotesForBook(int bookId)
        {
            try
            {
                //throw new Exception("Exception example");

                //Check for book first
                if (!_bookInfoRepository.BookExists(bookId))
                {
                    _logger.LogInformation($"The book with id {bookId} was not found when trying to access quotes.");
                    return NotFound();
                }

                var quotesForBook = _bookInfoRepository.GetQuotationsForBook(bookId);

                return Ok(_mapper.Map<IEnumerable<QuoteDto>>(quotesForBook));
            }
            catch  (Exception ex)
            {
                _logger.LogCritical($"Exception whilst trying to get all quotes for book with book id {bookId}", ex);
                return StatusCode(500, "A problem occurred while handling your request.");
            }
        }

        // Single quote
        [HttpGet("{id}", Name = "GetQuote")]
        public IActionResult GetQuoteForBook(int bookId, int id)
        {
            //Check for book first
            if (!_bookInfoRepository.BookExists(bookId))
                return NotFound();

            var quote = _bookInfoRepository.GetQuotationForBook(bookId, id);
            if (quote == null)
                return NotFound();

            return Ok(_mapper.Map<QuoteDto>(quote));
        
        }

        [HttpPost]
        public IActionResult CreateQuote(int bookId,
            [FromBody] QuoteForCreationDto quote) //bookId from the URI
        {
            // older style api consumer error (not needed as API Contoller attribute 
            // ensures bad request is returned automatically if quote is null)
            // if (quote == null) 
            //    return BadRequest();

            if (!_bookInfoRepository.BookExists(bookId))
                return NotFound();

            // don't allow duplicate quotes
            var book = _bookInfoRepository.GetBook(bookId,true);
            if (book.Quotes.Count > 0)
            {
                foreach (var item in book.Quotes)
                {
                    if (string.Equals(item.Quote, 
                                      quote.Quote, 
                                      StringComparison.OrdinalIgnoreCase) == true)
                    {
                        ModelState.AddModelError("Quote", "The quote already exists. Duplicates not allowed.");
                    }
                }
            }
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // adding ----------------------------------------------------------------
            var newQuote = _mapper.Map<Entities.Quotation>(quote);

            _bookInfoRepository.AddQuoteForBook(bookId, newQuote);
            _bookInfoRepository.Save();

            //------------------------------------------------------------------------

            // return
            var createdQuoteToReturn = _mapper.Map<QuoteDto>(newQuote);

            return CreatedAtRoute("GetQuote",
                new { bookId = bookId, id = createdQuoteToReturn.Id },
                createdQuoteToReturn);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateQuote(int bookId, int id,
            [FromBody] QuoteForUpdateDto quote)
        {
            //Check book and quote exist
            if (!_bookInfoRepository.BookExists(bookId))
                return NotFound();

            var quoteEntity = _bookInfoRepository.GetQuotationForBook(bookId, id);
            if (quoteEntity == null)
                return NotFound();

            // update...
            _mapper.Map(quote, quoteEntity);

            // call to update on repository
            _bookInfoRepository.UpdateQuoteForBook(bookId, quoteEntity);

            // changes tracked by DbContext
            _bookInfoRepository.Save();

            return NoContent();
        }

        [HttpPatch("{id}")]
        public IActionResult PartiallyUpdateQuote(int bookId, int id,
            [FromBody] JsonPatchDocument<QuoteForUpdateDto> patchDoc)
        {
            //  check book exists
            if (!_bookInfoRepository.BookExists(bookId))
                return NotFound();

            // check quote exists & get data if so
            var quoteEntity = _bookInfoRepository.GetQuotationForBook(bookId, id);
            if (quoteEntity == null)
                return NotFound();

            var quoteToPatch = _mapper.Map<QuoteForUpdateDto>(quoteEntity);

            patchDoc.ApplyTo(quoteToPatch,ModelState);

            if (!TryValidateModel(quoteToPatch))
            {
                return ValidationProblem(ModelState);
            }

            // update...
            _mapper.Map(quoteToPatch, quoteEntity);

            // call to update on repository
            _bookInfoRepository.UpdateQuoteForBook(bookId, quoteEntity);

            // changes tracked by DbContext
            _bookInfoRepository.Save();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteQuote(int bookId, int id)
        {
            //  check book exists
            if (!_bookInfoRepository.BookExists(bookId))
                return NotFound();

            // check quote exists
            var quoteEntity = _bookInfoRepository.GetQuotationForBook(bookId, id);
            if (quoteEntity == null)
                return NotFound();

            _bookInfoRepository.DeleteQuote(quoteEntity);
            _bookInfoRepository.Save();

            return NoContent();
        }

        public override ActionResult ValidationProblem(
            [ActionResultObjectValue] ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices
                .GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}


