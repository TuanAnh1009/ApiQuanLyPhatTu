using QlyPhatTu.Dto;
using QlyPhatTu.Helper;
using QlyPhatTu.Models;

namespace QlyPhatTu.IServices
{
    public interface IDaoTrangServices
    {
        ReturnObject<DaoTrang> AddDaoTrang(DaoTrangDto dto);
        ReturnObject<DaoTrang> UpdateDaoTrang(DaoTrangDto dto);
        ReturnObject<string> DeleteDaoTrang(int id);
        IQueryable<DaoTrang> GetDaoTrang(string? noitochuc);
    }
}
