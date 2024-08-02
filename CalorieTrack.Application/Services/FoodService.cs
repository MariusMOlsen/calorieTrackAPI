using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Application.DTO;
using CalorieTrack.DTO;
using CalorieTrack.Services.interfaces;
using CalorieTrack.Domain.Model;
using CalorieTrack.Domain.Model.Food;

namespace CalorieTrack.Application.Services
{
    public class UserFoodService : IUserFoodService
    {
        private readonly IUserFoodRepository _userFoodRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserFoodService(IUserFoodRepository context, IUnitOfWork unitOfWork)
        {
            _userFoodRepository = context;
            _unitOfWork = unitOfWork;
        }

        public async Task<List<UserFoodDto>> AddFood(Food food)
        {
            User dummyUser = new User();
            Guid testGuid = dummyUser.Guid;
            UserFood newFood = new UserFood(dummyUser, food.Name, food.NutritionGuid, food.AmountOfUnit, food.Barcode);
            _userFoodRepository.Add(newFood);
            await _unitOfWork.CommitChangesAsync();
            IEnumerable<UserFood> foodList = await _userFoodRepository.GetAll();
            return UserFoodDto.convertFromEntityListToDTOList(foodList);
        }

        public async Task<List<UserFoodDto>?> EditFood(Food food)
        {
            Food foundFood = await _userFoodRepository.Find(food.Guid);
            if (foundFood == null)
            {
                return null;
            }

            foundFood.Name = food.Name;
           
            foundFood.AmountOfUnit = food.AmountOfUnit;
            foundFood.Barcode = food.Barcode;
            await _unitOfWork.CommitChangesAsync();
            IEnumerable<UserFood> foodList = await _userFoodRepository.GetAll();
            return UserFoodDto.convertFromEntityListToDTOList(foodList);

        }

        public async Task<List<UserFoodDto>?> DeleteFood(Guid guid)
        {
            UserFood foundFood = await _userFoodRepository.Find(guid);
            if (foundFood == null)
            {
                return null;
            }
            _userFoodRepository.Delete(foundFood);
            await _unitOfWork.CommitChangesAsync();
            IEnumerable<UserFood> foodList = await _userFoodRepository.GetAll();
            return UserFoodDto.convertFromEntityListToDTOList(foodList);
        }

        public async Task<List<UserFoodDto>> GetAllFoods()
        {
            IEnumerable<UserFood> foodList = await _userFoodRepository.GetAll();
            return UserFoodDto.convertFromEntityListToDTOList(foodList);
        }

        public async Task<UserFoodDto?> GetSingleFood(Guid guid)
        {
            UserFood foundFood = await _userFoodRepository.Find(guid);
            if (foundFood == null)
            {
                return null;

            }
            return UserFoodDto.convertFromEntityToDTO(foundFood);
        }

        public static async Task<IEnumerable<Food>> GetFoodListByGuidList(List<Guid> guidList, IUserFoodRepository dataContext)
        {
           IEnumerable<Food>? foodList = await dataContext.GetFoodListByGuidList(guidList);  
            
            if(foodList == null)
            {
                foodList = new List<Food>();
            }
            return foodList;
        }
    }
}

