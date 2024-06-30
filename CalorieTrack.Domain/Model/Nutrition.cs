using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CalorieTrack.Model.Interfaces;

namespace CalorieTrack.Domain.Model
{
    public class Nutrition : INutritionObject
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Guid { get; set; }
        public double Protein { get; set; }
        public double Carbohydrates { get; set; }
        public double Fat { get; set; }
        public double Calories { get; set; }
        public Guid UnitDefinitionGuid { get; set; }
        
        public UnitDefinition? UnitDefinition { get; set; }

        public Nutrition() { }
        public Nutrition(double protein, double carbohydrates, double fat, double calories) { 
            this.Protein = protein;
            this.Carbohydrates= carbohydrates;
            this.Fat = fat;
            this.Guid= Guid.NewGuid();
            this.Calories = calories;
        }

        public Nutrition(double protein, double carbohydrates, double fat, double calories, Guid unitDefinitionGuid)
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
