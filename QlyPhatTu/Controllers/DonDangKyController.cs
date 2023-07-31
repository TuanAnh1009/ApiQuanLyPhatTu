using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QlyPhatTu.Dto;
using QlyPhatTu.Helper;
using QlyPhatTu.IServices;
using QlyPhatTu.Models;
using QlyPhatTu.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace QlyPhatTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DonDangKyController : ControllerBase
    {
        private readonly IDonDangKyServices donDangKyServices;

        public DonDangKyController()
        {
            donDangKyServices = new DonDangKyServices();
        }

        [HttpPost("guidondangky")]
        [Authorize(Roles = "MEMBER")]
        public IActionResult GuiDonDangKy(DonDangKyDto dto)
        {
            var token = Request.Cookies["token"];
            var phattuid = GetIdFromToken(token);
            var res = donDangKyServices.GuiDon(phattuid, dto);
            if (res.Error)
            {
                return BadRequest(res);
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

        [HttpPost("xacnhandon")]
        [Authorize(Roles = "TRUTRI")]
        public IActionResult XacNhanDon(XacNhanDonDto dto)
        {
            var token = Request.Cookies["token"];
            var phattuid = GetIdFromToken(token);
            var res = donDangKyServices.XacNhanDon(phattuid,dto);
            if (res.Error)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [Authorize(Roles = "TRUTRI")]
        [HttpGet("listdaotrang")]
        public IActionResult ListDaoTrang([FromQuery] Pagination? pagination)
        {
            var token = Request.Cookies["token"];
            var userid = GetIdFromToken(token);
            var query = donDangKyServices.GetDaoTrangByNTT(userid);
            var daotrangs = PageResult<DaoTrang>.ToPageResult(pagination, query);
            pagination.TotalCount = query.ToList().Count();
            var res = new PageResult<DaoTrang>(pagination, daotrangs);
            if(res.Data.ToList().Count() == 0) 
            {
                return NotFound(res);
            }
            return Ok(res);
        }

        [Authorize("TRUTRI")]
        [HttpGet("listdondangky")]
        public IActionResult ListDonDangKy([FromQuery] int daotrangid,[FromQuery]Pagination? pagination)
        {
            var query = donDangKyServices.GetDonDangKyByDT(daotrangid);
            var dondangkys = PageResult<DonDangKy>.ToPageResult(pagination, query);
            pagination.TotalCount = query.ToList().Count();
            var res = new PageResult<DonDangKy>(pagination, dondangkys);
            if (res.Data.ToList().Count() == 0)
            {
                return NotFound(res);
            }
            return Ok(res);
        }
    }
}
