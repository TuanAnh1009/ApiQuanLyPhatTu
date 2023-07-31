using QlyPhatTu.Dto;
using QlyPhatTu.Helper;
using QlyPhatTu.Models;

namespace QlyPhatTu.IServices
{
    public interface IDonDangKyServices
    {
        ReturnObject<DonDangKy> GuiDon(int phattuid, DonDangKyDto dto);
        ReturnObject<DonDangKy> XacNhanDon(int userid, XacNhanDonDto dto);
        IQueryable<DaoTrang> GetDaoTrangByNTT(int nguoitrutri);
        IQueryable<DonDangKy> GetDonDangKyByDT(int daotrangid);
    }
}
