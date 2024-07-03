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
    public class UnitDefinitionRepository : IUnitDefinitionRepository
    {
        private readonly DataContext _context;
        public UnitDefinitionRepository(DataContext context)
        {
            _context = context;
        }

       
        public void Add(UnitDefinition unitDefition)
        {
            _context.UnitDefinition.Add(unitDefition);
        }

        public async Task<List<UnitDefinition>> GetAll()
        {
            return await _context.UnitDefinition.ToListAsync();
        }

        public async Task<UnitDefinition?> Find(Guid id)
        {
          return   await _context.UnitDefinition.FindAsync(id);
        }

        public void Delete(UnitDefinition unitDefinition)
        {
            _context.UnitDefinition.Remove(unitDefinition);
        }
    }
}
