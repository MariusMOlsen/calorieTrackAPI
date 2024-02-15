using CalorieTrack.DTO;

namespace CalorieTrack.Services.interfaces
{
    public interface IRecepieService
    {
        Task<RecepieDTO> AddRecepie(string name, Guid userGuid);
        Task<RecepieDTO?> UpdateRecepieNutrition(Guid guid);
        Task<List<RecepieDTO>?> DeleteRecepie(Guid guid);
        Task<List<RecepieDTO>> GetRecepieListByUserGuid(Guid userGuid);

    }
}
