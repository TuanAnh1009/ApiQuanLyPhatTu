using QlyPhatTu.Dto;
using QlyPhatTu.Helper;
using QlyPhatTu.Models;

namespace QlyPhatTu.IServices
{
    public interface IEmailPassServices
    {
        PhatTu ForgetPassword(string email);
        PasswordRefresh CreateRefreshPassword(PhatTu phatTu);
        ReturnObject<string> RefreshWithPassword(RefreshwithCode dto);
        ReturnObject<string> ChangePassword(string email,ChangePassword dto);
    }
}
