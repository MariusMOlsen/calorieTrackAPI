using CalorieTrack.Data;
using CalorieTrack.DTO;
using CalorieTrack.Model;
using CalorieTrack.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrack.Services
{
    public class MealService: IMealService
    {
        private readonly DataContext _context;

        public MealService(DataContext context) { _context = context; }

        public async Task<MealDTO> AddMeal(string name, Guid userGuid)
        {
            Meal meal = new Meal(name, userGuid);

            _context.meals.Add(meal);
            await _context.SaveChangesAsync();
            List<Meal> mealList = await _context.meals.ToListAsync();
            return MealDTO.convertFromEntityToDTO(meal);
        }

        public async Task<List<MealDTO>?> ChangeName(Guid guid, string name)
        {
            Meal meal = await _context.meals.FindAsync(guid);
            if (meal == null || name == "")
            {
                return null;
            }
            meal.Name = name;
            await _context.SaveChangesAsync();
            List<Meal> mealList = await _context.meals.ToListAsync();
            return MealDTO.convertFromEntityListToDTOList(mealList);

        }

        public async Task<List<MealDTO>?> DeleteMeal(Guid guid)
        {
            Meal meal = await _context.meals.FindAsync(guid);
            if (meal == null)
            {
                return null;
            }
            _context.meals.Remove(meal);
            await _context.SaveChangesAsync();
            List<Meal> mealList = await _context.meals.ToListAsync();
            return MealDTO.convertFromEntityListToDTOList(mealList);
        }

        public async Task<List<MealDTO>> GetAllMeals()
        {
            List<Meal> mealList = await _context.meals.ToListAsync();
            return MealDTO.convertFromEntityListToDTOList(mealList);
        }

        public async Task<MealDTO> GetSingleMeal(Guid guid)
        {
            Meal meal = await _context.meals.FindAsync(guid);
            if (meal == null)
            {
                return null;
            }
            return MealDTO.convertFromEntityToDTO(meal);
        }

        public async Task<List<MealDTO>> GetAllMealsByUser(Guid userGuid)
        {
            // User table is not created yet
            // List<Meal> mealList = await  _context.Users.Where(c => c.Guid == userGuid).ToList();
            List<Meal> mealList = await _context.meals.ToListAsync();
            return MealDTO.convertFromEntityListToDTOList(mealList);
        }
    }
}

