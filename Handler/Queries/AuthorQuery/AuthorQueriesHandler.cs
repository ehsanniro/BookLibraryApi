using BookLibraryAPI.Data;
using BookLibraryAPI.Handler.Queries.BookQuery;
using BookLibraryAPI.Models;
using MediatR;

namespace BookLibraryAPI.Handler.Queries.AuthorQuery
{
    public class GetAuthorsQueryHandler : IRequestHandler<GetAuthorsQuery, List<Author>>
    {
        private readonly BookLibraryContext _context;

        public GetAuthorsQueryHandler(BookLibraryContext context)
        {
            _context = context;
        }

        public Task<List<Author>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_context.Authors.ToList());
        }
    }

    public class GetAuthorByIdQueryHandler : IRequestHandler<GetAuthorByIdQuery, Author>
    {
        private readonly BookLibraryContext _context;

        public GetAuthorByIdQueryHandler(BookLibraryContext context)
        {
            _context = context;
        }

        public async Task<Author> Handle(GetAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var author = await _context.Authors.FindAsync(request.Id);
            if (author == null) 
                throw new Exception("Author not found");
            return author;
        }
    }

    public class GetAuthorBooksByAuthorIdHandler : IRequestHandler<GetAuthorBooksByAuthorId, List<Book>>
    {
        private readonly BookLibraryContext _context;

        public GetAuthorBooksByAuthorIdHandler(BookLibraryContext context)
        {
            _context = context;
        }

        public Task<List<Book>> Handle(GetAuthorBooksByAuthorId request, CancellationToken cancellationToken)
        {
            var books = _context.Books.Where(b => b.AuthorId == request.AuthorId).ToList();
            return Task.FromResult(books);
        }
    }
}
