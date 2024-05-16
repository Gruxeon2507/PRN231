using APIProject.DTO;
using APIProject.Models;
using AutoMapper;

namespace APIProject.AutoMapper
{
    public class Mapper : Profile
    {
        public Mapper() {
            CreateMap<LoginDTO, NguoiDung>().ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                                               .ForMember(dest => dest.MatKhau, opt => opt.MapFrom(src => src.MatKhau))
                                               .ReverseMap();
            CreateMap<NguoiDung, NguoiDungDTO>().ReverseMap()
                .ForMember(dest => dest.VaiTro, opt => opt.MapFrom(src => src.VaiTro)); // Ánh xạ trường VaiTro

            CreateMap<GiangVienDTO, GiangVien>();
            CreateMap<SinhVienDTO, SinhVien>();
            CreateMap<DangKyDeTaiDTO, SinhVienDangKyDeTai>();
        } 
    }
}
