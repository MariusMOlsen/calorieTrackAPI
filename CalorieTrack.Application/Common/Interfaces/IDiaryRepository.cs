using CalorieTrack.Domain.Model;
using CalorieTrack.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalorieTrack.Application.Common.Interfaces
{
    public interface IDiaryRepository
    {
        Task<List<Diary>?> getDiariesListByIdBetweenDate(Guid id,DateTime startDate, DateTime endDate);
        void AddToDiary(Guid userId, DateTime date);
    }
}
