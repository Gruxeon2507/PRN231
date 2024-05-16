using APIProject.DTO;
using APIProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinhVienController : ControllerBase
    {
        public readonly QLDTContext _context;

        public SinhVienController(QLDTContext context)
        {
            _context = context;
        }
        [HttpGet("RegistrationsByStudent/{studentId}")]
        public async Task<IActionResult> GetRegistrationsByStudent(int studentId)
        {
            try
            {
                var registrations = await _context.SinhVienDangKyDeTais
                    .Include(s => s.IdSinhVienNavigation)
                    .Include(s => s.IdDeTaiNavigation)
                    .Where(s => s.IdSinhVien == studentId)
                    .ToListAsync();

                var studentRegistrationsDTO = registrations.Select(s => new SinhVienDangKyDeTaiDTO
                {
                    IdDangKy = s.IdDangKy,
                    TenSinhVien = s.IdSinhVienNavigation.Ten, // Assuming 'Ten' is the name field in 'SinhVien' table
                    TenDeTai = s.IdDeTaiNavigation.TenDeTai, // Assuming 'TenDeTai' is the name field in 'DeTai' table
                    MoTaDeTai = s.IdDeTaiNavigation.MoTa, // Assuming 'MoTaDeTai' is the description field in 'DeTai' table
                    Diem = s.Diem,
                    GhiChu = s.GhiChu
                }).ToList();

                return Ok(studentRegistrationsDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("GetAllDeTaiBySVId/{id}")]
        public async Task<ActionResult<IEnumerable<DeTaiDTO>>> GetDeTaiBySinhVienId(int id)
        {
            var deTai = await _context.DeTais
                .Where(dt => dt.IdSinhVien == id)
                .Select(dt => new DeTaiDTO
                {
                    IdDeTai = dt.IdDeTai,
                    TenDeTai = dt.TenDeTai,
                    MoTa = dt.MoTa,
                    StartDate = dt.StartDate,
                    EndDate = dt.EndDate,
                    TenGiangVien = dt.IdGiangVienNavigation.Ten, // Assumed navigation property from DeTai to GiangVien
                    TenSinhVien = dt.IdSinhVienNavigation.Ten     // Assumed navigation property from DeTai to SinhVien
                })
                .ToListAsync();

            if (deTai == null)
            {
                return NotFound();
            }

            return deTai;
        }
        [HttpPost("CreateDeTai")]
        public async Task<ActionResult<DeTai>> CreateDeTai([FromBody] CreateDeTaiDTO createDeTaiDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var deTai = new DeTai
                {
                    TenDeTai = createDeTaiDto.TenDeTai,
                    MoTa = createDeTaiDto.MoTa,
                    IdGiangVien = createDeTaiDto.IdGiangVien,
                    StartDate = createDeTaiDto.StartDate,
                    EndDate = createDeTaiDto.EndDate,
                    IdSinhVien = createDeTaiDto.IdSinhVien
                };

                _context.DeTais.Add(deTai);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetDeTai), new { id = deTai.IdDeTai }, deTai);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpGet("sinhvien-id/{userId}")]
        public ActionResult<int> GetSinhVienId(int userId)
        {
            var sinhVien = _context.SinhViens.FirstOrDefault(s => s.IdNguoiDung == userId);
            if (sinhVien == null)
            {
                return NotFound("Sinh viên không tồn tại");
            }

            return sinhVien.IdSinhVien;
        }

            // GET: api/DeTai/{id}
            [HttpGet("{id}")]
        public async Task<ActionResult<DeTai>> GetDeTai(int id)
        {
            var deTai = await _context.DeTais.FindAsync(id);

            if (deTai == null)
            {
                return NotFound();
            }
            return Ok(deTai);
        }
        [HttpGet("Deadline/{id}")]
        public ActionResult<DeadlineDTO> GetDeadline(int id)
        {
            var deadline = _context.DeTais
                                    .Where(d => d.IdDeTai == id)
                                    .Select(d => new DeadlineDTO
                                    {
                                        StartDate = d.StartDate,
                                        EndDate = d.EndDate
                                    })
                                    .FirstOrDefault();

            if (deadline == null)
            {
                return NotFound();
            }

            return deadline;
        }
        [HttpPost("dang-ky-de-tai")]
        public IActionResult DangKyDeTai([FromBody] DangKyDeTaiDTO dangKyDTO)
        {
            try
            {
                // Kiểm tra xem sinh viên có tồn tại không
                var sinhVien = _context.SinhViens.FirstOrDefault(s => s.IdSinhVien == dangKyDTO.IdSinhVien);
                if (sinhVien == null)
                {
                    return BadRequest("Sinh viên không tồn tại.");
                }

                // Kiểm tra xem đề tài có tồn tại không
                var deTai = _context.DeTais.FirstOrDefault(d => d.IdDeTai == dangKyDTO.IdDeTai);
                if (deTai == null)
                {
                    return BadRequest("Đề tài không tồn tại.");
                }

                // Kiểm tra xem sinh viên đã đăng ký đề tài này chưa
                var daDangKy = _context.SinhVienDangKyDeTais.Any(d => d.IdSinhVien == dangKyDTO.IdSinhVien && d.IdDeTai == dangKyDTO.IdDeTai);
                if (daDangKy)
                {
                    return BadRequest("Sinh viên đã đăng ký đề tài này.");
                }

                // Tạo mới bản ghi đăng ký đề tài
                var dangKyDeTai = new SinhVienDangKyDeTai
                {
                    IdSinhVien = dangKyDTO.IdSinhVien,
                    IdDeTai = dangKyDTO.IdDeTai,
                };

                _context.SinhVienDangKyDeTais.Add(dangKyDeTai);
                _context.SaveChanges();

                return Ok("Đăng ký đề tài thành công.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Lỗi nội bộ máy chủ: {ex.Message}");
            }
        }
        [HttpGet("SearchByName")]
        public async Task<ActionResult<IEnumerable<DeTaiDTO>>> SearchByName(string name)
        {
            try
            {
                // Tìm kiếm đề tài theo tên (giả sử 'TenDeTai' là trường chứa tên đề tài trong cơ sở dữ liệu)
                var deTais = await _context.DeTais
                    .Where(d => d.TenDeTai.Contains(name))
                    .Select(d => new DeTaiDTO
                    {
                        IdDeTai = d.IdDeTai,
                        TenDeTai = d.TenDeTai,
                        MoTa = d.MoTa,
                        StartDate = d.StartDate,
                        EndDate = d.EndDate,
                        TenGiangVien = d.IdGiangVienNavigation.Ten, // Giả định có navigation property từ DeTai tới GiangVien
                        TenSinhVien = d.IdSinhVienNavigation.Ten     // Giả định có navigation property từ DeTai tới SinhVien
                    })
                    .ToListAsync();

                return deTais;
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

}

