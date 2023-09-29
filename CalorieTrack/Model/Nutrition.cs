using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CalorieTrack.Interfaces.Model;

namespace CalorieTrack.Model
{
    public class Nutrition : INutritionObject
    {
        public int Id { get; set; }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Guid { get; set; }
        public int Protein { get; set; }
        public int Carbohydrates { get; set; }
        public int Fat { get; set; }

        public Guid? unitDefinitionGuid { get; set; }

        public Nutrition(int protein, int carbohydrates, int fat) { 
            this.Protein = protein;
            this.Carbohydrates= carbohydrates;
            this.Fat = fat;
            this.Guid= Guid.NewGuid();
        }

        public Nutrition(int protein, int carbohydrates, int fat, Guid unitDefinitionGuid)
        {
            this.Protein = protein;
            this.Carbohydrates = carbohydrates;
            this.Fat = fat;
            this.Guid = Guid.NewGuid();
            this.unitDefinitionGuid = unitDefinitionGuid; 
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
