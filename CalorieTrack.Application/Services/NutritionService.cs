using CalorieTrack.Data;
using CalorieTrack.Model;
using CalorieTrack.Services.interfaces;
using Microsoft.EntityFrameworkCore;
using System;

namespace CalorieTrack.Services
{
    public class NutritionService : INutritionService
    {
        private readonly DataContext _context;

        public NutritionService(DataContext context)
        {
            _context = context;
        }


        public async Task<List<NutritionDTO>> GetAllNutrition()
        {
            List<Nutrition> nutritonList = await _context.Nutritions.ToListAsync();
            return NutritionDTO.convertFromEntityListToDTOList(nutritonList);
        }

        public async Task<List<NutritionDTO>> AddNutrition(int protein, int carbohydrates, int fat, int calories, Guid unitDefinitonGuid)
        {
            Nutrition newNutrition = new Nutrition(protein, carbohydrates, fat, calories, unitDefinitonGuid);
            _context.Nutritions.Add(newNutrition);
            await _context.SaveChangesAsync();
            List<Nutrition> nutritonList = await _context.Nutritions.ToListAsync();
            return NutritionDTO.convertFromEntityListToDTOList(nutritonList);

        }

        public async Task<List<NutritionDTO>?> DeleteNutrition(Guid guid)
        {
            var nutrition = await _context.Nutritions.FindAsync(guid);
            if (nutrition == null)
            {
                return null;
            }
            _context.Nutritions.Remove(nutrition);
            await _context.SaveChangesAsync();
            List<Nutrition> nutritonList = await _context.Nutritions.ToListAsync();
            return NutritionDTO.convertFromEntityListToDTOList(nutritonList);
        }

        public async Task<List<NutritionDTO>?> EditNutrition(Nutrition nutritionRequest)
        {
            Nutrition nutritionObject = await _context.Nutritions.FindAsync(nutritionRequest.Guid);
            if (nutritionObject == null)
            {
                return null;
            }
            nutritionObject.UnitDefinitionGuid = nutritionRequest.UnitDefinitionGuid;
            nutritionObject.Carbohydrates = nutritionRequest.Carbohydrates;
            nutritionObject.Fat = nutritionRequest.Fat;
            nutritionObject.Calories = nutritionRequest.Calories;
            nutritionObject.Protein = nutritionRequest.Protein;
            await _context.SaveChangesAsync();
            List<Nutrition> nutritonList = await _context.Nutritions.ToListAsync();
            return NutritionDTO.convertFromEntityListToDTOList(nutritonList);
        }

        public async Task<NutritionDTO?> GetSingleNutrition(Guid guid)
        {
            Nutrition nutrition = await _context.Nutritions.FindAsync(guid);
            if (nutrition == null)
            {
                return null;
            }
            return NutritionDTO.convertFromEntityToDTO(nutrition);

        }

        public async Task<List<NutritionDTO>> GetNutritionDTOListByGuidList(List<Guid> guidList)
        {
            List<Nutrition> nutritionList = await _context.Nutritions.Where(n => guidList.Contains(n.Guid)).ToListAsync();
            return NutritionDTO.convertFromEntityListToDTOList(nutritionList);
        }

        public static List<Nutrition> GetNutritionListByGuidList(List<Guid> guidList, DataContext dataContext)
        {
            List<Nutrition> nutritionList = dataContext.Nutritions.Where(n => guidList.Contains(n.Guid)).ToList();
            return nutritionList;
        }

        public static Nutrition convertNutritionListToSingleObject(List<Nutrition> nutritionList, DataContext dataContext)
        {
            int protein = 0;
            int carbohydrates = 0;
            int fat = 0;
            int calories = 0;
            foreach (Nutrition nutrition in nutritionList)
            {
                protein = +nutrition.Protein;
                carbohydrates = +nutrition.Carbohydrates;
                fat = +nutrition.Fat;
                calories = +nutrition.Calories;
            }
            Nutrition nutritionObject = new Nutrition(protein, carbohydrates, fat, calories);
            dataContext.Nutritions.Add(nutritionObject);
            dataContext.SaveChanges();
            return nutritionObject;
        }

    }
}

