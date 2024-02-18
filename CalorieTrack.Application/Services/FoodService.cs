using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Domain.Model;
using CalorieTrack.DTO;
using CalorieTrack.Model;
using CalorieTrack.Services.interfaces;

namespace CalorieTrack.Services
{
    public class FoodService : IFoodService
    {
        private readonly IFoodRepository _foodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public FoodService(IFoodRepository context, IUnitOfWork unitOfWork)
        {
            _foodRepository = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<FoodDTO>> AddFood(Food food)
        {

            Food newFood = new Food(food.Name, food.NutritionGuid, food.AmountOfUnit, food.Barcode);
            _foodRepository.Add(newFood);
            await _unitOfWork.CommitChangesAsync();
            List<Food> foodList = await _foodRepository.GetAll();
            return FoodDTO.convertFromEntityListToDTOList(foodList);
        }

        public async Task<List<FoodDTO>?> EditFood(Food food)
        {
            Food foundFood = await _foodRepository.Find(food.Guid);
            if (foundFood == null)
            {
                return null;
            }

            foundFood.Name = food.Name;
            foundFood.NutritionGuid = food.NutritionGuid;
            foundFood.AmountOfUnit = food.AmountOfUnit;
            foundFood.Barcode = food.Barcode;
            await _unitOfWork.CommitChangesAsync();
            List<Food> foodList = await _foodRepository.GetAll();
            return FoodDTO.convertFromEntityListToDTOList(foodList);

        }

        public async Task<List<FoodDTO>?> DeleteFood(Guid guid)
        {
            Food foundFood = await _foodRepository.Find(guid);
            if (foundFood == null)
            {
                return null;
            }
            _foodRepository.Delete(foundFood);
            await _unitOfWork.CommitChangesAsync();
            List<Food> foodList = await _foodRepository.GetAll();
            return FoodDTO.convertFromEntityListToDTOList(foodList);
        }

        public async Task<List<FoodDTO>> GetAllFoods()
        {
            List<Food> foodList = await _foodRepository.GetAll();
            return FoodDTO.convertFromEntityListToDTOList(foodList);
        }

        public async Task<FoodDTO?> GetSingleFood(Guid guid)
        {
            Food foundFood = await _foodRepository.Find(guid);
            if (foundFood == null)
            {
                return null;

            }
            return FoodDTO.convertFromEntityToDTO(foundFood);
        }

        public static async Task<List<Food>> GetFoodListByGuidList(List<Guid> guidList, IFoodRepository dataContext)
        {
            List<Food>? foodList = await dataContext.GetFoodListByGuidList(guidList);  
            if(foodList == null)
            {
                foodList = new List<Food>();
            }
            return foodList;
        }
    }
}

