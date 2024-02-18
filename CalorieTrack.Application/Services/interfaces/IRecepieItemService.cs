using CalorieTrack.Domain.Model;
using CalorieTrack.DTO;
using CalorieTrack.Model;

namespace CalorieTrack.Services.interfaces
{
    public interface IRecepieItemService
    {

        Task<List<RecepieItemDTO>> AddRecepieItem(RecepieItem recepieItem);
        Task<RecepieItemDTO?> DeleteRecepieItem(Guid guid);
        Task<RecepieItemDTO?> EditRecepieItem(RecepieItem recepieItem);
        Task<List<RecepieItemDTO>?> GetAllRecepieItemsByRecepieGuid(Guid guid);

    }
}
