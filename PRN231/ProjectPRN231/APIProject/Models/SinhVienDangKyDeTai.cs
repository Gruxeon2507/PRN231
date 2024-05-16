using System;
using System.Collections.Generic;

namespace APIProject.Models
{
    public partial class SinhVienDangKyDeTai
    {
        public int IdDangKy { get; set; }
        public int? IdSinhVien { get; set; }
        public int? IdDeTai { get; set; }
        public double? Diem { get; set; }
        public string? GhiChu { get; set; }

        public virtual DeTai? IdDeTaiNavigation { get; set; }
        public virtual SinhVien? IdSinhVienNavigation { get; set; }
    }
}
