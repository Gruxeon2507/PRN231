using System.ComponentModel.DataAnnotations;

namespace ProgressTest1.DTO
{
    public class BookView
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string PublisherName { get; set; }
        public string? Country { get; set; }
        public decimal Price { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string? EmailAddress { get; set; }
    }

}
