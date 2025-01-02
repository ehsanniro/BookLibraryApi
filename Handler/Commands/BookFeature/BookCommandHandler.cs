using MediatR;
using BookLibraryAPI.Models;
using BookLibraryAPI.Data;

namespace BookLibraryAPI.Handler.Commands.BookFeature
{
    public class AddBookHandler : IRequestHandler<AddBookCommand, Book>
    {
        private readonly BookLibraryContext _context;
        public AddBookHandler(BookLibraryContext context)
        {
            _context = context;
        }

        public async Task<Book> Handle(AddBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                AuthorId = request.AuthorId,
                PublishedYear = request.PublishedYear
            };
            _context.Books.Add(book);
            await _context.SaveChangesAsync(cancellationToken);
            return book;
        }
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Book>
    {
        private readonly BookLibraryContext _context;

        public UpdateBookCommandHandler(BookLibraryContext context) 
        {
            _context = context;
        }
        public async Task<Book> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = await _context.Books.FindAsync(request.Id);
            if (book == null) throw new Exception("Book not found");

            book.Title = request.Title;
            book.AuthorId = request.AuthorId;
            book.PublishedYear = request.PublishedYear;

            _context.Books.Update(book);
            await _context.SaveChangesAsync(cancellationToken);
            return book;
        }
    }
}