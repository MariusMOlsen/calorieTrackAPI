using CalorieTrack.Data;
using CalorieTrack.DTO;
using CalorieTrack.Model;
using CalorieTrack.Services.interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using static CalorieTrack.Constants.Enums;

namespace CalorieTrack.Services
{
    public class MealItemService : IMealItemService
    {

        private readonly DataContext _context;
        public MealItemService(DataContext context) { _context = context; }

        public async Task<List<MealItemDTO>?> AddMealItem(Guid mealGuid, Guid itemGuid, InstanceDefinition instanceDefiniton)
        {
            if(mealGuid == Guid.Empty || itemGuid == Guid.Empty)
            {
                return null;
            }
            MealItem mealitem = new MealItem(mealGuid, itemGuid, instanceDefiniton);
            _context.mealsItem.Add(mealitem);
            await _context.SaveChangesAsync();
            List<MealItem> mealItemList = await _context.mealsItem.ToListAsync();
            return MealItemDTO.convertFromEntityListToDTOList(mealItemList);
        }

        public async Task<List<MealItemDTO>?> DeleteMealItem(Guid guid)
        {
            MealItem mealItem = await _context.mealsItem.FindAsync(guid);
            if(mealItem == null)
            {
                return null;
            }
            _context.mealsItem.Remove(mealItem);
            await _context.SaveChangesAsync();
            List<MealItem> mealItemList = await _context.mealsItem.ToListAsync();
            return MealItemDTO.convertFromEntityListToDTOList(mealItemList);
        }

        public async Task<List<MealItemDTO>> GetMealItemListByMealGuid(Guid mealGuid)
        {
            List<MealItem> mealItemList = await _context.mealsItem.Where(e => e.MealGuid == mealGuid).ToListAsync();
           return MealItemDTO.convertFromEntityListToDTOList(mealItemList);
        }

        public async Task<MealItemDTO> GetSingleMealItemByGuid(Guid guid)
        {
            MealItem mealItem = await _context.mealsItem.FindAsync(guid);
            return MealItemDTO.convertFromEntityToDTO(mealItem);
        }

 
    }

  
}
