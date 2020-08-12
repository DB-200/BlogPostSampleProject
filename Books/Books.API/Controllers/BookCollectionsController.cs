using AutoMapper;
using Books.API.Entities;
using Books.API.Helpers;
using Books.API.Models;
using Books.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    [ApiController]
    [Route("api/bookcollections")]
    public class BookCollectionsController : ControllerBase
    {
        private readonly IBookInfoRepository _bookInfoRepository;
        private readonly IMapper _mapper;

        public BookCollectionsController(IBookInfoRepository bookInfoRepository, IMapper mapper)
        {
            _bookInfoRepository = bookInfoRepository ?? throw new ArgumentNullException(nameof(bookInfoRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("({ids})",Name ="GetBookCollection")]
        public IActionResult GetBookCollection([FromRoute] [ModelBinder(BinderType = typeof(ArrayModelBinder))] 
                                               IEnumerable<int> ids)
        {
            if (ids == null)
                return BadRequest();

            var bookEntities = _bookInfoRepository.GetBooks(ids);

            if (ids.Count() != bookEntities.Count())
                return NotFound();

            var booksToReturn = _mapper.Map<IEnumerable<BookDto>>(bookEntities);

            return Ok(booksToReturn);
        }

        [HttpPost]
        public ActionResult<IEnumerable<BookDto>> CreateBookCollection(IEnumerable<BookForCreationDto> bookCollection)
        {
            var bookEntities = _mapper.Map<IEnumerable<Book>>(bookCollection);

            foreach (var book in bookEntities)
            {
                _bookInfoRepository.AddBook(book);
            }

            _bookInfoRepository.Save();

            var bookCollectionToReturn = _mapper.Map<IEnumerable<BookDto>>(bookEntities);
            var iDsString = string.Join(",", bookCollectionToReturn.Select(b => b.Id));

            return CreatedAtRoute("GetBookCollection", new { ids = iDsString }, bookCollectionToReturn); 
        }
    }
}



