using CalorieTrack.Model;

namespace CalorieTrack.DTO
{
    public class RecepieItemDTO
    {
        public Guid Guid { get; set; }

        public Guid RecepieGuid { get; set; }
        public Guid FoodGuid { get; set; }

        public int Amount { get; set; }

        public RecepieItemDTO(Guid guid,Guid recepieGuid, Guid foodGuid, int amount)
        {
            this.Guid = guid;
            this.FoodGuid = foodGuid;
            this.RecepieGuid = recepieGuid;
            this.Amount = amount;
        }
        public static List<RecepieItemDTO> convertFromEntityListToDTOList(List<RecepieItem> entityList)
        {
            List<RecepieItemDTO> DTOList = new List<RecepieItemDTO>();
            foreach (RecepieItem entity in entityList)
            {

                DTOList.Add(new RecepieItemDTO(entity.Guid,entity.RecepieGuid, entity.FoodGuid, entity.Amount));

            }
            return DTOList;
        }
        public static RecepieItemDTO convertFromEntityToDTO(RecepieItem entity)
        {
            return new RecepieItemDTO(entity.Guid, entity.RecepieGuid, entity.FoodGuid, entity.Amount);

        }
    }
}
