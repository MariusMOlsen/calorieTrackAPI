using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Application.DTO;
using CalorieTrack.DTO;
using CalorieTrack.Services.interfaces;
using CalorieTrack.Domain.Model;

namespace CalorieTrack.Application.Services
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

        public async Task<List<FoodDto>> AddFood(Domain.Model.Food food)
        {

            Food newFood = new Food(food.Name, food.NutritionGuid, food.AmountOfUnit, food.Barcode);
            _foodRepository.Add(newFood);
            await _unitOfWork.CommitChangesAsync();
            List<Domain.Model.Food> foodList = await _foodRepository.GetAll();
            return FoodDto.convertFromEntityListToDTOList(foodList);
        }

        public async Task<List<FoodDto>?> EditFood(Domain.Model.Food food)
        {
            Domain.Model.Food foundFood = await _foodRepository.Find(food.Guid);
            if (foundFood == null)
            {
                return null;
            }

            foundFood.Name = food.Name;
            foundFood.NutritionGuid = food.NutritionGuid;
            foundFood.AmountOfUnit = food.AmountOfUnit;
            foundFood.Barcode = food.Barcode;
            await _unitOfWork.CommitChangesAsync();
            List<Domain.Model.Food> foodList = await _foodRepository.GetAll();
            return FoodDto.convertFromEntityListToDTOList(foodList);

        }

        public async Task<List<FoodDto>?> DeleteFood(Guid guid)
        {
            Domain.Model.Food foundFood = await _foodRepository.Find(guid);
            if (foundFood == null)
            {
                return null;
            }
            _foodRepository.Delete(foundFood);
            await _unitOfWork.CommitChangesAsync();
            List<Domain.Model.Food> foodList = await _foodRepository.GetAll();
            return FoodDto.convertFromEntityListToDTOList(foodList);
        }

        public async Task<List<FoodDto>> GetAllFoods()
        {
            List<Domain.Model.Food> foodList = await _foodRepository.GetAll();
            return FoodDto.convertFromEntityListToDTOList(foodList);
        }

        public async Task<FoodDto?> GetSingleFood(Guid guid)
        {
            Domain.Model.Food foundFood = await _foodRepository.Find(guid);
            if (foundFood == null)
            {
                return null;

            }
            return FoodDto.convertFromEntityToDTO(foundFood);
        }

        public static async Task<List<Domain.Model.Food>> GetFoodListByGuidList(List<Guid> guidList, IFoodRepository dataContext)
        {
            List<Domain.Model.Food>? foodList = await dataContext.GetFoodListByGuidList(guidList);  
            if(foodList == null)
            {
                foodList = new List<Domain.Model.Food>();
            }
            return foodList;
        }
    }
}

