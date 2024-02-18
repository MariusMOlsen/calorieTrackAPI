using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Data;
using CalorieTrack.Domain.Model;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrack.Infrastructure
{
    public class FoodRepository : IFoodRepository
    {
        private readonly DataContext _context;
        public FoodRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Food food)
        {

            _context.Add(food);
        }

        public async Task<Food?> Find(Guid id)
        {
            return await _context.Foods.FindAsync(id);
        }

        public async Task<List<Food>> GetAll()
        {
            return await _context.Foods.ToListAsync();
        }
        public void Delete(Food food)
        {
            _context.Foods.Remove(food);
        }
        
        public async Task<List<Food>?> GetFoodListByGuidList(List<Guid> guidList)
        {
               List<Food> foodList = await _context.Foods.Where(food => guidList.Contains(food.Guid)).ToListAsync();
            return foodList;
        }
    }
}
