using CalorieTrack.Data;
using CalorieTrack.DTO;
using CalorieTrack.Model;
using Microsoft.EntityFrameworkCore;
using static CalorieTrack.Constants.Enums;

namespace CalorieTrack.Services
{
    public class DiaryItemService
    {
        private readonly DataContext _context;
        public DiaryItemService(DataContext context) { _context = context; }

        public async Task<DiaryItemDTO> AddFoodItem(Guid diaryGuid, InstanceDefinition instanceDefinition, Guid itemGuid, int amount)
        {
            DiaryItem diaryItem = new DiaryItem(diaryGuid, amount, instanceDefinition, itemGuid);
            _context.DiaryItems.Add(diaryItem);
            await _context.SaveChangesAsync();
            return DiaryItemDTO.convertFromEntityToDTO(diaryItem);
        }

        public async Task<List<DiaryItemDTO>> GetFoodItems()
        {
            List<DiaryItem> DiaryItems = await _context.DiaryItems.ToListAsync();
            return DiaryItemDTO.convertFromEntityListToDTOList(DiaryItems);
        }

        public async Task<DiaryItemDTO?> EditDiaryItem(Guid diaryItemGuid, int amount)
        {
            DiaryItem foundDiaryItem = await _context.DiaryItems.FindAsync(diaryItemGuid);
            if (foundDiaryItem == null)
            {
                return null;
            }

            foundDiaryItem.Amount = amount;
            await _context.SaveChangesAsync();
            return DiaryItemDTO.convertFromEntityToDTO(foundDiaryItem);
        }

        public async Task<List<DiaryItemDTO>?> DeleteDiaryItem(Guid diaryItemGuid)
        {
            DiaryItem foundDiaryItem = await _context.DiaryItems.FindAsync(diaryItemGuid);
            if (foundDiaryItem == null)
            {
                return null;
            }

            _context.DiaryItems.Remove(foundDiaryItem);
            await _context.SaveChangesAsync();

            List<DiaryItem> diaryItemList = await _context.DiaryItems.ToListAsync();
            return DiaryItemDTO.convertFromEntityListToDTOList(diaryItemList);
           
        }
    }
}
