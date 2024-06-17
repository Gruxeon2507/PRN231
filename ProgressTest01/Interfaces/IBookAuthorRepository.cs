using ProgressTest01.Models;

namespace ProgressTest01.Interfaces
{
    public interface IBookAuthorRepository
    {
        public Task<BookAuthor> SaveBookAuthor(BookAuthor bookAuthor);
    }
}
