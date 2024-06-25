using Assignment03.Models;

namespace Assignment03.DTO
{
    public class MovieDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? DirectorId { get; set; }
        public string DirectorName { get; set; }
        public int? ProducerId { get; set; }
        public string ProducerName { get; set; }
        public string Language { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? ReleaseYear { get; set; }
        public virtual ICollection<Genre> Genres { get; set; }
        public virtual ICollection<Star> Stars { get; set; }
    }
}
