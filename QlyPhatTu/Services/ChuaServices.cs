using QlyPhatTu.Dto;
using QlyPhatTu.Helper;
using QlyPhatTu.IServices;
using QlyPhatTu.Models;
using System.Linq.Expressions;

namespace QlyPhatTu.Services
{
    public class ChuaServices: IChuaServices
    {
        private readonly AppDbContext appDbContext;

        public ChuaServices()
        {
            appDbContext = new AppDbContext();
        }

        public ReturnObject<Chua> AddChua(ChuaDto chua)
        {
            try
            {
                var addChua = new Chua
                {
                    CapNhap = DateTime.UtcNow,
                    DiaChi = chua.DiaChi,
                    NgayThanhLap = chua.NgayThanhLap,
                    TenChua = chua.TenChua,
                    TruTri = chua.TruTri,

                };
                appDbContext.Add(addChua);
                appDbContext.SaveChanges();
                return new ReturnObject<Chua>
                {
                    Mes = "Success",
                    Data = addChua
                };
            }
            catch
            {
                return new ReturnObject<Chua>
                {
                    Mes = "Failed",
                    Data = null,
                    Error = true
                };
            }
        }

        public ReturnObject<string> DeleteChua(int chuaId)
        {
            try
            {
                var deleteChua = appDbContext.Chua.SingleOrDefault(x => x.ChuaId == chuaId);
                if(deleteChua == null)
                {
                    throw new Exception("Not exist");
                }
                appDbContext.Remove(deleteChua);
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
                    Data = null,
                    Error = true
                };
            }
        }

        public IQueryable<Chua> GetChua(string? tenChua)
        {
            var query = appDbContext.Chua.AsQueryable();
            if (!string.IsNullOrEmpty(tenChua))
            {
                query = query.Where(x => x.TenChua.ToLower().Contains(tenChua.ToLower()));
            }
            return query;
        }

        public ReturnObject<Chua> UpdateChua(ChuaDto chua)
        {
            try
            {
                var updateChua = appDbContext.Chua.SingleOrDefault(x => x.ChuaId == chua.ChuaId);
                if(updateChua == null)
                {
                    throw new Exception("Not exist");
                }
                updateChua.DiaChi = chua.DiaChi;
                updateChua.NgayThanhLap = chua.NgayThanhLap;
                updateChua.TenChua = chua.TenChua;
                updateChua.TruTri = chua.TruTri;
                updateChua.CapNhap = DateTime.UtcNow;
                appDbContext.Update(updateChua);
                appDbContext.SaveChanges();
                return new ReturnObject<Chua>
                {
                    Mes = "Success",
                    Data = updateChua
                };
            }
            catch (Exception ex)
            {
                return new ReturnObject<Chua>
                {
                    Mes = ex.Message,
                    Data = null,
                    Error = true
                };
            }
        }
    }
}
