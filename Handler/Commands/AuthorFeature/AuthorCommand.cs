using MediatR;
using BookLibraryAPI.Models;

namespace BookLibraryAPI.Handler.Commands.AuthorFeature
{
    public class AbstractAuthorCommand : IRequest<Author>
    {
        public string Name { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(Name);
        }
    }
    public class AddAuthorCommand : AbstractAuthorCommand
    {
    }

    public class UpdateAuthorCommand : AbstractAuthorCommand
    {
        public Guid Id { get; set; }
    }
}
