

using CalorieTrack.Domain.Model;

namespace CalorieTrack.Application.Common.Interfaces
{
    public interface IDiaryItemRepository
    {
        Task Add(DiaryItem diaryItem);
        Task<List<DiaryItem>> GetAllDiaryItems();
        Task<DiaryItem> Find(Guid id);
        Task Delete(DiaryItem diaryItem);

    }
}
