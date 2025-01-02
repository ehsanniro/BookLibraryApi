using MediatR;
using BookLibraryAPI.Models;

namespace BookLibraryAPI.Handler.Commands.BookFeature
{
    public class AbstractBookCommand : IRequest<Book>
    {
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public int PublishedYear { get; set; }
    }
    public class AddBookCommand : AbstractBookCommand
    {}

    public class UpdateBookCommand : AbstractBookCommand
    {
        public Guid Id { get; set; }
    }
}
