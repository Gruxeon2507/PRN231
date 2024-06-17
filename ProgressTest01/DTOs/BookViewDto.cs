namespace ProgressTest01.DTOs
{
    public class BookViewDto
    {
        public int BookID { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? PublisherName { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<AuthorsDto> AuthorInformations { get; set; } = new List<AuthorsDto>();
    }
}
