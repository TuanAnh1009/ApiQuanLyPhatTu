using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace QlyPhatTu.Dto
{
    public class PhatTuUpdateDto
    {
        public int? PhatTuId { get; set; }
        public string? AnhChup { get; set; }
        public Boolean? DaHoanTuc { get; set; }
        public string? Email { get; set; }
        public int? GioiTinh { get; set; }
        public string? Ho { get; set; }
        public DateTime? NgayCapNhat { get; set; }
        public DateTime? NgayHoanTuc { get; set; }
        public DateTime? NgaySinh { get; set; }
        public DateTime? NgayXuatGia { get; set; }
        public string? PassWord { get; set; }
        public string? PhapDanh { get; set; }
        public string? SoDienThoai { get; set; }
        public string? Ten { get; set; }
        public string? TenDem { get; set; }
        public int? ChuaId { get; set; }
        public int? KieuThanhVienId { get; set; }
    }
}
