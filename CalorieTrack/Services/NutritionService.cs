using CalorieTrack.Data;
using CalorieTrack.Interfaces.Services;
using CalorieTrack.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace CalorieTrack.Services
{
    public class NutritionService: INutritionService
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

        public async Task<List<NutritionDTO>> AddNutrition(Nutrition nutrition)
        {
             _context.Nutritions.Add(nutrition);
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

        public async Task<List<NutritionDTO>?> EditNutrition( Nutrition nutritionRequest)
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

        public async Task<List<NutritionDTO>> GetNutritionListByGuidList(List<Guid> guidList)
        {
            List<Nutrition> nutritionList = await _context.Nutritions.Where(n => guidList.Contains(n.Guid)).ToListAsync();
            return NutritionDTO.convertFromEntityListToDTOList(nutritionList);
        }
    }
}

