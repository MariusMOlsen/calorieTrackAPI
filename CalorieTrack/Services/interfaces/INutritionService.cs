using CalorieTrack.Model;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTrack.Services.interfaces
{
    public interface INutritionService
    {
        Task<NutritionDTO> GetSingleNutrition(Guid guid);


        Task<List<NutritionDTO>?> EditNutrition(Nutrition nutritionRequest);

        Task<List<NutritionDTO>> DeleteNutrition(Guid guid);


        Task<List<NutritionDTO>> AddNutrition(int protein, int carbohydrates, int fat, int calories, Guid unitDefinitonGuid);


        Task<List<NutritionDTO>> GetAllNutrition();

        Task<List<NutritionDTO>> GetNutritionListByGuidList(List<Guid> guidList);

    }
}
