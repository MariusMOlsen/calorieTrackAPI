using CalorieTrack.Domain.Model.Common;
using CalorieTrack.Model.Interfaces;

namespace CalorieTrack.Domain.Model.Food
{
    
    public abstract class Food: Entity , INutritionObject
    {
      

        // [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.None)]
        // public Guid Guid { get; set; }
        public string Name { get;  set; }
        public Guid NutritionGuid { get; private set; }
        public Nutrition Nutrition { get; private set; }
        public int AmountOfUnit { get; set; }
        
        public DateTime CreatedDate { get; private set; }
        public string Barcode { get; set; }

        public Food()
        {
            
        }
        
        public Food(string name, Guid nutritionGuid, int amountOfUnit, string barcode) :base(Guid.NewGuid())
        {
            this.Name = name;
            this.Barcode = barcode;
            this.AmountOfUnit = amountOfUnit;
            this.NutritionGuid= nutritionGuid;
            this.CreatedDate = DateTime.Now;
            
       
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
