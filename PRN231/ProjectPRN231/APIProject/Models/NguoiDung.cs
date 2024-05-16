using System;
using System.Collections.Generic;

namespace APIProject.Models
{
    public partial class NguoiDung
    {
        public NguoiDung()
        {
            GiangViens = new HashSet<GiangVien>();
            SinhViens = new HashSet<SinhVien>();
        }

        public int IdNguoiDung { get; set; }
        public string? TenNguoiDung { get; set; }
        public string? MatKhau { get; set; }
        public int? VaiTro { get; set; }
        public string? Email { get; set; }

        public virtual ICollection<GiangVien> GiangViens { get; set; }
        public virtual ICollection<SinhVien> SinhViens { get; set; }
    }
}
