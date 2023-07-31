using System.ComponentModel.DataAnnotations;

namespace QlyPhatTu.Dto
{
    public class Login
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string PassWord { get; set; }
    }
}
