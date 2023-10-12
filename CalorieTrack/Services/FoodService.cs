using CalorieTrack.Data;
using CalorieTrack.DTO;
using CalorieTrack.Model;
using CalorieTrack.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrack.Services
{
    public class FoodService: IFoodService
    {
        private readonly DataContext _context;

        public FoodService(DataContext context) { _context = context; }

        public async Task<List<FoodDTO>> AddFood(Food food)
        {

            Food newFood = new Food(food.Name, food.NutritionGuid, food.AmountOfUnit, food.Barcode);
            _context.Foods.Add(newFood);
            await _context.SaveChangesAsync();
            List<Food> foodList = await _context.Foods.ToListAsync();
            return FoodDTO.convertFromEntityListToDTOList(foodList);
        }

        public async Task<List<FoodDTO>?> EditFood(Food food)
        {
            Food foundFood = await _context.Foods.FindAsync(food.Guid);
            if (foundFood == null)
            {
                return null;
            }

            foundFood.Name = food.Name;
            foundFood.NutritionGuid = food.NutritionGuid;
            foundFood.AmountOfUnit = food.AmountOfUnit;
            foundFood.Barcode = food.Barcode;
            await _context.SaveChangesAsync();
            List<Food> foodList = await _context.Foods.ToListAsync();
            return FoodDTO.convertFromEntityListToDTOList(foodList);

        }

        public async Task<List<FoodDTO>?> DeleteFood(Guid guid)
        {
            Food foundFood = await _context.Foods.FindAsync(guid);
            if (foundFood == null)
            {
                return null;
            }
             _context.Foods.Remove(foundFood);
            await _context.SaveChangesAsync();
            List<Food> foodList = await _context.Foods.ToListAsync();
            return FoodDTO.convertFromEntityListToDTOList(foodList);
        }

        public async Task<List<FoodDTO>> GetAllFoods()
        {
            List<Food> foodList = await _context.Foods.ToListAsync();
            return FoodDTO.convertFromEntityListToDTOList(foodList);
        }

        public async Task<FoodDTO?> GetSingleFood(Guid guid)
        {
            Food foundFood = await _context.Foods.FindAsync(guid);
            if (foundFood == null) {
                return null;

            }
            return FoodDTO.convertFromEntityToDTO(foundFood);
        }
        
        public static List<Food> GetFoodListByGuidList(List<Guid> guidList, DataContext dataContext)
        {
            List<Food> foodList = dataContext.Foods.Where(food => guidList.Contains(food.Guid)).ToList();
            return foodList;
        }
    }
}

