using MediatR;
using BookLibraryAPI.Models;
using BookLibraryAPI.Data;

namespace BookLibraryAPI.Handler.Commands.AuthorFeature
{
    public class AddAuthorHandler : IRequestHandler<AddAuthorCommand,Author>
    {
        private readonly BookLibraryContext _context;
        public AddAuthorHandler(BookLibraryContext context)
        {
            _context = context;
        }

        public async Task<Author> Handle(AddAuthorCommand request, CancellationToken cancellationToken)
        {
            var Author = new Author
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };
            _context.Authors.Add(Author);
            await _context.SaveChangesAsync(cancellationToken);
            return Author;
        }
    }

    public class UpdateAuthorHandler : IRequestHandler<UpdateAuthorCommand, Author>
    {
        private readonly BookLibraryContext _context;
        public UpdateAuthorHandler(BookLibraryContext context)
        {
            _context = context;
        }

        public async Task<Author> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _context.Authors.FindAsync(request.Id);
            if (author == null) throw new Exception("Author not found");

            author.Name = request.Name;

            _context.Authors.Update(author);
            await _context.SaveChangesAsync(cancellationToken);
            return author;
        }
    }
}
