using BookLibraryAPI.Models;
using MediatR;

namespace BookLibraryAPI.Handler.Queries.AuthorQuery
{
    public class GetAuthorsQuery : IRequest<List<Author>> { }

    public class GetAuthorByIdQuery : IRequest<Author>
    {
        public Guid Id { get; set; }
    }
    public class GetAuthorBooksByAuthorId : IRequest<List<Book>>
    {
        public Guid AuthorId { get; set; }
    }
}
