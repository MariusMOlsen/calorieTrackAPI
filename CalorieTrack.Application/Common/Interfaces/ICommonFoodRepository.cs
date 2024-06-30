using CalorieTrack.Domain.Model.Food;

namespace CalorieTrack.Application.Common.Interfaces;


    public interface ICommonFoodRepository
    {
        void Add(CommonFood food);
        Task<CommonFood?> Find(Guid id);

        Task<List<CommonFood>> GetAll();
        void Delete(CommonFood food);

        Task<List<CommonFood>?> GetFoodListByGuidList(List<Guid> foodGuids);

    }
