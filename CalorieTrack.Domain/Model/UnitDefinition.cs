using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace CalorieTrack.Domain.Model
{
    public class UnitDefinition
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Guid { get; set; } 

        public string Name { get; set; }
        public int defaultAmount { get; set; }
        public Guid NutritionGuid { get; private set; }
        public Nutrition Nutrition { get; private set; }

       public UnitDefinition(string Name, int defaultAmount, Nutrition nutrition) {
            this.Name = Name;
            this.defaultAmount = defaultAmount;
            this.Guid =  Guid.NewGuid();
            this.NutritionGuid = nutrition.Guid;
            this.Nutrition = nutrition;
            
        }

    }
}
