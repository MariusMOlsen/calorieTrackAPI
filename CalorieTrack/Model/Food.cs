using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CalorieTrack.Interfaces.Model;

namespace CalorieTrack.Model
{
    public class Food: INutritionObject
    {
        public int Id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public Guid NutritionGuid { get; set; }

        public int AmountOfUnit { get; set; }

        public string barcode { get; set; }

        public Food(string name, Guid nutritionGuid, int amountOfUnit, string barcode) {
            this.Guid = new Guid();
            this.Name = name;
            this.barcode = barcode;
            this.AmountOfUnit = amountOfUnit;
            this.NutritionGuid= nutritionGuid;
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
