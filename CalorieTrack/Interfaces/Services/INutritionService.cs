using CalorieTrack.Model;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTrack.Interfaces.Services
{
    public interface INutritionService
    {
        Task<NutritionDTO> GetSingleNutrition(Guid guid);


        Task<List<NutritionDTO>?> EditNutrition( Nutrition nutritionRequest);

        Task<List<NutritionDTO>> DeleteNutrition(Guid guid);


        Task<List<NutritionDTO>> AddNutrition(Nutrition nutrition);


        Task<List<NutritionDTO>> GetAllNutrition();

        Task<List<NutritionDTO>> GetNutritionListByGuidList(List<Guid > guidList);
  
    }
}
