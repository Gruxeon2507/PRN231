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


    public class GiangVienController : ControllerBase
    {
        public readonly QLDTContext _context;

        public GiangVienController(QLDTContext context)
        {
            _context = context;
        }


        [HttpGet("StudentsRegisteredByProfessor/{id}")]
        public async Task<IActionResult> GetStudentsRegisteredByProfessor(int id)
        {
            try
            {
                var studentRegistrations = await _context.SinhVienDangKyDeTais
                    .Include(s => s.IdSinhVienNavigation)
                    .Include(s => s.IdDeTaiNavigation)
                    .Where(s => s.IdDeTaiNavigation.IdGiangVien == id)
                    .Select(s => new SinhVienDangKyDeTaiDTO
                    {
                        IdDangKy = s.IdDangKy,
                        TenSinhVien = s.IdSinhVienNavigation.Ten, // Assuming 'Ten' is the name field in 'SinhVien' table
                        TenDeTai = s.IdDeTaiNavigation.TenDeTai,   // Assuming 'TenDeTai' is the name field in 'DeTai' table
                        MoTaDeTai = s.IdDeTaiNavigation.MoTa,     // Assuming 'MoTa' is the description field in 'DeTai' table
                        Diem = s.Diem ?? 0, // If Diem is null, set it to 0
                        GhiChu = s.GhiChu ?? "" // If GhiChu is null, set it to an empty string
                    })
                    .ToListAsync();

                return Ok(studentRegistrations);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GiangVien-id/{userId}")]
        public ActionResult<int> GetGvId(int userId)
        {
            var giangVien = _context.GiangViens.FirstOrDefault(s => s.IdNguoiDung == userId);
            if (giangVien == null)
            {
                return NotFound("Giang viên không tồn tại");
            }

            return giangVien.IdGiangVien;
        }






        [HttpPut("getMark/{IdDangKy}")]
        public async Task<IActionResult> getMark(int IdDangKy, [FromBody] ChamDiemDTO updatedRegistration)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingRegistration = await _context.SinhVienDangKyDeTais.FindAsync(IdDangKy);

                if (existingRegistration == null)
                {
                    return NotFound("Registration not found.");
                }

                existingRegistration.Diem = updatedRegistration.Diem;
                existingRegistration.GhiChu = updatedRegistration.GhiChu;

                _context.Entry(existingRegistration).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok("Registration updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPut("Deadline/{id}")]
        public async Task<IActionResult> Deadline(int id, [FromBody] DeadlineDTO updatedDeTai)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var existingDeTai = await _context.DeTais.FindAsync(id);

                if (existingDeTai == null)
                {
                    return NotFound("DeTai not found.");
                }
                existingDeTai.StartDate = updatedDeTai.StartDate;
                existingDeTai.EndDate = updatedDeTai.EndDate;

                _context.Entry(existingDeTai).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return Ok("Deadline updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
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
    }
}
