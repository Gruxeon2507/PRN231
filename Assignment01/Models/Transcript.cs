namespace Assignment01.Models
{
    public class Transcript
    {
        public string StudentCode { get; set; }
        public Student Student { get; set; }
        public string SubjectCode { get; set; }
        public Subject Subject { get; set; }
        public decimal HighestScore { get; set; }
    }
}
