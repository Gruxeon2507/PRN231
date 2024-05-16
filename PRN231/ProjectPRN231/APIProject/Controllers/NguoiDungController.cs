using APIProject.DTO;
using APIProject.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NguoiDungController : ControllerBase
    {
        private readonly QLDTContext _context;
        private readonly IMapper _mapper;
        public NguoiDungController(QLDTContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddUser([FromBody] NguoiDungDTO userDTO)
        {
            try
            {
                var user = _mapper.Map<NguoiDung>(userDTO);
                _context.NguoiDungs.Add(user);
                await _context.SaveChangesAsync();
                return Ok("User added successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("add-giangvien")]
        public IActionResult AddGiangVien([FromBody] GiangVienDTO giangVienDTO)
        {
            try
            {
                var giangVien = _mapper.Map<GiangVien>(giangVienDTO);

                // Lấy id người dùng cuối cùng
                int lastUserId = _context.NguoiDungs.Max(u => u.IdNguoiDung);


                giangVien.IdNguoiDung = lastUserId + 1; // Gán id người dùng mới
                _context.GiangViens.Add(giangVien);

                // Cập nhật vai trò của người dùng thành 1 (giảng viên)
                var user = _context.NguoiDungs.SingleOrDefault(u => u.IdNguoiDung == lastUserId + 1);
                if (user != null)
                {
                    user.VaiTro = 1;
                    _context.SaveChanges();
                }

                return Ok("Giang vien da duoc them thanh cong.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("add-sinhvien")]
        public IActionResult AddSinhVien([FromBody] SinhVienDTO sinhVienDTO)
        {
            try
            {
                var sinhVien = _mapper.Map<SinhVien>(sinhVienDTO);

                // Lấy id người dùng cuối cùng
                int lastUserId = _context.NguoiDungs.Max(u => u.IdNguoiDung);


                sinhVien.IdNguoiDung = lastUserId + 1; // Gán id người dùng mới
                _context.SinhViens.Add(sinhVien);

                // Cập nhật vai trò của người dùng thành 2 (sinh viên)
                var user = _context.NguoiDungs.SingleOrDefault(u => u.IdNguoiDung == lastUserId + 1);
                if (user != null)
                {
                    user.VaiTro = 2;
                    _context.SaveChanges();
                }

                return Ok("Sinh vien da duoc them thanh cong.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

    }
}