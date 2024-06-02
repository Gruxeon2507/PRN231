namespace Assignment02.Models
{
    public class MedicalFacility
    {
        public int FacilityId { get; set; }
        public string FacilityName { get; set; }
        public int NoDoctors { get; set; }
        public int NoStaffs { get; set; }
        public bool PrivateFacility { get; set; } // true for private, false for public
        public int Level { get; set; } // Levels 1-5
    }
}
