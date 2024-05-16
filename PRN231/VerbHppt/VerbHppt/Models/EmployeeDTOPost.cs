using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace VerbHppt.Models
{
    public partial class EmployeeDTOPost
    {
        public EmployeeDTOPost()
        {
        }

        public string LastName { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public int? DepartmentId { get; set; }
        public string? Title { get; set; }
        public string? TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string? Address { get; set; }
    }
}
