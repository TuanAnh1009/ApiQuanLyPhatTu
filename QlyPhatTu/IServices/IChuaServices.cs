using QlyPhatTu.Dto;
using QlyPhatTu.Helper;
using QlyPhatTu.Models;

namespace QlyPhatTu.IServices
{
    public interface IChuaServices
    {
        ReturnObject<Chua> AddChua(ChuaDto chua);
        ReturnObject<Chua> UpdateChua(ChuaDto chua);
        ReturnObject<string> DeleteChua(int chuaId);
        IQueryable<Chua> GetChua(string? tenChua);
    }
}
