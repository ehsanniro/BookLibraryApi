using Microsoft.AspNetCore.Mvc;
using MediatR;
using BookLibraryAPI.Handler.Commands;
using BookLibraryAPI.Handler.Queries;
using BookLibraryAPI.Models;
using BookLibraryAPI.Handler.Commands.AuthorFeature;
using BookLibraryAPI.Handler.Queries.AuthorQuery;

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // POST: api/authors
        [HttpPost]
        public async Task<IActionResult> AddAuthor([FromBody] AddAuthorCommand command)
        {
            var author = await _mediator.Send(command);
            return Ok(author);
        }

        // PUT: api/authors/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAuthor(Guid id, [FromBody] UpdateAuthorCommand command)
        {
            command.Id = id;
            var author = await _mediator.Send(command);
            return Ok(author);
        }

        // GET: api/authors
        [HttpGet]
        public async Task<IActionResult> GetAuthors()
        {
            var query = new GetAuthorsQuery();
            var authors = await _mediator.Send(query);
            return Ok(authors);
        }

        // GET: api/authors/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAuthorById(Guid id)
        {
            var query = new GetAuthorByIdQuery { Id = id };
            var author = await _mediator.Send(query);
            return Ok(author);
        }

        // GET: api/authors/authorbooks/{id}
        [HttpGet("authorbooks/{id}")]
        public async Task<IActionResult> GetAuthorBooksByAuthorId(Guid id)
        {
            var query = new GetAuthorBooksByAuthorId { AuthorId = id };
            var books = await _mediator.Send(query);
            return Ok(books);
        }
    }
}
