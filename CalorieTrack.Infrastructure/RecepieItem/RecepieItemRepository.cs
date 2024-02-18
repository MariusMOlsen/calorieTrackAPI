using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Data;
using CalorieTrack.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;

namespace CalorieTrack.Infrastructure
{
    public class RecepieItemRepository: IRecepieItemRepository
    {
        private readonly DataContext _context;
        public RecepieItemRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(RecepieItem recepieItem)
        {
          _context.RecepieItems.Add(recepieItem);
        }

        public void Delete(RecepieItem recepieitem)
        {
            _context.RecepieItems.Remove(recepieitem);
        }

        public async Task<RecepieItem?> Find(Guid id)
        {
          return  await _context.RecepieItems.FindAsync(id);
        }

        public async Task<List<RecepieItem>> GetAll()
        {
           return await _context.RecepieItems.ToListAsync();
        }

        public async Task<List<RecepieItem>> GetAllRecepieItemsByRecepieGuid(Guid id)
        {
            return await _context.RecepieItems.Where(r => r.RecepieGuid == id).ToListAsync();
        }

      
    }
}
