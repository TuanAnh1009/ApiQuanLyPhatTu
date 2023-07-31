using QlyPhatTu.Dto;
using QlyPhatTu.Helper;
using QlyPhatTu.Models;

namespace QlyPhatTu.IServices
{
    public interface IUserServices
    {
        ReturnObject<PhatTu> Register(Register dto);
        ReturnObject<PhatTu> Login(Login dto);
        IQueryable<PhatTu> GetPhatTu(string? ten = null, string? phapdanh = null, string? email = null, int? gioitinh = null, Boolean? trangthai = null);
        ReturnObject<PhatTu> GetPhatTuById(int phattuid);
        ReturnObject<PhatTu> UpdateUser(int phattuid, UserDto dto);
    }
}
