namespace Assignment01.Models
{
    public class Instructor
    {
        public string TeacherCode { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<InstructorSubject>? InstructorSubjects { get; set; }
    }
}
