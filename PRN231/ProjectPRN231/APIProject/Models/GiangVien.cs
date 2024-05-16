using System;
using System.Collections.Generic;

namespace APIProject.Models
{
    public partial class GiangVien
    {
        public GiangVien()
        {
            DeTais = new HashSet<DeTai>();
        }

        public int IdGiangVien { get; set; }
        public int? IdNguoiDung { get; set; }
        public string? Ten { get; set; }
        public string? Khoa { get; set; }
        public string? ChucVu { get; set; }

        public virtual NguoiDung? IdNguoiDungNavigation { get; set; }
        public virtual ICollection<DeTai> DeTais { get; set; }
    }
}
