using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using QlyPhatTu.Dto;
using QlyPhatTu.Helper;
using QlyPhatTu.IServices;
using QlyPhatTu.Models;
using QlyPhatTu.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace QlyPhatTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        private readonly IUserServices userServices;
        //private readonly Appsettings appsettings;
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment webHostEnvironment;
        public UserControllers(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            userServices = new UserServices();
            this.configuration = configuration;
            this.webHostEnvironment = webHostEnvironment;   
        }

        [HttpGet("listphattu")]
        [Authorize(Roles = "ADMIN")]
        public IActionResult GetPhatTu([FromQuery] string? ten,
            [FromQuery] string? phapdanh = null,
            [FromQuery] string? email = null,
            [FromQuery] int? gioitinh = null,
            [FromQuery] Boolean? trangthai = null,
            [FromQuery] Pagination? pagination = null)
        {
            var query = userServices.GetPhatTu(ten, phapdanh, email, gioitinh, trangthai);
            var PhatTus = PageResult<PhatTu>.ToPageResult(pagination, query);
            pagination.TotalCount = query.Count();
            var res = new PageResult<PhatTu>(pagination!, PhatTus);
            if(res == null)
            {
                return NotFound();
            } 
            return Ok(res);
        }

        [HttpPost("register")]
        public IActionResult Register(Register dto)
        {
            var res = userServices.Register(dto);
            if (res.Error)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPost("login")]
        public IActionResult Login(Login dto)
        {
            var res = userServices.Login(dto);
            if (res.Error)
            {
                return Unauthorized(res);
            }
            var token = GenerateToken(res.Data);
            Response.Cookies.Append("token", token, new CookieOptions
            {
                HttpOnly = true,
            });
            return Ok(new
            {
               Message = res.Mes,
               Token = token
            });
        }

        [Authorize]
        [HttpGet("user")]
        public IActionResult GetUserById()
        {
            var token = Request.Cookies["token"];
            int  id = GetIdFromToken(token);
            var res = userServices.GetPhatTuById(id);
            if (res.Error)
            {
                return NotFound(res);
            }
            return Ok(res);
        }

        [Authorize]
        [HttpPost("updateuser")]
        public IActionResult UpdateUser(UserDto dto)
        {
            var token = Request.Cookies["token"];
            int id = GetIdFromToken(token);
            var res = userServices.UpdateUser(id, dto);
            if (res.Error)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        private string GenerateToken(PhatTu phatTu)
        {
            var Token = new JwtSecurityTokenHandler();
            //var SecretKeyBytes = Encoding.UTF8.GetBytes(appsettings.SecretKey);
            var SecretKeyBytes = Encoding.UTF8.GetBytes(configuration["Appsettings:SecretKey"]);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, phatTu.Email),
                    new Claim(ClaimTypes.Name, phatTu.Ho+phatTu.TenDem+phatTu.Ten),
                    new Claim("PhatTuId", phatTu.PhatTuId.ToString()),
                    //role
                    new Claim(ClaimTypes.Role, phatTu.UserRoles.Role.Code),
                    new Claim(ClaimTypes.Role, phatTu.KieuThanhVien.Code)
                }),
                Expires = DateTime.UtcNow.AddMinutes(20),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(SecretKeyBytes), SecurityAlgorithms.HmacSha512Signature)
            };
            var TokenHandler = Token.CreateToken(tokenDescription);
            return Token.WriteToken(TokenHandler);
        }
        private int GetIdFromToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);

            var idClaim = token.Claims.FirstOrDefault(c => c.Type == "PhatTuId");
            return int.Parse(idClaim.Value);
        }
    }
}
