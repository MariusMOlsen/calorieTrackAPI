using CalorieTrack.DTO;

namespace CalorieTrack.Services.interfaces
{
    public interface IMealService
    {
        Task<MealDTO> AddMeal(string name, Guid userGuid);

        Task<List<MealDTO>?> ChangeName(Guid guid, string name);

        Task<List<MealDTO>?> DeleteMeal(Guid guid);
        Task<List<MealDTO>> GetAllMeals();

        Task<MealDTO> GetSingleMeal(Guid guid);

        Task<List<MealDTO>> GetAllMealsByUser(Guid userGuid);



    }
}
