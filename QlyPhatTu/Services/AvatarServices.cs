using Microsoft.AspNetCore.Authorization;
using QlyPhatTu.Helper;
using QlyPhatTu.IServices;
using QlyPhatTu.Models;

namespace QlyPhatTu.Services
{
    public class AvatarServices : IAvatarServices
    {
        private readonly AppDbContext appDbContext;

        public AvatarServices()
        {
            appDbContext = new AppDbContext();
        }

        public async Task<string> UploadAvatar(int id, string avatarUrl)
        {

            var user = appDbContext.PhatTu.SingleOrDefault(x => x.PhatTuId == id);
            if (user == null)
            {
                throw new Exception("Not logged in");
            }
            user.AnhChup = avatarUrl;
            appDbContext.Update(user);
            appDbContext.SaveChanges();
            return "success";
        }
    }
}
