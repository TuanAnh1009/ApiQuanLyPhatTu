using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using QlyPhatTu.Dto;
using QlyPhatTu.Helper;
using QlyPhatTu.IServices;
using QlyPhatTu.Models;
using static Microsoft.Extensions.Logging.EventSource.LoggingEventSource;

namespace QlyPhatTu.Services
{
    public class UserServices : IUserServices
    {
        private readonly AppDbContext appDbContext;

        public UserServices()
        {
            appDbContext = new AppDbContext();
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public IQueryable<PhatTu> GetPhatTu(string? ten = null,
            string? phapdanh = null, 
            string? email = null, 
            int? gioitinh = null, 
            Boolean? trangthai = null)
        {
            var query = appDbContext.PhatTu.AsQueryable().Where(x => x.IsActive == true);
            if(!string.IsNullOrEmpty(ten))
            {
                query = query.Where(x => x.Ten.ToLower().Contains(ten.ToLower()));
            }
            if(!string.IsNullOrEmpty(phapdanh))
            {
                query = query.Where(x => x.PhapDanh.ToLower().Contains(phapdanh.ToLower()));
            }
            if (!string.IsNullOrEmpty(email))
            {
                query = query.Where(x => x.Email.ToLower().Contains(email.ToLower()));
            }
            if (gioitinh.HasValue)
            {
                query = query.Where(x => x.GioiTinh == gioitinh);
            }
            if (trangthai.HasValue)
            {
                query = query.Where(x => x.DaHoanTuc == trangthai);
            }
            return query;
        }

        public ReturnObject<PhatTu> GetPhatTuById(int phattuid)
        {
            try
            {
                var user = appDbContext.PhatTu.SingleOrDefault(x => x.PhatTuId == phattuid);
                if (user == null)
                {
                    throw new Exception("Not logged in");
                }
                return new ReturnObject<PhatTu>
                {
                    Mes = "Success",
                    Data = user
                };
            }
            catch (Exception ex)
            {
                return new ReturnObject<PhatTu>
                {
                    Mes = ex.Message,
                    Data = null,
                    Error = true
                };
            }
        }

        public ReturnObject<PhatTu> Login(Login dto)
        {
            var User = appDbContext.PhatTu.Include(z => z.KieuThanhVien).Include(x => x.UserRoles).ThenInclude(y => y.Role).SingleOrDefault(u => u.Email == dto.Email);
            try
            {
                if(string.IsNullOrEmpty(dto.PassWord) || string.IsNullOrEmpty(dto.Email))
                {
                    throw new Exception("Email or password can't be blank");
                }
                if (User == null || BCrypt.Net.BCrypt.Verify(dto.PassWord, User.PassWord) == false)
                {
                    throw new Exception("email or password is incorrect");
                }
                if(User.IsActive == false)
                {
                    throw new Exception("Account has been deleted");
                }
            }
            catch(Exception ex)
            {
                return new ReturnObject<PhatTu>
                {
                    Error = true,
                    Mes = ex.Message,
                    Data = null
                };
            }
            return new ReturnObject<PhatTu>
            {
                Mes = "Loggin success",
                Data = User
            };
        }

        public ReturnObject<PhatTu> Register(Register dto)
        {
            try
            {
                if(appDbContext.PhatTu.Any(x=> x.Email == dto.Email))
                {
                    throw new Exception("Email already exists");
                }
                if(!IsValidEmail(dto.Email))
                {
                    throw new Exception("Email invalidate");
                }
            }
            catch (Exception ex)
            {
                return new ReturnObject<PhatTu>
                {
                    Error = true,
                    Mes = ex.Message,
                    Data = null
                };
            }
            PhatTu CreatePhatTu = new PhatTu()
            {
                Ho = dto.Ho,
                TenDem = dto.TenDem,
                Ten = dto.Ten,
                NgaySinh = dto.NgaySinh,
                GioiTinh = dto.GioiTinh,
                Email = dto.Email,
                PassWord = BCrypt.Net.BCrypt.HashPassword(dto.PassWord),
                UserRoles = new UserRoles()
                {
                    RoleId = 2
                },
                KieuThanhVienId = 2
            };
            
            appDbContext.Add(CreatePhatTu);
            appDbContext.SaveChanges();
            return new ReturnObject<PhatTu>
            {
                Mes = "Sign Up Success",
                Data = CreatePhatTu
            };
        }

        public ReturnObject<PhatTu> UpdateUser(int phattuid, UserDto dto)
        {
            try
            {
                var user = appDbContext.PhatTu.SingleOrDefault(x => x.PhatTuId == phattuid);
                if (user == null)
                {
                    throw new Exception("Not login");
                }
                user.DaHoanTuc = dto.DaHoanTuc;
                user.Email = dto.Email;
                user.GioiTinh = dto.GioiTinh;
                user.Ho = dto.Ho;
                user.NgayHoanTuc = dto.NgayHoanTuc;
                user.NgaySinh = dto.NgaySinh;
                user.NgayXuatGia = dto.NgayXuatGia;
                user.PhapDanh = dto.PhapDanh;
                user.SoDienThoai = dto.SoDienThoai;
                user.Ten = dto.Ten;
                user.TenDem = dto.TenDem;
                user.ChuaId = dto.ChuaId;
                user.NgayCapNhat = DateTime.UtcNow;
                appDbContext.Update(user);
                appDbContext.SaveChanges();
                return new ReturnObject<PhatTu>
                {
                    Mes = "Success",
                    Data = user
                };
            }
            catch (Exception ex)
            {
                return new ReturnObject<PhatTu>
                {
                    Mes = ex.Message,
                    Data = null,
                    Error = true
                };
            }
        }
    }
}
