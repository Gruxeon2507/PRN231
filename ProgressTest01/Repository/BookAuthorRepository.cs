using ProgressTest01.Interfaces;
using ProgressTest01.Models;

namespace ProgressTest01.Repository
{
    public class BookAuthorRepository : IBookAuthorRepository
    {
        private readonly DataContext _context;
        public BookAuthorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<BookAuthor> SaveBookAuthor(BookAuthor bookAuthor)
        {
            await _context.BookAuthors.AddAsync(bookAuthor);
            await _context.SaveChangesAsync();
            return bookAuthor;

        }
    }
}
