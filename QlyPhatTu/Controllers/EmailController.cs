using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QlyPhatTu.Dto;
using QlyPhatTu.Helper;
using QlyPhatTu.IServices;
using QlyPhatTu.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace QlyPhatTu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailPassServices emailPassServices;

        public EmailController()
        {
            emailPassServices = new EmailPassServices();
        }

        [HttpPost("forgetpassword")]
        public IActionResult SendRefreshCode(string email)
        {
            var checkEmail = emailPassServices.ForgetPassword(email);
            if (checkEmail == null)
            {
                return BadRequest(new ReturnObject<string>
                {
                    Mes = "Email not exist",
                    Error = true,
                    Data = null
                });
            }
            var code = emailPassServices.CreateRefreshPassword(checkEmail);
            var Subject = "Code Refresh";
            var htmlEmail = TemplateEmailForgotPassword.TemplateHTMLEmail(code.RefreshCode, code.ExpireAt);
            var sendEmail = Sendmail.send(email, htmlEmail, Subject);
            return Ok(sendEmail);
        }

        [HttpPost("forgetpassword/refreshpassword")]
        public IActionResult RefreshPassword(RefreshwithCode dto)
        {
            var res = emailPassServices.RefreshWithPassword(dto);
            return Ok(res);
        }

        [HttpPut("changepassword")]
        [Authorize(Policy = "ADMINANDMEMBER")]
        public IActionResult ChangePassword(ChangePassword dto)
        {
            var token = Request.Cookies["token"];
            string email = GetEmailFromToken(token);
            var res = emailPassServices.ChangePassword(email, dto);
            if (res.Error)
            {
                return BadRequest(res);
            }
            return Ok(res);
        }

        private string GetEmailFromToken(string jwtToken)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(jwtToken);

            var emailClaim = token.Claims.FirstOrDefault(c => c.Type == "email");
            if (emailClaim != null)
            {
                return emailClaim.Value;
            }
            return null;
        }
    }
}
