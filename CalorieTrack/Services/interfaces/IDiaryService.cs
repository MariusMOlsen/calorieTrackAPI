using CalorieTrack.DTO;

namespace CalorieTrack.Services.interfaces
{
    public interface IDiaryService
    {
        Task<List<DiaryDTO>> GetDiaryList(DateTime? dateInput);
    }
}
