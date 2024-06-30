using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Data;
using CalorieTrack.Domain.Model.Food;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrack.Infrastructure.UserFoodRepo
{
    public class UserFoodRepository : IUserFoodRepository
    {
        private readonly DataContext _context;
        public UserFoodRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(UserFood food)
        {
            

            _context.Add(food); 
        }

        public async Task<Domain.Model.Food.UserFood?> Find(Guid id)
        {
            return await _context.UserFoods.FindAsync(id);
        }

        public async Task<List<UserFood>> GetAll()
        {
            return await _context.UserFoods.ToListAsync();
        }
        public void Delete(UserFood food)
        {
            _context.UserFoods.Remove(food);
        }
        
        public async Task<List<UserFood>?> GetFoodListByGuidList(List<Guid> guidList)
        {
               List<UserFood> foodList = await _context.UserFoods.Where(food => guidList.Contains(food.Guid)).ToListAsync();
            return foodList;
        }
    }
}
