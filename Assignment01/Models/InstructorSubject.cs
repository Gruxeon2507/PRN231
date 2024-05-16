namespace Assignment01.Models
{
    public class InstructorSubject
    {
        public string TeacherCode { get; set; }
        public Instructor? Instructor { get; set; }
        public string SubjectCode { get; set; }
        public Subject? Subject { get; set; }
    }
}
