using CalorieTrack.Application.DTO;
using CalorieTrack.Domain.Model;
using CalorieTrack.DTO;
using CalorieTrack.Model;

namespace CalorieTrack.Services.interfaces
{
    public interface IFoodService
    {
        Task<List<FoodDto>> AddFood(Food food);
        Task<List<FoodDto>?> EditFood(Food food);
        Task<List<FoodDto>?> DeleteFood(Guid guid);
        Task<List<FoodDto>> GetAllFoods();
        Task<FoodDto?> GetSingleFood(Guid guid);
    }
}
