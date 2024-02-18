
using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Domain.Model;
using CalorieTrack.Model;
using CalorieTrack.Services.interfaces;

namespace CalorieTrack.Services
{
    public class NutritionService : INutritionService
    {
        private readonly INutritionRepository _nutritionRepository;
        private readonly IUnitOfWork _unitOfWork;

        public NutritionService(INutritionRepository nutritionRepository, IUnitOfWork unitOfWork)
        {
            _nutritionRepository = nutritionRepository;
            _unitOfWork = unitOfWork;
        }


        public async Task<List<NutritionDTO>> GetAllNutrition()
        {
            List<Nutrition> nutritonList = await _nutritionRepository.GetAll();
            return NutritionDTO.convertFromEntityListToDTOList(nutritonList);
        }

        public async Task<List<NutritionDTO>> AddNutrition(int protein, int carbohydrates, int fat, int calories, Guid unitDefinitonGuid)
        {
            Nutrition newNutrition = new Nutrition(protein, carbohydrates, fat, calories, unitDefinitonGuid);
            _nutritionRepository.Add(newNutrition);
            await _unitOfWork.CommitChangesAsync();
            List<Nutrition> nutritonList = await _nutritionRepository.GetAll();
            return NutritionDTO.convertFromEntityListToDTOList(nutritonList);

        }

        public async Task<List<NutritionDTO>?> DeleteNutrition(Guid guid)
        {
            var nutrition = await _nutritionRepository.Find(guid);
            if (nutrition == null)
            {
                return null;
            }
            _nutritionRepository.Delete(nutrition);
            await _unitOfWork.CommitChangesAsync();
            List<Nutrition> nutritonList = await _nutritionRepository.GetAll();
            return NutritionDTO.convertFromEntityListToDTOList(nutritonList);
        }

        public async Task<List<NutritionDTO>?> EditNutrition(Nutrition nutritionRequest)
        {
            Nutrition? nutritionObject = await _nutritionRepository.Find(nutritionRequest.Guid);
            if (nutritionObject == null)
            {
                return null;
            }
            nutritionObject.UnitDefinitionGuid = nutritionRequest.UnitDefinitionGuid;
            nutritionObject.Carbohydrates = nutritionRequest.Carbohydrates;
            nutritionObject.Fat = nutritionRequest.Fat;
            nutritionObject.Calories = nutritionRequest.Calories;
            nutritionObject.Protein = nutritionRequest.Protein;
            await _unitOfWork.CommitChangesAsync();
            List<Nutrition> nutritonList = await _nutritionRepository.GetAll();
            return NutritionDTO.convertFromEntityListToDTOList(nutritonList);
        }

        public async Task<NutritionDTO?> GetSingleNutrition(Guid guid)
        {
            Nutrition? nutrition = await _nutritionRepository.Find(guid);
            if (nutrition == null)
            {
                return null;
            }
            return NutritionDTO.convertFromEntityToDTO(nutrition);

        }

        public async Task<List<NutritionDTO>> GetNutritionDTOListByGuidList(List<Guid> guidList)
        {
            List<Nutrition> nutritionList = await _nutritionRepository.GetNutritionListByGuidList(guidList);
            return NutritionDTO.convertFromEntityListToDTOList(nutritionList);
        }

        public async static Task<List<Nutrition>> GetNutritionListByGuidList(List<Guid> guidList, INutritionRepository nutritionRepository)
        {
            List<Nutrition> nutritionList = await nutritionRepository.GetNutritionListByGuidList(guidList);
            return nutritionList;
        }

        public  static async Task<Nutrition> convertNutritionListToSingleObject(List<Nutrition> nutritionList, INutritionRepository nutritionRepository, IUnitOfWork unitOfWork)
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
            nutritionRepository.Add(nutritionObject);
           await  unitOfWork.CommitChangesAsync();
            return nutritionObject;
        }

    }
}

