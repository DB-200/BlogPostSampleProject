using AutoMapper;
using Books.API.Models;
using Books.API.ResourceParameters;
using Books.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookInfoRepository _bookInfoRepository;
        private readonly IMapper _mapper;

        public BooksController(IBookInfoRepository bookInfoRepository, IMapper mapper)
        {
            _bookInfoRepository = bookInfoRepository ?? throw new ArgumentNullException(nameof(bookInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        [HttpHead]
        public ActionResult<IEnumerable<BookWithoutQuotesDto>> GetBooks(
                            [FromQuery] BooksResourceParameters booksResourceParameters)
        {
            var books = _bookInfoRepository.GetBooks(booksResourceParameters);
            return Ok(_mapper.Map<IEnumerable<BookWithoutQuotesDto>>(books));
        }

        [HttpGet("{id}", Name = "GetBook")]
        public IActionResult GetBook(int id, bool includeQuotations = false)
        {
            var book = _bookInfoRepository.GetBook(id, includeQuotations);
            if (book == null)
                return NotFound();

            if (includeQuotations)
            {
                return Ok(_mapper.Map<BookDto>(book));
            }
            else
            {
                return Ok(_mapper.Map<BookWithoutQuotesDto>(book));
            }
        }

        [HttpOptions]
        public IActionResult GetBookOptions()
        {
            Response.Headers.Add("Allow", "GET, OPTIONS, POST");
            return Ok();
        }


        [HttpPost]
        public ActionResult<BookDto> CreateBook([FromBody] BookForCreationDto book)
        {
            var bookEntity = _mapper.Map<Entities.Book>(book); // map dto to entity 

            _bookInfoRepository.AddBook(bookEntity);
            _bookInfoRepository.Save();

            var bookToReturn = _mapper.Map<BookDto>(bookEntity);

            return CreatedAtRoute("GetBook",
                                    new { Id = bookToReturn.Id },
                                    bookToReturn);
        }

        [HttpDelete("{bookId}")]
        public IActionResult DeleteBook(int bookId, [FromQuery] bool deleteEvenIfHasQuotes = true)
        {
            var book = _bookInfoRepository.GetBook(bookId,true);
            if (book == null)
                return NotFound();

            bool bookHasQuotations = _bookInfoRepository.BookHasQuotations(bookId);

            // cascade delete on by default (ef core)
            bool performDelete = ((bookHasQuotations && deleteEvenIfHasQuotes) || (!bookHasQuotations)) ? true : false;
            
            if (performDelete == true)
            {
                _bookInfoRepository.DeleteBook(book);
                _bookInfoRepository.Save();
                return NoContent();
            }
            
            return BadRequest(new { InformationForAPIConsumer = "Book has quotations. Unable to delete.", 
                                    StatusCode = StatusCodes.Status400BadRequest.ToString() 
            });
        }

        [HttpPatch("{bookId}")]
        public ActionResult PartiallyUpdateBook(int bookId,
                                    JsonPatchDocument<BookForUpdateDto> jsonPatchDocument)
        {
            //  check book exists
            if (!_bookInfoRepository.BookExists(bookId))
                return NotFound();

            // get book
            var bookFromRepos = _bookInfoRepository.GetBook(bookId, false);

            if (bookFromRepos == null)
            {
                return NotFound();
                #region Upsert
                //var bookDto = new BookForUpdateDto();
                //jsonPatchDocument.ApplyTo(bookDto, ModelState);

                //if (!TryValidateModel(bookDto))
                //{
                //    return ValidationProblem(ModelState);
                //}

                //var bookToAdd = _mapper.Map<Entities.Book>(bookDto);
                //bookToAdd.Id = bookId;

                //_bookInfoRepository.AddBook(bookId, bookToAdd);
                //_bookInfoRepository.Save();

                //var bookToReturn = _mapper.Map<BookDto>(bookToAdd);

                //return CreatedAtRoute("GetBook",
                //    new { bookId = bookToReturn.Id },
                //    bookToReturn); 
                #endregion
            }

            // mapping
            var bookToPatch = _mapper.Map<BookForUpdateDto>(bookFromRepos);

            // apply
            jsonPatchDocument.ApplyTo(bookToPatch, ModelState);

            if (!TryValidateModel(bookToPatch))
            {
                return ValidationProblem(ModelState);
            }

            // mapping 
            _mapper.Map(bookToPatch, bookFromRepos);

            // repos
            _bookInfoRepository.UpdateBook(bookFromRepos);
            _bookInfoRepository.Save();

            return NoContent();
        }

        public override ActionResult ValidationProblem([ActionResultObjectValue]
                                                        ModelStateDictionary modelStateDictionary)
        {
            var options = HttpContext.RequestServices
                .GetRequiredService<IOptions<ApiBehaviorOptions>>();
            return (ActionResult)options.Value.InvalidModelStateResponseFactory(ControllerContext);
        }
    }
}









