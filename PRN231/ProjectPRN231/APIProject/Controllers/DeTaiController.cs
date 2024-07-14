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
    [Authorize]
    public class DeTaiController : ControllerBase
    {
        public readonly QLDTContext _context;

        public DeTaiController(QLDTContext context)
        {
            _context = context;
        }
        [HttpGet("GetAllDeTai")]
        public IActionResult GetAllTopics()
        {
            try
            {
                var allTopics = _context.DeTais
                                       .Include(t => t.IdGiangVienNavigation)
                                       .Include(t => t.IdSinhVienNavigation)
                                       .Select(t => new DeTaiDTO
                                       {
                                           IdDeTai = t.IdDeTai,
                                           TenDeTai = t.TenDeTai,
                                           MoTa = t.MoTa,
                                           TenGiangVien = t.IdGiangVienNavigation.Ten, // Lấy tên giảng viên
                                           TenSinhVien = t.IdSinhVienNavigation != null ? t.IdSinhVienNavigation.Ten : null, // Lấy tên sinh viên (nếu có)
                                           StartDate = t.StartDate,
                                           EndDate = t.EndDate
                                       })
                                       .ToList();

                return Ok(allTopics);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

      

       

        [HttpPut("UpdateDeTai/{id}")]
        public async Task<IActionResult> UpdateDeTai(int id, [FromBody] UpdateDeTaiDTO updatedDeTai)
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

                existingDeTai.TenDeTai = updatedDeTai.TenDeTai;
                existingDeTai.MoTa = updatedDeTai.MoTa;

                await _context.SaveChangesAsync();

                return Ok("DeTai updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }


      

    }
}
