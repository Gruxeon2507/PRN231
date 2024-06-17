namespace ProgressTest01.DTOs
{
    public class CreateBookAuthorDto
    {
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string? Author_order { get; set; } = string.Empty;
        public decimal Royality_percentage { get; set; }

    }
}
