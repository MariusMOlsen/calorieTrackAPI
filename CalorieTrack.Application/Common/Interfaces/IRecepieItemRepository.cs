using CalorieTrack.Domain.Model;


namespace CalorieTrack.Application.Common.Interfaces
{
    public interface IRecepieItemRepository
    {
        void Add(RecepieItem recepieItem);
        Task<List<RecepieItem>> GetAll();

        Task<RecepieItem?> Find(Guid id);

        void Delete(RecepieItem recepieitem);

        Task<List<RecepieItem>> GetAllRecepieItemsByRecepieGuid(Guid id);
    }
}
