using ProgressTest01.DTOs;
using ProgressTest01.Models;

namespace ProgressTest01.Interfaces
{
    public interface IAuthorRepository
    {
        public Task<List<Author>> GetAll(int book_id);
        public Task<List<Author>> GetAllAsync();
        public Task<bool> AuthorExist(CreateBookAuthorDto authorDto);
        public Task<Author> AddAuthor(CreateBookAuthorDto authorDto);
        public Task<Author> GetAuthorFromName(CreateBookAuthorDto authorDto);
    }
}
