using CalorieTrack.DTO;
using static CalorieTrack.Constants.Enums;

namespace CalorieTrack.Services.interfaces
{
    public interface IMealItemService
    {
        Task<List<MealItemDTO>?> AddMealItem(Guid mealGuid, Guid itemGuid,int amount, InstanceDefinition instanceDefiniton);
        Task<List<MealItemDTO>?> DeleteMealItem(Guid guid);
        Task<List<MealItemDTO>> GetMealItemListByMealGuid(Guid mealGuid);
        Task<MealItemDTO> GetSingleMealItemByGuid(Guid guid);
    }
}
