using System.ComponentModel.DataAnnotations;

namespace ProgressTest1.Models
{
    public class Publisher
    {
        [Key]
        public int Pub_id { get; set; }
        public string Publisher_name { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        // One-To-Many
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
