using CalorieTrack.Domain.Model;
using System.Xml.Serialization;

namespace CalorieTrack.Application.Common.Interfaces
{
    public interface IMealItemRepository
    {
        void Add(MealItem mealItem);
        Task<List<MealItem>> GetAll();

        Task<MealItem?> Find(Guid id);

        void Delete(MealItem id);

        Task<List<MealItem>> GetMealItemListByMealGuid(Guid mealGuid);

        Task<MealItem?> GetSingleMealItemByGuid(Guid guid);
    }
}
