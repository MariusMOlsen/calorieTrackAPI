using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CalorieTrack.Model.Interfaces;

namespace CalorieTrack.Model
{
    public class Nutrition : INutritionObject
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Guid { get; set; }
        public int Protein { get; set; }
        public int Carbohydrates { get; set; }
        public int Fat { get; set; }
        
        public int Calories { get; set; }

        public Guid UnitDefinitionGuid { get; set; }

        public Nutrition() { }
        public Nutrition(int protein, int carbohydrates, int fat, int calories) { 
            this.Protein = protein;
            this.Carbohydrates= carbohydrates;
            this.Fat = fat;
            this.Guid= Guid.NewGuid();
            this.UnitDefinitionGuid = Guid.Empty;
            this.Calories = calories;
        }

        public Nutrition(int protein, int carbohydrates, int fat, int calories, Guid unitDefinitionGuid)
        {
            this.Protein = protein;
            this.Carbohydrates = carbohydrates;
            this.Fat = fat;
            this.Guid = Guid.NewGuid();
            this.Calories = calories;
            this.UnitDefinitionGuid = unitDefinitionGuid; 
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
