using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Data;
using CalorieTrack.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrack.Infrastructure
{
    public class MealRepository : IMealRepository
    {
        private readonly DataContext _context;

        public MealRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Meal meal)
        {
            _context.Meals.Add(meal);
        }

        public void Delete(Meal meal)
        {
            _context.Remove(meal);
        }

        public async Task<Meal?> Find(Guid id)
        {
            return await _context.Meals.FindAsync(id);
        }

        public async Task<List<Meal>> GetAll()
        {
            return await _context.Meals.ToListAsync();
        }
    }
}
