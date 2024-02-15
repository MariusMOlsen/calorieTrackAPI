using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Data;
using CalorieTrack.Domain.Model;
using CalorieTrack.Model;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrack.Infrastructure
{
    public class DiaryRepository : IDiaryRepository
    {
        private readonly DataContext _context;
        public DiaryRepository(DataContext context)
        {
            _context = context;
        }

        public void AddToDiary(Guid userId, DateTime date)
        {
            _context.Diaries.Add(new Diary(

                   userId,
                   date)
              
                );
        }

        public async Task<List<Diary>?> getDiariesListByIdBetweenDate(Guid id, DateTime startDate, DateTime endDate)
        {
            return await _context.Diaries.Where(d => d.userGuid == id && d.Date >= startDate && d.Date <= endDate)
                   .ToListAsync();
        }

        Task<List<Diary>?> IDiaryRepository.getDiariesListByIdBetweenDate(Guid id, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
