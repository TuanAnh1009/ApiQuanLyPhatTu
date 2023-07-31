using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QlyPhatTu.Dto;
using QlyPhatTu.IServices;
using QlyPhatTu.Services;

namespace QlyPhatTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "ADMIN")]
    public class KieuThanhVienController : ControllerBase
    {
        private readonly IKieuThanhVienServices kieuThanhVienServices;

        public KieuThanhVienController()
        {
            kieuThanhVienServices = new KieuThanhVienServices();
        }

        [HttpPost("addkieuthanhvien")]
        public IActionResult AddKieuThanhVien(KieuThanhVienDto dto)
        {
            var res = kieuThanhVienServices.AddKieuThanhVien(dto);
            if (res.Error)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPut("updatekieuthanhvien")]
        public IActionResult UpdateKieuThanhVien(KieuThanhVienDto dto)
        {
            var res = kieuThanhVienServices.UpdateKieuThanhVien(dto);
            if (res.Error)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpDelete("deletekieuthanhvien")]
        public IActionResult DeleteKieuThanhVien(int id)
        {
            var res = kieuThanhVienServices.DeleteKieuThanhVien(id);
            if (res.Error)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
    }
}
