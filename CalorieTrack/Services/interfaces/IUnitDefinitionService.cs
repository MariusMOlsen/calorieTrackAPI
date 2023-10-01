using CalorieTrack.Model;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrack.Services.interfaces
{
    public interface IUnitDefinitionService
    {

        Task<List<UnitDefinitionDTO>> AddUnitDefition(string name, int defaultAmount);
        Task<List<UnitDefinitionDTO>> DeleteUnitDefinition(Guid Guid);

        Task<List<UnitDefinitionDTO>> GetUnitDefinitions();
        Task<UnitDefinitionDTO> GetSingleUnitDefiniton(Guid Guid);



    }
}
