using System.ComponentModel.DataAnnotations;

namespace QlyPhatTu.Dto
{
    public class ChangePassword
    {
        [Required]
        public string OldPassword { get; set; }
        [Required]
        public string NewPassword { get; set; }
        [Required]
        public string ReNewPassword { get; set; }
    }
}
