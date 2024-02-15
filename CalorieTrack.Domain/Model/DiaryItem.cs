using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CalorieTrack.Constants.Enums;

namespace CalorieTrack.Domain.Model
{

    
    public class DiaryItem
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Guid { get; set; }
        public Guid DiaryGuid { get; set; }

        public int Amount { get; set; }

        public InstanceDefinition InstanceDefinition { get; set; }
        public Guid ItemGuid { get; set; }

        public DiaryItem() { }
        public DiaryItem( Guid diaryGuid, int amount, InstanceDefinition instanceDefinition, Guid itemGuid)
        {
            Guid = Guid.NewGuid();
            DiaryGuid = diaryGuid;
            Amount = amount;
            InstanceDefinition = instanceDefinition;
            ItemGuid = itemGuid;
        }
    }
}
