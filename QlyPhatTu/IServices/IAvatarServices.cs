using QlyPhatTu.Helper;

namespace QlyPhatTu.IServices
{
    public interface IAvatarServices
    {
        Task<string> UploadAvatar (int id, string avatarUrl);
    }
}
