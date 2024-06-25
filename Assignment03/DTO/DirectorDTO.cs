namespace Assignment03.DTO
{
    public class DirectorDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Description { get; set; }
        public DateTime Dob { get; set; }
        public string DobString { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public List<MovieDTO> Movies { get; set; }
    }
}
