using QlyPhatTu.Dto;
using QlyPhatTu.Helper;
using QlyPhatTu.Models;

namespace QlyPhatTu.IServices
{
    public interface IPhatTuServices
    {
        ReturnObject<PhatTu> AddPhatTu(PhatTuDto dto);
        ReturnObject<PhatTu> UpdatePhatTu(PhatTuUpdateDto dto);
        ReturnObject<string> DeletePhatTu(int phatTuId);
    }
}
