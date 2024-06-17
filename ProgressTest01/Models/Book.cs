using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProgressTest01.Models
{
    public class Book
    {
        [Key]
        public int Book_id { get; set; }
        public string Title { get; set; } = string.Empty;
        public BookType Type { get; set; }
        public int? Pub_id { get; set; }
        // Many-To-One
        public Publisher? Publisher { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        // tiền tạm ứng cho tác giả
        [Column(TypeName = "decimal(18,2)")]
        public decimal Advanced { get; set; }
        // tiền bản quyền của tác giả
        [Column(TypeName = "decimal(18,2)")]
        public decimal Royalty { get; set; }
        // số lượng sách đã bán đến thời điểm hiện tại
        public long Ytd_sales { get; set; }
        public string Notes { get; set; } = string.Empty;
        public DateTime Published_date { get; set; }

        public List<BookAuthor> BookAuthors { get; set; } = new List<BookAuthor>();
    }
}
