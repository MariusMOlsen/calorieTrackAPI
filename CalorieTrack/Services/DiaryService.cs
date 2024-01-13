using CalorieTrack.Data;
using CalorieTrack.DTO;
using CalorieTrack.Model;
using CalorieTrack.Services.interfaces;
using System.Reflection.Metadata.Ecma335;

namespace CalorieTrack.Services
{
    public class DiaryService: IDiaryService
    {
        private readonly DataContext _context;

        public DiaryService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<DiaryDTO>> GetDiaryList(DateTime? dateInput = null)

        {
            Guid userGuid = Guid.NewGuid();

            DateTime specificDate = new DateTime();
            if (dateInput != null)
            {
                specificDate = (DateTime)dateInput;
            }
            // Calculate the start and end dates for the date range
            DateTime startDate = specificDate.AddDays(-50);
            DateTime endDate = specificDate.AddDays(50);

            // Query existing diaries for the specific user and date range
            var existingDiaries = _context.Diaries
                .Where(d => d.userGuid == userGuid && d.Date >= startDate && d.Date <= endDate)
                .ToList();

            // Extract the dates from the existing diaries
            var existingDates = existingDiaries.Select(d => d.Date).ToList();

            // Create a list of missing dates within the date range
            var missingDates = Enumerable.Range(0, (int)(endDate - startDate).TotalDays + 1)
                .Select(offset => startDate.AddDays(offset))
                .Except(existingDates)
                .ToList();

            // Create Diary entities for missing dates and add them to the context
            foreach (var date in missingDates)
            {
                _context.Diaries.Add(new Diary(

                   userGuid,
                   date)
                // Other properties as needed
                );
            }

            // Save changes to the database to persist the new Diary entries
           await _context.SaveChangesAsync();

            // Query the diaries again to include the newly created entries
            var updatedDiaries = _context.Diaries
                .Where(d => d.userGuid == userGuid && d.Date >= startDate && d.Date <= endDate)
                .ToList();
        
           return DiaryDTO.convertFromEntityListToDTOList(updatedDiaries);
        }
    
    }
}
