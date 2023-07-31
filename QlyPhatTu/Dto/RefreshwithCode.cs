using System.ComponentModel.DataAnnotations;

namespace QlyPhatTu.Dto
{
    public class RefreshwithCode
    {
        public string Email { get; set; }
        [Required]
        public string RefreshCode { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string ReturnNewPassword { get; set; }
    }
}
