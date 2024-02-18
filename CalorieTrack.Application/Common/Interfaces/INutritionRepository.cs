
using CalorieTrack.Domain.Model;
using System.Xml.Serialization;

namespace CalorieTrack.Application.Common.Interfaces
{
    public interface INutritionRepository
    {
        Task<List<Nutrition>> GetAll();

        void Add(Nutrition nutrition);

        Task<Nutrition?> Find(Guid id);

        void Delete(Nutrition nutrition);

        Task<List<Nutrition>> GetNutritionListByGuidList(List<Guid> guidList);
      
    }
}
