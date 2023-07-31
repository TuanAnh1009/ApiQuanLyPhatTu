using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QlyPhatTu.Dto;
using QlyPhatTu.Helper;
using QlyPhatTu.IServices;
using QlyPhatTu.Models;
using QlyPhatTu.Services;
using System.IdentityModel.Tokens.Jwt;

namespace QlyPhatTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "TRUTRI, ADMIN")]
    public class DaoTrangController : ControllerBase
    {
        private readonly IDaoTrangServices daoTrangServices;
        private readonly AppDbContext appDbContext;

        public DaoTrangController()
        {
            daoTrangServices = new DaoTrangServices();
            appDbContext = new AppDbContext();
        }

        [HttpPost("adddaotrang")]
        public IActionResult AddDaoTrang(DaoTrangDto dto)
        {
            var token = Request.Cookies["token"];
            var userId = GetIdFromToken(token);
            var user = appDbContext.PhatTu.Include(x => x.UserRoles).ThenInclude(y => y.Role).FirstOrDefault(z => z.PhatTuId == userId);
            if (user.UserRoles.Role.Code != "ADMIN")
            {
                dto.NguoiTruTri = userId;
            }
            var res = daoTrangServices.AddDaoTrang(dto);
            if(res.Error)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPut("updatedaotrang")]
        public IActionResult UpdateDaoTrang(DaoTrangDto dto)
        {
            var token = Request.Cookies["token"];
            var userId = GetIdFromToken(token);
            var user = appDbContext.PhatTu.Include(x => x.UserRoles).ThenInclude(y => y.Role).FirstOrDefault(z => z.PhatTuId == userId);
            if (user.UserRoles.Role.Code != "ADMIN")
            {
                dto.NguoiTruTri = userId;
            }
            var res = daoTrangServices.UpdateDaoTrang(dto);
            if (res.Error)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpDelete("deletedaotrang")]
        public IActionResult DeleteDaoTrang(int id)
        {
            var res = daoTrangServices.DeleteDaoTrang(id);
            if (res.Error)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpGet("listdaotrang")]
        public IActionResult ListDaoTrang([FromQuery] string? noitochuc,
            [FromQuery] Pagination? pagination)
        {
            var query = daoTrangServices.GetDaoTrang(noitochuc);
            var daotrangs = PageResult<DaoTrang>.ToPageResult(pagination, query);
            pagination.TotalCount = query.ToList().Count;
            var res = new PageResult<DaoTrang>(pagination, daotrangs);
            if(res.Data.ToList().Count() == 0)
            {
                return NotFound(res);
            }
            return Ok(res);
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
