using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Application.Services;
using CalorieTrack.Domain.Model;
using CalorieTrack.Domain.Model.Food;
using CalorieTrack.DTO;
using CalorieTrack.Services.interfaces;


namespace CalorieTrack.Services
{
    public class RecepieService : IRecepieService
    {
        private readonly IRecepieRepository _recepieRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserFoodRepository _userFoodRepository;
        private readonly ICommonFoodRepository _commonFoodRepository;
        private readonly IRecepieItemRepository _recepieItemRepository;
        private readonly INutritionRepository _nutritionRepository;

        public RecepieService(IRecepieRepository recepieRepository,IUnitOfWork unitOfWork, IUserFoodRepository userFoodRepository, ICommonFoodRepository commonFoodRepository, IRecepieItemRepository recepieItemRepository,
            INutritionRepository nutritionRepository) { 
            _recepieRepository = recepieRepository; 
            _unitOfWork = unitOfWork; 
            _userFoodRepository = userFoodRepository;
            _commonFoodRepository = commonFoodRepository;
            _recepieItemRepository = recepieItemRepository;
            _nutritionRepository = nutritionRepository;
        }



        public async Task<RecepieDTO> AddRecepie(string name, Guid userGuid)
        {
            Recepie recepie = new Recepie(name, userGuid);
            _recepieRepository.Add(recepie);
            await _unitOfWork.CommitChangesAsync();

            return RecepieDTO.convertFromEntityToDTO(recepie);
        }

        public async Task<RecepieDTO?> UpdateRecepieNutrition(Guid guid)
        {
            Recepie? recepie = await _recepieRepository.Find(guid);
            if (recepie == null)
            {
                return null;
            }

            recepie.NutritionGuid = guid;
            List<Guid> RecepieItemFoodGuids = await RecepieItemService.GetFoodGuidsByRecepieGuid(guid, _recepieItemRepository);
            IEnumerable<Food> foodList = await UserFoodService.GetFoodListByGuidList(RecepieItemFoodGuids, _userFoodRepository);
         
            List<Guid> nutritionGuidList = new List<Guid>();

            foreach (Food food in foodList)
            {
                nutritionGuidList.Add(food.NutritionGuid);
            }

            List<Nutrition> nutritionList = await NutritionService.GetNutritionListByGuidList(nutritionGuidList, _nutritionRepository);
            Nutrition nutritionObject = await NutritionService.convertNutritionListToSingleObject(nutritionList, _nutritionRepository, _unitOfWork);


            recepie.NutritionGuid = nutritionObject.Guid;
            await _unitOfWork.CommitChangesAsync();
            return RecepieDTO.convertFromEntityToDTO(recepie);


        }

        public async Task<List<RecepieDTO>?> DeleteRecepie(Guid guid)
        {
           Recepie? recepie = await _recepieRepository.Find(guid);
            if(recepie == null)
            {
                return null;
            }
            _recepieRepository.Delete(recepie);
            await _unitOfWork.CommitChangesAsync();

            return  new List<RecepieDTO>();

        }

        public async Task<List<RecepieDTO>> GetRecepieListByUserGuid(Guid userGuid)
        {
            List<Recepie> recepieList = await _recepieRepository.GetListByUserId(userGuid);
             return RecepieDTO.convertFromEntityListToDTOList(recepieList);

        }
    }
}

