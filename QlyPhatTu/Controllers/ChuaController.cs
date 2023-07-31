using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QlyPhatTu.Dto;
using QlyPhatTu.Helper;
using QlyPhatTu.IServices;
using QlyPhatTu.Models;
using QlyPhatTu.Services;
using System.Data;

namespace QlyPhatTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class ChuaController : ControllerBase
    {
        private readonly IChuaServices chuaServices;

        public ChuaController()
        {
            chuaServices = new ChuaServices();
        }

        [HttpPost("addchua")]
        public IActionResult AddChua(ChuaDto dto)
        {
            var res = chuaServices.AddChua(dto);
            if (res.Error)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPut("updatechua")]
        public IActionResult UpdateChua(ChuaDto dto)
        {
            var res = chuaServices.UpdateChua(dto);
            if (res.Error)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpDelete("deletechua")]
        public IActionResult DeleteChua(int id)
        {
            var res = chuaServices.DeleteChua(id);
            if (res.Error)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpGet("listchua")]
        [AllowAnonymous]
        public IActionResult GetChua([FromQuery] string? tenChua, [FromQuery] Pagination? pagination)
        {
            var query = chuaServices.GetChua(tenChua);
            var Chuas = PageResult<Chua>.ToPageResult(pagination, query);
            pagination.TotalCount = query.ToList().Count;
            var res = new PageResult<Chua>(pagination, Chuas);
            if(res.Data == null)
            {
                return NotFound();
            }
            return Ok(res);
        }
    }
}
