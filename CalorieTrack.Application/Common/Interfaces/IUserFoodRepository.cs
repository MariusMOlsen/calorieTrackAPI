
using CalorieTrack.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalorieTrack.Domain.Model.Food;

namespace CalorieTrack.Application.Common.Interfaces
{
    public interface IUserFoodRepository
    {
        void Add(UserFood food);
        Task<UserFood?> Find(Guid id);

        Task<List<UserFood?>> GetAll();
        void Delete(UserFood food);

        Task<List<UserFood>?> GetFoodListByGuidList(List<Guid> foodGuids);

    }
}
