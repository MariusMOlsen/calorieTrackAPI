using CalorieTrack.Domain.Model;
using CalorieTrack.Model;

namespace CalorieTrack.DTO
{
    public class DiaryDTO
    {
        public Guid Guid { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public Guid NutritionGuid { get; set; }
        public int Sections { get; set; }
        public Guid userGuid { get; set; }

     
        public DiaryDTO(Guid guid,DateTime date, double weight, Guid nutritionGuid, Guid userGuid, int sections)
        {
            this.Guid = guid;
            this.Date = date;
            this.Weight = weight;
            this.NutritionGuid = nutritionGuid;
            this.userGuid = userGuid;
            this.Sections = sections;

        }

        public static List<DiaryDTO> convertFromEntityListToDTOList(List<Diary> entityList)
        {
            List<DiaryDTO> DTOList = new List<DiaryDTO>();
            foreach (Diary entity in entityList)
            {
                DTOList.Add(new DiaryDTO(entity.Guid, entity.Date, entity.Weight, entity.NutritionGuid, entity.userGuid, entity.Sections));
            }

            return DTOList;
        }

        public static DiaryDTO convertFromEntityToDTO(Diary entity)
        {
            return new DiaryDTO(entity.Guid, entity.Date, entity.Weight, entity.NutritionGuid, entity.userGuid, entity.Sections);
        }
    }
}
