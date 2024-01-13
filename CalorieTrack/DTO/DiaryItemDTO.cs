using CalorieTrack.Model;
using static CalorieTrack.Constants.Enums;

namespace CalorieTrack.DTO
{
    public class DiaryItemDTO
    {
        public Guid Guid { get; set; }
        public Guid DiaryGuid { get; set; }

        public int Amount { get; set; }

        public InstanceDefinition InstanceDefinition { get; set; }
        public Guid ItemGuid { get; set; }


        public DiaryItemDTO(Guid guid,Guid diaryGuid, int amount, InstanceDefinition instanceDefinition, Guid itemGuid)
        {
            Guid = guid;
            DiaryGuid = diaryGuid;
            Amount = amount;
            InstanceDefinition = instanceDefinition;
            ItemGuid = itemGuid;
        }

        public static List<DiaryItemDTO> convertFromEntityListToDTOList(List<DiaryItem> entityList)
        {
            List<DiaryItemDTO> DTOList = new List<DiaryItemDTO>();
            foreach (DiaryItem entity in entityList)
            {
                DTOList.Add(new DiaryItemDTO(entity.Guid, entity.DiaryGuid, entity.Amount, entity.InstanceDefinition, entity.ItemGuid));
            }

            return DTOList;
        }

        public static DiaryItemDTO convertFromEntityToDTO(DiaryItem entity)
        {
            return new DiaryItemDTO(entity.Guid, entity.DiaryGuid, entity.Amount, entity.InstanceDefinition, entity.ItemGuid);
        }
    }
}
