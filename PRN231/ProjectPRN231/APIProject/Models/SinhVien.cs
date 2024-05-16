using System;
using System.Collections.Generic;

namespace APIProject.Models
{
    public partial class SinhVien
    {
        public SinhVien()
        {
            DeTais = new HashSet<DeTai>();
            SinhVienDangKyDeTais = new HashSet<SinhVienDangKyDeTai>();
        }

        public int IdSinhVien { get; set; }
        public int? IdNguoiDung { get; set; }
        public string? Khoa { get; set; }
        public string? Lop { get; set; }
        public string? Ten { get; set; }

        public virtual NguoiDung? IdNguoiDungNavigation { get; set; }
        public virtual ICollection<DeTai> DeTais { get; set; }
        public virtual ICollection<SinhVienDangKyDeTai> SinhVienDangKyDeTais { get; set; }
    }
}
