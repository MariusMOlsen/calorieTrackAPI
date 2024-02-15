
using CalorieTrack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrack.Application.Common.Interfaces
{
    public interface IFoodRepository
    {
        void Add(Food food);
        Task<Food?> Find(Guid id);

        Task<List<Food>> GetAll();
        void Delete(Food food);

        Task<List<Food>?> GetFoodListByGuidList(List<Guid> foodGuids);

    }
}
