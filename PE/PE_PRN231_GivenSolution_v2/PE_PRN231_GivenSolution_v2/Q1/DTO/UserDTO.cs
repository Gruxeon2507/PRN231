using Q1.Models;

namespace Q1.DTO
{
    public class UserDTO
    {
        public int userId { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        public List<CoursesDTO> courses { get; set; }
    }
}
