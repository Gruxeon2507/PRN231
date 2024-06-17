using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.EntityFrameworkCore;
using ProgressTest1.DTO;
using ProgressTest1.Models;

namespace ProgressTest1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly DataContext _context;

        public BooksController(DataContext context)
        {
            _context = context;
        }

        // GET: api/books
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            var query = _context.Books
            .Include(b => b.Publisher)
            .Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
            .Select(book => new BookView
            {
                Title = book.Title,
                PublisherName = book.Publisher.Publisher_name,
                Country = book.Publisher.Country,
                Price = book.Price,
                LastName = book.BookAuthors.FirstOrDefault().Author.Last_name,
                FirstName = book.BookAuthors.FirstOrDefault().Author.First_name,
                EmailAddress = book.BookAuthors.FirstOrDefault().Author.Email_address
            }).AsQueryable();


            return Ok(query);
        }


        // GET: api/books/5
        [HttpGet("{key}")]
        [EnableQuery]

        public IQueryable<BookView> Get(int key)
        {
            var query = _context.Books
                .Where(b => b.Book_id == key)
                .Include(b => b.Publisher)
                .Include(b => b.BookAuthors).ThenInclude(ba => ba.Author)
                .Select(book => new BookView
                {
                    BookId = book.Book_id,
                    Title = book.Title,
                    PublisherName = book.Publisher.Publisher_name,
                    Country = book.Publisher.Country,
                    Price = book.Price,
                    LastName = book.BookAuthors.FirstOrDefault().Author.Last_name,
                    FirstName = book.BookAuthors.FirstOrDefault().Author.First_name,
                    EmailAddress = book.BookAuthors.FirstOrDefault().Author.Email_address
                }).AsQueryable();

            return query;
        }

        // POST: api/books
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BookView bookView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                // Check if the author already exists
                var existingAuthor = await _context.Authors
                    .FirstOrDefaultAsync(a => a.Last_name == bookView.LastName && a.First_name == bookView.FirstName);

                if (existingAuthor == null)
                {
                    // If the author doesn't exist, create a new one
                    var newAuthor = new Author
                    {
                        Last_name = bookView.LastName,
                        First_name = bookView.FirstName,
                        Email_address = bookView.EmailAddress
                    };

                    _context.Authors.Add(newAuthor);
                    await _context.SaveChangesAsync();

                    var existingPublisher = await _context.Publishers
                    .FirstOrDefaultAsync(a => a.Publisher_name == bookView.PublisherName);
                    if (existingPublisher == null)
                    {
                        var newPublisher = new Publisher
                        {
                            Publisher_name = bookView.PublisherName,

                        };

                        _context.Publishers.Add(newPublisher);
                        await _context.SaveChangesAsync();
                    }
                    // Now associate the new author with the book
                    var book = new Book
                    {
                        Title = bookView.Title,
                        Price = bookView.Price,
                        Publisher = await _context.Publishers.FirstOrDefaultAsync(p => p.Publisher_name == bookView.PublisherName),
                        Published_date = DateTime.UtcNow,
                        BookAuthors = new List<BookAuthor>
                        {
                            new BookAuthor
                            {
                                Author = newAuthor,
                                Royality_percentage = 0.0m // Set appropriate royalty percentage
                            }
                        }
                    };

                    _context.Books.Add(book);
                    await _context.SaveChangesAsync();

                    return Ok(book);
                }
                else
                {
                    var existingPublisher = await _context.Publishers
                    .FirstOrDefaultAsync(a => a.Publisher_name == bookView.PublisherName);
                    if(existingPublisher == null)
                    {
                        var newPublisher =  new Publisher
                        {
                            Publisher_name = bookView.PublisherName,
                            
                        };

                        _context.Publishers.Add(newPublisher);
                        await _context.SaveChangesAsync();
                    }
                    // If the author already exists, just create the book
                    var book = new Book
                    {
                        Title = bookView.Title,
                        Price = bookView.Price,
                        Publisher = await _context.Publishers.FirstOrDefaultAsync(p => p.Publisher_name == bookView.PublisherName),
                        Published_date = DateTime.UtcNow,
                        BookAuthors = new List<BookAuthor>
                        {
                            new BookAuthor
                            {
                                Author = existingAuthor,
                                Royality_percentage = 0.0m // Set appropriate royalty percentage
                            }
                        }
                    };

                    _context.Books.Add(book);
                    await _context.SaveChangesAsync();

                    return Ok(book);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/books/5
        [HttpPut("{key}")]
        public async Task<IActionResult> Put(int key, [FromBody] BookView bookView)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != bookView.BookId)
            {
                return BadRequest();
            }

            try
            {
                // Check if the book exists
                var existingBook = await _context.Books.FindAsync(key);

                if (existingBook == null)
                {
                    return NotFound();
                }

                // Update the existing book
                existingBook.Title = bookView.Title;
                existingBook.Price = bookView.Price;

                // Update associated entities if necessary (e.g., Publisher, Author)
                existingBook.Publisher = await _context.Publishers.FirstOrDefaultAsync(p => p.Publisher_name == bookView.PublisherName);

                // Save changes
                _context.Entry(existingBook).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/books/5
        [HttpDelete("{key}")]
        public async Task<IActionResult> Delete(int key)
        {
            try
            {
                var book = await _context.Books.FindAsync(key);

                if (book == null)
                {
                    return NotFound();
                }

                _context.Books.Remove(book);
                await _context.SaveChangesAsync();

                return Ok(book);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}
