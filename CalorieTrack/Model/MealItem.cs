using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CalorieTrack.Model
{
    public enum MealtemType
    {
        Recepie,
        Food
    }
    public class MealItem
    {
        public int Id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Guid { get; set; }

        public Guid MealGuid { get; set; }
       
        public MealtemType MealItemType { get; set; }
        public Guid ItemGuid { get; set; }
        public MealItem(Guid MealGuid, MealtemType mealItemType,Guid itemGuid ) { 
            this.Guid = Guid.NewGuid();
            this.MealItemType = mealItemType;
            this.MealGuid = MealGuid;
            this.ItemGuid = itemGuid;
            }

       
    }
}
