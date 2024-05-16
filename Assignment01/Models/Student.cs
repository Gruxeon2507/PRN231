namespace Assignment01.Models
{
    public class Student
    {
        public string StudentCode { get; set; }
        public string FullName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public char Gender { get; set; }
        public string Course { get; set; }
        public bool StillStudying { get; set; }
        public ICollection<Transcript> Transcripts { get; set; }
    }
}
