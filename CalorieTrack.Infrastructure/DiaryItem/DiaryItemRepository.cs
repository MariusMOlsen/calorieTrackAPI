using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Data;
using CalorieTrack.Domain;
using CalorieTrack.Domain.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrack.Infrastructure
{
    public class DiaryItemRepository : IDiaryItemRepository
    {
        private readonly DataContext _context;

        public DiaryItemRepository(DataContext context)
        {
            _context = context;
        }
            
        public async Task Add(DiaryItem diaryItem)
        {
            await _context.DiaryItems.AddAsync(diaryItem);
        }

        public async Task GetAllDiaryItems()
        {
            await _context.DiaryItems.ToListAsync();
        }

        public async Task Find(Guid id)
        {
            await _context.DiaryItems.FindAsync(id);
        }

        Task<List<DiaryItem>> IDiaryItemRepository.GetAllDiaryItems()
        {
            throw new NotImplementedException();
        }

        Task<DiaryItem> IDiaryItemRepository.Find(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Delete(DiaryItem diaryItem)
        {
            throw new NotImplementedException();
        }

  
    }
}
