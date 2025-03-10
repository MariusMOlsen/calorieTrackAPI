﻿using CalorieTrack.Domain.Model;
using CalorieTrack.Model;

namespace CalorieTrack.Services.interfaces
{
    public interface INutritionService
    {
        Task<NutritionDTO>? GetSingleNutrition(Guid guid);


        Task<List<NutritionDTO>?> EditNutrition(Nutrition nutritionRequest);

        Task<List<NutritionDTO>?> DeleteNutrition(Guid guid);


        Task<List<NutritionDTO>> AddNutrition(double protein, double carbohydrates, double fat, double calories, Guid unitDefinitonGuid);


        Task<List<NutritionDTO>> GetAllNutrition();

        Task<List<NutritionDTO>> GetNutritionDTOListByGuidList(List<Guid> guidList);

    }
}
