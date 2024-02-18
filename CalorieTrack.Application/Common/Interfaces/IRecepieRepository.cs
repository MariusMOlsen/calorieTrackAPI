

using CalorieTrack.Domain.Model;

namespace CalorieTrack.Application.Common.Interfaces
{
    public interface IRecepieRepository
    {

        void Add(Recepie recepie);
        Task<Recepie?> Find(Guid id);
        void Delete(Recepie recepie);

        Task<List<Recepie>> GetListByUserId(Guid id);
    }
}
