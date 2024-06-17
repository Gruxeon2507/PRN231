using Microsoft.EntityFrameworkCore;
using ProgressTest01.DTOs;
using ProgressTest01.Helpers;
using ProgressTest01.Interfaces;
using ProgressTest01.Models;

namespace ProgressTest01.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly DataContext _context;
        public BookRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Book> CreateAsync(Book bookModel)
        {
            await _context.Books.AddAsync(bookModel);
            await _context.SaveChangesAsync();
            return bookModel;
        }

        public async Task<List<Book>> GetAllAsync(QueryObject query)
        {
            var books = _context.Books
            .Include(b => b.Publisher)
            .Include(b => b.BookAuthors)
            .ThenInclude(ba => ba.Author)
            .AsQueryable();
            if (!string.IsNullOrWhiteSpace(query.Title))
            {
                books = books.Where(b => b.Title == query.Title);
            }
            if (!string.IsNullOrWhiteSpace(query.EmailAddress))
            {
                books = books.Where(b => b.BookAuthors.Any(ba => ba.Author.Email_address == query.EmailAddress));
            }
            if (query.MinPrice.HasValue)
            {
                books = books.Where(b => b.Price >= query.MinPrice.Value);
            }
            if (query.MaxPrice.HasValue)
            {
                books = books.Where(b => b.Price <= query.MaxPrice.Value);
            }
            var skipNumber = (query.PageNumber - 1) * query.PageSize;
            return await books.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }
        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books
            .Include(b => b.Publisher)
            .Include(b => b.BookAuthors)
            .ThenInclude(ba => ba.Author).FirstOrDefaultAsync(b => b.Book_id == id);

        }

        public async Task<Book?> UpdateBookAsync(int id, BookUpdateRequestDto bookDto)
        {
            var bookModel = await _context.Books
            .Include(b => b.Publisher)
            .Include(b => b.BookAuthors)
            .ThenInclude(ba => ba.Author).FirstOrDefaultAsync(b => b.Book_id == id);
            if (bookModel == null)
            {
                return null;
            }
            bookModel.Title = bookDto.Title;
            bookModel.Type = bookDto.Type;
            bookModel.Price = bookDto.Price;
            bookModel.Royalty = bookDto.Royalty;
            bookModel.Advanced = bookDto.Advanced;
            bookModel.Notes = bookDto.Notes;
            await _context.SaveChangesAsync();
            return bookModel;
        }
    }
}
