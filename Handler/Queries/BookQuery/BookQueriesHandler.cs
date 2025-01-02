using MediatR;
using BookLibraryAPI.Models;
using BookLibraryAPI.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace BookLibraryAPI.Handler.Queries.BookQuery
{
    public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, List<Book>>
    {
        private readonly BookLibraryContext _context;

        public GetBooksQueryHandler(BookLibraryContext context)
        {
            _context = context;
        }

        public Task<List<Book>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_context.Books.ToList());
        }
    }

    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly BookLibraryContext _context;

        public GetBookByIdQueryHandler(BookLibraryContext context)
        {
            _context = context;
        }

        public async Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);
            if (book == null) 
                throw new Exception("Book not found");
            return book;
        }
    }
}
