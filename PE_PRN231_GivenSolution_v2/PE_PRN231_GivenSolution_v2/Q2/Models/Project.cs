namespace GivenAPI.Models
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; } = null!;
        public string ProjectDescription { get; set; } = null!;
        public DateTime StartDate { get; set; } 
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; }
    }
}
