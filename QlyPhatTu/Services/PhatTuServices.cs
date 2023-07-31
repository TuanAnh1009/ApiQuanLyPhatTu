using QlyPhatTu.Dto;
using QlyPhatTu.Helper;
using QlyPhatTu.IServices;
using QlyPhatTu.Models;

namespace QlyPhatTu.Services
{
    public class PhatTuServices:IPhatTuServices
    {
        private readonly AppDbContext appDbContext;

        public PhatTuServices()
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
        public ReturnObject<PhatTu> AddPhatTu(PhatTuDto dto)
        {
            try
            {
                if (!IsValidEmail(dto.Email))
                {
                    throw new Exception("Email invalidate");
                }
                if (appDbContext.PhatTu.Any(x => x.Email == dto.Email))
                {
                    throw new Exception("Email already exists");
                }
                var addPhatTu = new PhatTu
                {
                    DaHoanTuc = dto.DaHoanTuc,
                    Email = dto.Email,
                    GioiTinh = dto.GioiTinh,
                    Ho = dto.Ho,
                    NgayCapNhat = dto.NgayCapNhat,
                    NgayHoanTuc = dto?.NgayHoanTuc,
                    NgaySinh = dto?.NgaySinh,
                    NgayXuatGia = dto?.NgayXuatGia,
                    PassWord = dto.PassWord,
                    PhapDanh = dto?.PhapDanh,
                    SoDienThoai = dto?.SoDienThoai,
                    Ten = dto?.Ten,
                    TenDem = dto?.TenDem,
                    ChuaId = dto?.ChuaId,
                    KieuThanhVienId = dto?.KieuThanhVienId
                };
                appDbContext.Add(addPhatTu);
                appDbContext.SaveChanges();
                return new ReturnObject<PhatTu>
                {
                    Mes = "Create success",
                    Data = addPhatTu
                };
            }
            catch (Exception ex)
            {
                return new ReturnObject<PhatTu>
                {
                    Mes = ex.Message,
                    Error = true,
                    Data = null
                };
            }
        }

        public ReturnObject<string> DeletePhatTu(int phatTuId)
        {
            try
            {
                var delPhatTu = appDbContext.PhatTu.SingleOrDefault(x => x.PhatTuId == phatTuId);
                if(delPhatTu == null)
                {
                    throw new Exception("not exist");
                }
                delPhatTu.IsActive = false;
                appDbContext.Update(delPhatTu);
                appDbContext.SaveChanges();
                return new ReturnObject<string>
                {
                    Mes = "Delete success",
                    Data = null
                };
            }
            catch(Exception ex)
            {
                return new ReturnObject<string>
                {
                    Mes = "Not exist",
                    Error = true,
                    Data = null
                };
            }
        }

        public ReturnObject<PhatTu> UpdatePhatTu(PhatTuUpdateDto dto)
        {
            try
            {
                var updatePhatTu = appDbContext.PhatTu.SingleOrDefault(x => x.PhatTuId == dto.PhatTuId);
                if(updatePhatTu == null)
                {
                    throw new Exception("Not exists");
                }
                if (appDbContext.PhatTu.Any(x => x.Email == dto.Email))
                {
                    throw new Exception("Email already exists");
                }

                if (!string.IsNullOrEmpty(dto.AnhChup))
                    updatePhatTu.AnhChup = dto.AnhChup;
                if(dto.DaHoanTuc.HasValue)
                    updatePhatTu.DaHoanTuc = dto.DaHoanTuc;
                if(!string.IsNullOrEmpty(dto.Email))
                    updatePhatTu.Email = dto.Email;
                if (dto.GioiTinh.HasValue)
                    updatePhatTu.GioiTinh = dto.GioiTinh;
                if (!string.IsNullOrEmpty(dto.Ho))
                    updatePhatTu.Ho = dto.Ho;
                if (dto.NgayHoanTuc.HasValue)
                    updatePhatTu.NgayHoanTuc = dto.NgayHoanTuc;
                if (dto.NgaySinh.HasValue)
                    updatePhatTu.NgaySinh = dto.NgaySinh;
                if (dto.NgayXuatGia.HasValue)
                    updatePhatTu.NgayXuatGia = dto?.NgayXuatGia;
                if (!string.IsNullOrEmpty(dto.PassWord))
                    updatePhatTu.PassWord =BCrypt.Net.BCrypt.HashPassword(dto.PassWord);
                if (!string.IsNullOrEmpty(dto.PhapDanh))
                    updatePhatTu.PhapDanh = dto.PhapDanh;
                if (!string.IsNullOrEmpty(dto.SoDienThoai))
                    updatePhatTu.SoDienThoai = dto.SoDienThoai;
                if (!string.IsNullOrEmpty(dto.Ten))
                    updatePhatTu.Ten = dto?.Ten;
                if (!string.IsNullOrEmpty(dto.TenDem))
                    updatePhatTu.TenDem = dto?.TenDem;
                if (dto.ChuaId.HasValue)
                    updatePhatTu.ChuaId = dto?.ChuaId;
                if (dto.KieuThanhVienId.HasValue)
                    updatePhatTu.KieuThanhVienId = dto?.KieuThanhVienId;
                updatePhatTu.NgayCapNhat = DateTime.UtcNow;
                appDbContext.Update(updatePhatTu);
                appDbContext.SaveChanges();
                return new ReturnObject<PhatTu>
                {
                    Mes = "Create success",
                    Data = updatePhatTu
                };
            }
            catch (Exception ex)
            {
                return new ReturnObject<PhatTu>
                {
                    Mes = ex.Message,
                    Error = true,
                    Data = null
                };
            }
        }
    }
}
