using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CalorieTrack.Constants.Enums;
using CalorieTrack.DTO;

namespace CalorieTrack.Model
{
 
    public class MealItem
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Guid { get; set; }

        public Guid MealGuid { get; set; }
       
        public Guid ItemGuid { get; set; }

        public int Amount { get; set; }
        public InstanceDefinition InstanceDefinition { get; set; }

        public MealItem() { }
        public MealItem(Guid MealGuid,Guid itemGuid,int amount, InstanceDefinition instanceDefinition ) { 
            this.Guid = Guid.NewGuid();
            this.MealGuid = MealGuid;
            this.ItemGuid = itemGuid;
            this.InstanceDefinition = instanceDefinition;
            this.Amount= amount;
    }

       
    }
}
