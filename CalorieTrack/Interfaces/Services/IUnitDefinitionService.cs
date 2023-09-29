using CalorieTrack.Model;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrack.Interfaces.Services
{
    public interface IUnitDefinitionService
    {

        Task<List<UnitDefinition>> AddUnitDefition(string name, int defaultAmount);
        Task<List<UnitDefinition>> DeleteUnitDefinition(Guid Guid);

        Task<List<UnitDefinition>> GetUnitDefinitions();
        Task<UnitDefinition> GetSingleUnitDefiniton(Guid Guid);



    }
}
