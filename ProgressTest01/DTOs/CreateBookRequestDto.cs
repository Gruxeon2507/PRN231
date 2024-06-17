using ProgressTest01.Models;
using System.ComponentModel.DataAnnotations;

namespace ProgressTest01.DTOs
{
    public class CreateBookRequestDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Title cannot be over 50 over characters")]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string PublisherName { get; set; } = string.Empty;
        [Required]
        public List<CreateBookAuthorDto> AuthorNames { get; set; } = new List<CreateBookAuthorDto>();
        [Required]
        public BookType Type { get; set; }
        [Required]
        [Range(0, 1000000000)]
        public decimal Price { get; set; }
        [Required]
        [Range(0, 1000000000)]
        public decimal Royalty { get; set; }
        [Required]
        [Range(0, 1000000000)]
        public decimal Advanced { get; set; }
        [Required]
        [MaxLength(1000, ErrorMessage = "Notes cannot be over 1000 over characters")]
        public string Notes { get; set; } = string.Empty;
    }
}
