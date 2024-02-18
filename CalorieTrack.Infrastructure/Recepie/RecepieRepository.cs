

using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Data;
using CalorieTrack.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrack.Infrastructure
{
    public class RecepieRepository: IRecepieRepository
    {
        private readonly DataContext _context;
       
        public RecepieRepository(DataContext context)
        {
            _context = context;
        }

        public void Add(Recepie recepie)
        {
            _context.Recepies.Add(recepie);
        }

        public void Delete(Recepie recepie)
        {
            _context.Recepies.Remove(recepie);
        }

        public async Task<Recepie?> Find(Guid id)
        {
            return await _context.Recepies.FindAsync(id);
        }

        public async Task<List<Recepie>> GetListByUserId(Guid id)
        {
           return await _context.Recepies.Where(r => r.UserGuid == id).ToListAsync();
        }
    }
}
