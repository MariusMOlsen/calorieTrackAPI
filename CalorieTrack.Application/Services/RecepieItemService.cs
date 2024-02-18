using CalorieTrack.Application.Common.Interfaces;

using CalorieTrack.Domain.Model;
using CalorieTrack.DTO;
using CalorieTrack.Services.interfaces;


namespace CalorieTrack.Services
{
    public class RecepieItemService : IRecepieItemService

    {
        private readonly IRecepieItemRepository _recepieItemRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RecepieItemService(IRecepieItemRepository recepieItemRepository, IUnitOfWork unitOfWork)
        {
            _recepieItemRepository = recepieItemRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<List<RecepieItemDTO>> AddRecepieItem(RecepieItem recepieItem)
        {
            RecepieItem newRecepieItem = new RecepieItem(recepieItem.RecepieGuid, recepieItem.FoodGuid, recepieItem.Amount);
            _recepieItemRepository.Add(newRecepieItem);
            await _unitOfWork.CommitChangesAsync();
            List<RecepieItem> recepieItemList = await _recepieItemRepository.GetAll(); 
            return RecepieItemDTO.convertFromEntityListToDTOList(recepieItemList);
        }

        public async Task<RecepieItemDTO?> DeleteRecepieItem(Guid guid)
        {
            RecepieItem? recepieItem = await _recepieItemRepository.Find(guid);
            if (recepieItem == null)
            {
                return null;
            }
            _recepieItemRepository.Delete(recepieItem);
            await _unitOfWork.CommitChangesAsync();
            return RecepieItemDTO.convertFromEntityToDTO(recepieItem);
        }

        public async Task<RecepieItemDTO?> EditRecepieItem(RecepieItem recepieItem)
        {
            RecepieItem? foundRecepieItem = await _recepieItemRepository.Find(recepieItem.Guid);
            if (foundRecepieItem == null)
            {
                return null;
            }
            foundRecepieItem.Amount = recepieItem.Amount;
            await _unitOfWork.CommitChangesAsync();
            return RecepieItemDTO.convertFromEntityToDTO(foundRecepieItem);
        }

        public async Task<List<RecepieItemDTO>?> GetAllRecepieItemsByRecepieGuid(Guid guid)
        {
            List<RecepieItem> recepieItemList = await _recepieItemRepository.GetAllRecepieItemsByRecepieGuid(guid);
            if (recepieItemList == null)
            {
                return null;
            }
            return RecepieItemDTO.convertFromEntityListToDTOList(recepieItemList);
        }

        public async static Task<List<Guid>> GetFoodGuidsByRecepieGuid(Guid RecepieGuid, IRecepieItemRepository dataContext)
        {
            List<Guid> guidList = new List<Guid>();
            List<RecepieItem> recepieItemList = await dataContext.GetAllRecepieItemsByRecepieGuid(RecepieGuid);
            foreach (RecepieItem item in recepieItemList)
            {
                guidList.Add(item.FoodGuid);
            }
            return guidList;
        }

    }
}

