using CalorieTrack.Data;
using CalorieTrack.Model;
using CalorieTrack.Services.interfaces;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrack.Services
{
    public class UnitDefinitionService: IUnitDefinitionService
    {
        private readonly DataContext _context;
        
        public UnitDefinitionService(DataContext context) { _context = context; }

        public async Task<List<UnitDefinitionDTO>> AddUnitDefition(string name, int defaultAmount)
        {
            UnitDefinition unitDefinition = new UnitDefinition(name, defaultAmount);
            _context.UnitDefinition.Add(unitDefinition);
            await _context.SaveChangesAsync();
            List<UnitDefinition> unitDefinitionList  = await _context.UnitDefinition.ToListAsync();
            return UnitDefinitionDTO.convertFromEntityListToDTOList(unitDefinitionList);
        }

        public async Task<List<UnitDefinitionDTO>?> DeleteUnitDefinition(Guid Guid)
        {
            var foundUnitDefinition = await _context.UnitDefinition.FindAsync(Guid);

            if (foundUnitDefinition == null) {
                    return null;
            
            }
             _context.UnitDefinition.Remove(foundUnitDefinition);
            await _context.SaveChangesAsync();
            List<UnitDefinition> unitDefinitionList = await _context.UnitDefinition.ToListAsync();
            return UnitDefinitionDTO.convertFromEntityListToDTOList(unitDefinitionList);
        }
        
        public async Task<List<UnitDefinitionDTO>> GetUnitDefinitions()
        {
            List<UnitDefinition> unitDefinitionList = await _context.UnitDefinition.ToListAsync();
            return UnitDefinitionDTO.convertFromEntityListToDTOList(unitDefinitionList);
        }

        public async Task<UnitDefinitionDTO> GetSingleUnitDefiniton(Guid Guid)
        {
            UnitDefinition unitDefinition = await _context.UnitDefinition.FindAsync(Guid);
            return UnitDefinitionDTO.convertFromEntityToDTO(unitDefinition);
        }
    }
}
