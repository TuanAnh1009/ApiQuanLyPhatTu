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
    public class PhatTuController : ControllerBase
    {
        private readonly IPhatTuServices phatTuServices;


        public PhatTuController()
        {
            phatTuServices = new PhatTuServices();
        }

        [HttpPost("addphattu")]
        public IActionResult AddPhatTu(PhatTuDto dto)
        {
            var res = phatTuServices.AddPhatTu(dto);
            if(res.Error)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpPut("updatephattu")]
        public IActionResult UpdatePhatTu(PhatTuUpdateDto dto)
        {
            var res = phatTuServices.UpdatePhatTu(dto);
            if (res.Error)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        [HttpDelete("deletephattu")]
        public IActionResult DeletePhatTu(int id)
        {
            var res = phatTuServices.DeletePhatTu(id);
            if (res.Error)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }
    }
}
