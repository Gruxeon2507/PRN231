using APIProject.DTO;
using APIProject.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIProject.Controllers
{
    public class UserAuthenticationController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly QLDTContext _context;
        private readonly IMapper _mapper;

        public UserAuthenticationController(QLDTContext context, IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            _context = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO login)
        {
            var user = _context.NguoiDungs.Include(x => x.GiangViens).Where(u => u.Email == login.Email && u.MatKhau == login.MatKhau).FirstOrDefault();
            // Thực hiện xác thực người dùng ở đây và kiểm tra thông tin đăng nhập
            var map = _mapper.Map<NguoiDung>(login);

            if (IsAuthenticated(map.Email, map.MatKhau))
            {
                var token = GenerateToken(map.Email);
                //var user = _context.NguoiDungs.FirstOrDefault(x => x.Email == map.Email);
                //var role = user?.Role ?? "User";
                //return Ok(new { Token = token, Role = role });
                return Ok(new { Token = token, IdNguoiDung = user.IdNguoiDung, TenNguoiDung = user.TenNguoiDung, VaiTro = user.VaiTro });
            }

            return Unauthorized();
        }

        private bool IsAuthenticated(string email, string matkhau)
        {
            var listUser = _context.NguoiDungs.ToList();
            var checkUser = listUser.FirstOrDefault(x => x.Email == email && x.MatKhau == matkhau);
            if (checkUser != null)
            {
                return true;
            }
            return false;
        }

        private string GenerateToken(string email)
        {
            var keyBytes = Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]);

            // Đảm bảo chiều dài của khóa là đủ lớn (256 bits)
            if (keyBytes.Length < 32)
            {
                throw new InvalidOperationException("Chuỗi bí mật không đủ dài. Hãy sử dụng chuỗi bí mật đủ lớn.");
            }

            var key = new SymmetricSecurityKey(keyBytes);
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var user = _context.NguoiDungs.FirstOrDefault(x => x.Email == email);
            //var role = user?.Role ?? "User"; // Mặc định là User nếu không tìm thấy vai trò

            var claims = new List<Claim>
         {
            new Claim(ClaimTypes.Name, email),
            //new Claim(ClaimTypes.Role, role)
         };

            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddDays(10),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
