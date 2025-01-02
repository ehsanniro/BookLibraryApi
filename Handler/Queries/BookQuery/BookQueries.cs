using BookLibraryAPI.Models;
using MediatR;

namespace BookLibraryAPI.Handler.Queries.BookQuery
{
    public class GetBooksQuery : IRequest<List<Book>>
    {}

    public class GetBookByIdQuery : IRequest<Book>
    {
        public Guid Id { get; set; }
    }
}
