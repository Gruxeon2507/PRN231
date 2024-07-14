namespace Q1.DTO
{
    public class ReviewDTO
    {
        public int? courseId { get; set; }
        public string title { get; set; }
        public string reviewText { get; set; }
        public DateTime? reviewDate { get; set; }
        public int? rating { get; set; }
    }
}
