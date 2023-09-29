using CalorieTrack.Data;
using CalorieTrack.Interfaces.Services;
using CalorieTrack.Model;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrack.Services
{
    public class UnitDefinitionService: IUnitDefinitionService
    {
        private readonly DataContext _context;
        
        public UnitDefinitionService(DataContext context) { _context = context; }

        public async Task<List<UnitDefinition>> AddUnitDefition(string name, int defaultAmount)
        {
            UnitDefinition unitDefinition = new UnitDefinition(name, defaultAmount);
            _context.UnitDefinition.Add(unitDefinition);
            await _context.SaveChangesAsync();
            return await _context.UnitDefinition.ToListAsync();
        }

        public async Task<List<UnitDefinition>> DeleteUnitDefinition(Guid Guid)
        {
            var foundUnitDefinition = await _context.UnitDefinition.FindAsync(Guid);

            if (foundUnitDefinition == null) {
                    return null;
            
            }
             _context.UnitDefinition.Remove(foundUnitDefinition);
            await _context.SaveChangesAsync();
            return await _context.UnitDefinition.ToListAsync();
        }
        
        public async Task<List<UnitDefinition>> GetUnitDefinitions()
        {
            return await _context.UnitDefinition.ToListAsync();
        }

        public async Task<UnitDefinition> GetSingleUnitDefiniton(Guid Guid)
        {
            return await _context.UnitDefinition.FindAsync(Guid);
        }
    }
}
