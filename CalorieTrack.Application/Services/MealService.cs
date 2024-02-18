using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Domain.Model;
using CalorieTrack.DTO;
using CalorieTrack.Services.interfaces;


namespace CalorieTrack.Services
{
    public class MealService: IMealService
    {
        private readonly IMealRepository _mealRepository;
        private readonly IUnitOfWork _unitOfWork;

        public MealService(IMealRepository context, IUnitOfWork unitOfWork) { _mealRepository = context; _unitOfWork = unitOfWork; }

        public async Task<MealDTO> AddMeal(string name, Guid userGuid)
        {
            Meal meal = new Meal(name, userGuid);

            _mealRepository.Add(meal);
            await _unitOfWork.CommitChangesAsync();
            return MealDTO.convertFromEntityToDTO(meal);
        }

        public async Task<List<MealDTO>?> ChangeName(Guid guid, string name)
        {
            Meal? meal = await _mealRepository.Find(guid);
            if (meal == null || name == "")
            {
                return null;
            }
            meal.Name = name;
            await _unitOfWork.CommitChangesAsync();
            List<Meal> mealList = await _mealRepository.GetAll();
            // Could consider to just return entity instead of list here.
            return MealDTO.convertFromEntityListToDTOList(mealList);

        }

        public async Task<List<MealDTO>?> DeleteMeal(Guid guid)
        {
            Meal? meal = await _mealRepository.Find(guid);
            if (meal == null)
            {
                return null;
            }
            _mealRepository.Delete(meal);
            await _unitOfWork.CommitChangesAsync();
            List<Meal> mealList = await _mealRepository.GetAll();
            return MealDTO.convertFromEntityListToDTOList(mealList);
        }

        public async Task<List<MealDTO>> GetAllMeals()
        {
            List<Meal> mealList = await _mealRepository.GetAll();
            return MealDTO.convertFromEntityListToDTOList(mealList);
        }

        public async Task<MealDTO?> GetSingleMeal(Guid guid)
        {
            Meal? meal = await _mealRepository.Find(guid);
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
            List<Meal> mealList = await _mealRepository.GetAll();
            return MealDTO.convertFromEntityListToDTOList(mealList);
        }
    }
}

