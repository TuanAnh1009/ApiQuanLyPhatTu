using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QlyPhatTu.Helper;
using QlyPhatTu.IServices;
using QlyPhatTu.Services;
using System.IdentityModel.Tokens.Jwt;

namespace QlyPhatTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvatarController : ControllerBase
    {
        private readonly IAvatarServices avatarServices;

        public AvatarController()
        {
            avatarServices = new AvatarServices();
        }

        [HttpPost("uploadfile")]
        public async Task<IActionResult> UploadAvatar(IFormFile file)
        {
            try
            {
                //var token = Request.Cookies["token"];
                //var userid = GetIdFromToken(token);
                var userid = 8;
                string link = await UploadFile.Upload(file);
                var res = await avatarServices.UploadAvatar(userid, link);
                return Ok(res);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
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

