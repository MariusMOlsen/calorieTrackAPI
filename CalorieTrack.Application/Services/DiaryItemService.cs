using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Domain.Model;
using CalorieTrack.DTO;
using CalorieTrack.Model;
using static CalorieTrack.Constants.Enums;

namespace CalorieTrack.Services
{
    public class DiaryItemService
    {
        private readonly IDiaryItemRepository _diaryRepository;
        private readonly IUnitOfWork _unitOfWork;
        public DiaryItemService(IDiaryItemRepository context, IUnitOfWork unitOfWork) { 
            _diaryRepository = context;
            _unitOfWork = unitOfWork;

        }

        public async Task<DiaryItemDTO> AddFoodItem(Guid diaryGuid, InstanceDefinition instanceDefinition, Guid itemGuid, int amount)
        {
            DiaryItem diaryItem = new DiaryItem(diaryGuid, amount, instanceDefinition, itemGuid);
            await _diaryRepository.Add(diaryItem);
            await _unitOfWork.CommitChangesAsync();
            return DiaryItemDTO.convertFromEntityToDTO(diaryItem);
        }

        public async Task<List<DiaryItemDTO>> GetFoodItems()
        {
            List<DiaryItem> DiaryItems = await _diaryRepository.GetAllDiaryItems();
            return DiaryItemDTO.convertFromEntityListToDTOList(DiaryItems);
        }

        public async Task<DiaryItemDTO?> EditDiaryItem(Guid diaryItemGuid, int amount)
        {
            DiaryItem foundDiaryItem = await _diaryRepository.Find(diaryItemGuid);
            if (foundDiaryItem == null)
            {
                return null;
            }

            foundDiaryItem.Amount = amount;
            await _unitOfWork.CommitChangesAsync();
            return DiaryItemDTO.convertFromEntityToDTO(foundDiaryItem);
        }

        public async Task<List<DiaryItemDTO>?> DeleteDiaryItem(Guid diaryItemGuid)
        {
            DiaryItem foundDiaryItem = await _diaryRepository.Find(diaryItemGuid);
            if (foundDiaryItem == null)
            {
                return null;
            }

           await _diaryRepository.Delete(foundDiaryItem);
            await _unitOfWork.CommitChangesAsync();

            List<DiaryItem> diaryItemList = await _diaryRepository.GetAllDiaryItems();
            return DiaryItemDTO.convertFromEntityListToDTOList(diaryItemList);
           
        }
    }
}
