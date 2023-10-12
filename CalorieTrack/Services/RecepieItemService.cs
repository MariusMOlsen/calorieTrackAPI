using CalorieTrack.Data;
using CalorieTrack.DTO;
using CalorieTrack.Model;
using CalorieTrack.Services.interfaces;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System;

namespace CalorieTrack.Services
{
    public class RecepieItemService: IRecepieItemService

    {
        private readonly DataContext _dataContext;

        public RecepieItemService(DataContext dataContext) { _dataContext = dataContext; }
        public async Task<List<RecepieItemDTO>> AddRecepieItem(RecepieItem recepieItem)
        {
            RecepieItem newRecepieItem = new RecepieItem(recepieItem.RecepieGuid, recepieItem.FoodGuid, recepieItem.Amount);
            _dataContext.RecepieItems.Add(newRecepieItem);
            await _dataContext.SaveChangesAsync();
            List<RecepieItem> recepieItemList = await _dataContext.RecepieItems.ToListAsync();
            return RecepieItemDTO.convertFromEntityListToDTOList(recepieItemList);
        }

        public  async Task<RecepieItemDTO?> DeleteRecepieItem(Guid guid)
        {
          RecepieItem? recepieItem = await  _dataContext.RecepieItems.FindAsync(guid);
            if(recepieItem == null)
            {
                return null;
            }
            _dataContext.RecepieItems.Remove(recepieItem);
            await _dataContext.SaveChangesAsync();
            return RecepieItemDTO.convertFromEntityToDTO(recepieItem);
        }

        public async Task<RecepieItemDTO?> EditRecepieItem(RecepieItem recepieItem)
        {
            RecepieItem? foundRecepieItem = await _dataContext.RecepieItems.FindAsync(recepieItem.Guid);
            if(foundRecepieItem == null)
            {
                return null;
            }
            foundRecepieItem.Amount = recepieItem.Amount;
            await _dataContext.SaveChangesAsync();
            return RecepieItemDTO.convertFromEntityToDTO(foundRecepieItem);
        }

        public async Task<List<RecepieItemDTO>?> GetAllRecepieItemsByRecepieGuid(Guid guid)
        {
            List<RecepieItem> recepieItemList = await _dataContext.RecepieItems.Where(r => r.RecepieGuid == guid).ToListAsync();
            if(recepieItemList == null)
            {
                return null;
            }
            return RecepieItemDTO.convertFromEntityListToDTOList(recepieItemList);
        }

        public static List<Guid> GetFoodGuidsByRecepieGuid(Guid RecepieGuid, DataContext dataContext)
        {
            List<Guid> guidList = new List<Guid>();
            List<RecepieItem> recepieItemList = dataContext.RecepieItems.Where(r => r.RecepieGuid == RecepieGuid).ToList();
            foreach (RecepieItem item in recepieItemList)
            {
                guidList.Add(item.FoodGuid);
            }
            return guidList;
        }


    }
}

