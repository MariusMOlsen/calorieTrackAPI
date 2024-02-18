using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Data;
using CalorieTrack.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrack.Infrastructure
{
    public class MealItemRepository : IMealItemRepository
    {

        private readonly DataContext _context;

        public MealItemRepository(DataContext context)
        {
            _context = context;
        }
        public void Add(MealItem mealItem)
        {
            _context.Add(mealItem);
        }

        public void Delete(MealItem mealItem)
        {
            _context.Remove(mealItem);
        }

        public async Task<MealItem?> Find(Guid id)
        {
            MealItem? mealItem = await _context.MealsItem.FindAsync(id);
            return mealItem;
        }

        public async Task<List<MealItem>> GetAll()
        {
            return await _context.MealsItem.ToListAsync();
        }

        public async Task<List<MealItem>> GetMealItemListByMealGuid(Guid mealGuid)
        {
            List<MealItem> mealItemList = await _context.MealsItem.Where(e => e.MealGuid == mealGuid).ToListAsync();
            return mealItemList;
        }

        public async Task<MealItem?> GetSingleMealItemByGuid(Guid guid)
        {
            MealItem? mealItem = await _context.MealsItem.FindAsync(guid);
            return mealItem;
        }
    }
}
