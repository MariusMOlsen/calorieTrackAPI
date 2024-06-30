using CalorieTrack.Application.DTO;
using CalorieTrack.Domain.Model;
using CalorieTrack.Domain.Model.Food;
using CalorieTrack.DTO;
using CalorieTrack.Model;

namespace CalorieTrack.Services.interfaces
{
    public interface IUserFoodService
    {
        Task<List<UserFoodDto>> AddFood(Food food);
        Task<List<UserFoodDto>?> EditFood(Food food);
        Task<List<UserFoodDto>?> DeleteFood(Guid guid);
        Task<List<UserFoodDto>> GetAllFoods();
        Task<UserFoodDto?> GetSingleFood(Guid guid);
    }
}
