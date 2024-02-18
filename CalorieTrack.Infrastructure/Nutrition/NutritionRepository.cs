
using CalorieTrack.Application.Common.Interfaces;


using CalorieTrack.Data;
using CalorieTrack.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrack.Infrastructure
{
    public class NutritionRepository : INutritionRepository
    {
        private readonly DataContext _context;

        public NutritionRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Nutrition nutrition)
        {
           _context.Add(nutrition);
        }

        public void Delete(Nutrition nutrition)
        {
            _context.Remove(nutrition);
        }

        public async Task<Nutrition?> Find(Guid id)
        {
            return await _context.Nutritions.FindAsync(id);
        }

        public async Task<List<Nutrition>> GetAll()
        {
            return await _context.Nutritions.ToListAsync();
        }

        public async  Task<List<Nutrition>> GetNutritionListByGuidList(List<Guid> guidList)
        {
          return await _context.Nutritions.Where(n => guidList.Contains(n.Guid)).ToListAsync();
        }
    }
}
