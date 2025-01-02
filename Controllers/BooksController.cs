using Microsoft.AspNetCore.Mvc;
using MediatR;
using BookLibraryAPI.Handler.Commands;
using BookLibraryAPI.Handler.Commands.BookFeature;
using Microsoft.AspNetCore.Http.HttpResults;
using BookLibraryAPI.Models;
using BookLibraryAPI.Handler.Queries.BookQuery;
//using BookLibraryAPI.Handler.Querie

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BooksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddBook([FromBody] AddBookCommand command)
        {
            var book = await _mediator.Send(command);
            return Ok(book);
        }

        // PUT: api/books/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(Guid id, [FromBody] UpdateBookCommand command)
        {
            command.Id = id;
            var book = await _mediator.Send(command);
            return Ok(book);
        }

        // GET: api/books
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var query = new GetBooksQuery();
            var books = await _mediator.Send(query);
            return Ok(books);
        }

        // GET: api/books/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var query = new GetBookByIdQuery { Id = id };
            var book = await _mediator.Send(query);
            return Ok(book);
        }
    }
}
