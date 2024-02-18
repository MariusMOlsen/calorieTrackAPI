
using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Domain.Model;
using CalorieTrack.DTO;
using CalorieTrack.Services.interfaces;

using static CalorieTrack.Constants.Enums;

namespace CalorieTrack.Services
{
    public class MealItemService : IMealItemService
    {

        private readonly IMealItemRepository _mealItemRepository;
        private readonly IUnitOfWork _unitOfWork;
        public MealItemService(IMealItemRepository context,  IUnitOfWork unitOfWork) { _mealItemRepository = context; _unitOfWork = unitOfWork; }

        public async Task<List<MealItemDTO>?> AddMealItem(Guid mealGuid, Guid itemGuid, int amount, InstanceDefinition instanceDefiniton)
        {
            if (mealGuid == Guid.Empty || itemGuid == Guid.Empty)
            {
                return null;
            }
            MealItem mealitem = new MealItem(mealGuid, itemGuid, amount, instanceDefiniton);
            _mealItemRepository.Add(mealitem);
            await _unitOfWork.CommitChangesAsync();
            List<MealItem> mealItemList = await _mealItemRepository.GetAll();
            return MealItemDTO.convertFromEntityListToDTOList(mealItemList);
        }

        public async Task<List<MealItemDTO>?> DeleteMealItem(Guid guid)
        {
            MealItem? mealItem = await _mealItemRepository.Find(guid);
            if (mealItem == null)
            {
                return null;
            }
            _mealItemRepository.Delete(mealItem);
            await _unitOfWork.CommitChangesAsync();
            List<MealItem> mealItemList = await _mealItemRepository.GetAll();
            return MealItemDTO.convertFromEntityListToDTOList(mealItemList);
        }

        public async Task<List<MealItemDTO>> GetMealItemListByMealGuid(Guid mealGuid)
        {
            List<MealItem> mealItemList = await _mealItemRepository.GetMealItemListByMealGuid(mealGuid);
            return MealItemDTO.convertFromEntityListToDTOList(mealItemList);
        }

        public async Task<MealItemDTO?> GetSingleMealItemByGuid(Guid guid)
        {
            MealItem? mealItem = await _mealItemRepository.GetSingleMealItemByGuid(guid);
            return mealItem != null ? MealItemDTO.convertFromEntityToDTO(mealItem) : null ;
        }


    }


}
