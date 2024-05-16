namespace Assignment01.Models
{
    public class Subject
    {
        public string SubjectCode { get; set; }
        public string SubjectName { get; set; }
        public ICollection<InstructorSubject>? InstructorSubjects { get; set; }
        public ICollection<Transcript>? Transcripts { get; set; }
    }
}
