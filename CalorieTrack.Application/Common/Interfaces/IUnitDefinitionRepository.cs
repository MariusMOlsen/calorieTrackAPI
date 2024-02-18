using CalorieTrack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrack.Application.Common.Interfaces
{
    public interface IUnitDefinitionRepository
    {
        void Add(UnitDefinition unitDefition);
        Task<List<UnitDefinition>> GetAll();
        Task<UnitDefinition?> Find(Guid id);

        void Delete(UnitDefinition unitDefinition);
    }
}
