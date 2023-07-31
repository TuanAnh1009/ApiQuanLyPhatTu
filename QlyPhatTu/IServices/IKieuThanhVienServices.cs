using QlyPhatTu.Dto;
using QlyPhatTu.Helper;
using QlyPhatTu.Models;

namespace QlyPhatTu.IServices
{
    public interface IKieuThanhVienServices
    {
        ReturnObject<KieuThanhVien> AddKieuThanhVien(KieuThanhVienDto dto);
        ReturnObject<KieuThanhVien> UpdateKieuThanhVien(KieuThanhVienDto dto);
        ReturnObject<string> DeleteKieuThanhVien(int id);
    }
}
