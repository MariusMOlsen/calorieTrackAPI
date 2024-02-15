using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CalorieTrack.Model.Interfaces;
using static CalorieTrack.Constants.Enums;
using CalorieTrack.Constants;

namespace CalorieTrack.Domain.Model
{
    public class Food: INutritionObject
    {
      

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public Guid NutritionGuid { get; set; }

        public int AmountOfUnit { get; set; }

        public string Barcode { get; set; }
        public InstanceDefinition InstanceDefinition { get; set; }

        public Food() { }
        public Food(string name, Guid nutritionGuid, int amountOfUnit, string barcode) {
            this.Guid = Guid.NewGuid();
            this.Name = name;
            this.Barcode = barcode;
            this.AmountOfUnit = amountOfUnit;
            this.NutritionGuid= nutritionGuid;
            this.InstanceDefinition = Enums.InstanceDefinition.Food;
    }
        public int GetCalories()
        {
            throw new NotImplementedException();
        }

        public int GetCarbohydrates()
        {
            throw new NotImplementedException();
        }

        public int GetFat()
        {
            throw new NotImplementedException();
        }

        public int GetProtein()
        {
            throw new NotImplementedException();
        }
    }
}
