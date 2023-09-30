using CalorieTrack.DTO;
using CalorieTrack.Model;

namespace CalorieTrack.Services.interfaces
{
    public interface IFoodService
    {
        Task<List<FoodDTO>> AddFood(Food food);
        Task<List<FoodDTO>?> EditFood(Food food);
        Task<List<FoodDTO>?> DeleteFood(Guid guid);
        Task<List<FoodDTO>> GetAllFoods();
        Task<FoodDTO?> GetSingleFood(Guid guid);
    }
}
