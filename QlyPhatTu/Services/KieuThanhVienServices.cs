using QlyPhatTu.Dto;
using QlyPhatTu.Helper;
using QlyPhatTu.IServices;
using QlyPhatTu.Models;

namespace QlyPhatTu.Services
{
    public class KieuThanhVienServices : IKieuThanhVienServices
    {
        private readonly AppDbContext appDbContext;

        public KieuThanhVienServices()
        {
            appDbContext = new AppDbContext();
        }

        public ReturnObject<KieuThanhVien> AddKieuThanhVien(KieuThanhVienDto dto)
        {
            try
            {
                var addKTV = new KieuThanhVien
                {
                    Code = dto.Code,
                    TenKieu = dto.TenKieu
                };
                appDbContext.Add(addKTV);
                appDbContext.SaveChanges();
                return new ReturnObject<KieuThanhVien>
                {
                    Mes = "Success",
                    Data = addKTV
                };
            }
            catch (Exception ex)
            {
                return new ReturnObject<KieuThanhVien>
                {
                    Mes = ex.Message,
                    Error = true,
                    Data = null
                };
            }
        }

        public ReturnObject<string> DeleteKieuThanhVien(int id)
        {
            try
            {
                var deleteKTV = appDbContext.KieuThanhVien.SingleOrDefault(x => x.KieuThanhVienId == id);
                if(deleteKTV == null)
                {
                    throw new Exception("Not exist");
                }
                appDbContext.Remove(deleteKTV);
                appDbContext.SaveChanges();
                return new ReturnObject<string>
                {
                    Mes = "Success",
                    Data = null
                };
            }
            catch (Exception ex)
            {
                return new ReturnObject<string>
                {
                    Mes = ex.Message,
                    Error = true,
                    Data = null
                };
            }
        }

        public ReturnObject<KieuThanhVien> UpdateKieuThanhVien(KieuThanhVienDto dto)
        {
            try
            {
                var updateKTV = appDbContext.KieuThanhVien.SingleOrDefault(x => x.KieuThanhVienId == dto.KieuThanhVienId);
                if(updateKTV == null)
                {
                    throw new Exception("Not exist");
                }
                updateKTV.TenKieu = dto.TenKieu;
                updateKTV.Code = dto.Code;
                appDbContext.Update(updateKTV);
                appDbContext.SaveChanges();
                return new ReturnObject<KieuThanhVien>
                {
                    Mes = "Success",
                    Data = updateKTV
                };
            }
            catch (Exception ex)
            {
                return new ReturnObject<KieuThanhVien>
                {
                    Mes = ex.Message,
                    Data = null,
                    Error = true
                };
            }
        }
    }
}
