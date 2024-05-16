using System;
using System.Collections.Generic;

namespace APIProject.Models
{
    public partial class DeTai
    {
        public DeTai()
        {
            SinhVienDangKyDeTais = new HashSet<SinhVienDangKyDeTai>();
        }

        public int IdDeTai { get; set; }
        public string? TenDeTai { get; set; }
        public string? MoTa { get; set; }
        public int? IdGiangVien { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? IdSinhVien { get; set; }

        public virtual GiangVien? IdGiangVienNavigation { get; set; }
        public virtual SinhVien? IdSinhVienNavigation { get; set; }
        public virtual ICollection<SinhVienDangKyDeTai> SinhVienDangKyDeTais { get; set; }
    }
}
