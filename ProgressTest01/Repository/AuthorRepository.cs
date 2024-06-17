using Microsoft.EntityFrameworkCore;
using ProgressTest01.DTOs;
using ProgressTest01.Interfaces;
using ProgressTest01.Models;

namespace ProgressTest01.Repository
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly DataContext _context;

        public AuthorRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAll(int book_id)
        {
            var authors = await _context.BookAuthors
                .Where(ba => ba.Book_id == book_id)
                .Select(ba => ba.Author)
                .ToListAsync();
            if (authors == null)
            {
                return null;
            }
            return authors;
        }
        public async Task<List<Author>> GetAllAsync()
        {
            var authors = await _context.Authors.ToListAsync();
            if (authors == null)
            {
                return null;
            }
            return authors;
        }
        public async Task<bool> AuthorExist(CreateBookAuthorDto authorDto)
        {
            return await _context.Authors.AnyAsync(a => a.First_name == authorDto.FirstName && a.Last_name == authorDto.LastName);
        }
        public async Task<Author> AddAuthor(CreateBookAuthorDto authorDto)
        {
            var authorModel = new Author
            {
                Last_name = authorDto.LastName,
                First_name = authorDto.FirstName
            };
            await _context.AddAsync(authorModel);
            await _context.SaveChangesAsync();
            return authorModel;
        }

        public async Task<Author> GetAuthorFromName(CreateBookAuthorDto authorDto)
        {
            var author = await _context.Authors
                    .FirstOrDefaultAsync(a => a.First_name == authorDto.FirstName && a.Last_name == authorDto.LastName);
            if (author == null)
            {
                return null;
            }
            return author;
        }
    }
}
