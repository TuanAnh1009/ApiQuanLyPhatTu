using System.ComponentModel.DataAnnotations;

namespace QlyPhatTu.Dto
{
    public class DaoTrangDto
    {
        public int DaoTrangId { get; set; }
        public Boolean? DaKetThuc { get; set; }
        public string? NoiDung { get; set; }
        [Required]
        public string? NoiToChuc { get; set; }
        public int NguoiTruTri { get; set; }
    }
}
