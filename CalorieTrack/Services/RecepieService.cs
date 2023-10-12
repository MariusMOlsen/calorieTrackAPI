using CalorieTrack.Data;
using CalorieTrack.DTO;
using CalorieTrack.Model;
using CalorieTrack.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrack.Services
{
    public class RecepieService : IRecepieService
    {
        private readonly DataContext _context;
        public RecepieService(DataContext context) { _context = context; }

        public async Task<RecepieDTO> AddRecepie(string name, Guid userGuid)
        {
            Recepie recepie = new Recepie(name, userGuid);
            _context.Add(recepie);
            await _context.SaveChangesAsync();

            return RecepieDTO.convertFromEntityToDTO(recepie);
        }

        public async Task<RecepieDTO?> UpdateRecepieNutrition(Guid guid)
        {
            Recepie? recepie = await _context.Recepies.FindAsync(guid);
            if (recepie == null)
            {
                return null;
            }

            List<Guid> RecepieItemFoodGuids = RecepieItemService.GetFoodGuidsByRecepieGuid(guid, _context);
            List<Food> foodList = FoodService.GetFoodListByGuidList(RecepieItemFoodGuids, _context);
            List<Guid> nutritionGuidList = new List<Guid>();

            foreach (Food food in foodList)
            {
                nutritionGuidList.Add(food.NutritionGuid);
            }

            List<Nutrition> nutritionList = NutritionService.GetNutritionListByGuidList(nutritionGuidList, _context);
            Nutrition nutritionObject = NutritionService.convertNutritionListToSingleObject(nutritionList, _context);


            recepie.NutritionGuid = nutritionObject.Guid;
            _context.SaveChanges();
            return RecepieDTO.convertFromEntityToDTO(recepie);


        }

        public async Task<List<RecepieDTO>?> DeleteRecepie(Guid guid)
        {
           Recepie? recepie = await _context.Recepies.FindAsync(guid);
            if(recepie == null)
            {
                return null;
            }
            _context.Recepies.Remove(recepie);
            _context.SaveChanges();
            return  new List<RecepieDTO>();

        }

        public async Task<List<RecepieDTO>> GetRecepieListByUserGuid(Guid userGuid)
        {
            List<Recepie> recepieList = await _context.Recepies.Where(r => r.UserGuid == userGuid).ToListAsync();
             return RecepieDTO.convertFromEntityListToDTOList(recepieList);

        }
    }
}

