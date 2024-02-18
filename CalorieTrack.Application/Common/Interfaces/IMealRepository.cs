using CalorieTrack.Domain.Model;


namespace CalorieTrack.Application.Common.Interfaces
{
    public interface IMealRepository
    {
        void Add(Meal meal);

        Task<List<Meal>> GetAll();

        Task<Meal?> Find(Guid id);

        void Delete(Meal meal);
    }
}
