using ProgressTest01.DTOs;
using ProgressTest01.Helpers;
using ProgressTest01.Models;

namespace ProgressTest01.Interfaces
{
    public interface IBookRepository
    {
        public Task<List<Book>> GetAllAsync(QueryObject query);
        public Task<Book?> GetByIdAsync(int id);
        public Task<Book?> UpdateBookAsync(int id, BookUpdateRequestDto bookDto);
        public Task<Book> CreateAsync(Book bookModel);
    }
}
