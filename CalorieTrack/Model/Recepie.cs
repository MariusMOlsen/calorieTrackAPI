using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CalorieTrack.Model.Interfaces;

namespace CalorieTrack.Model
{
    public class Recepie: INutritionObject
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Guid { get; set; }  
        public string Name { get; set; }

        public Guid NutritionGuid { get; set; }
        public Guid UserGuid { get; set; }
        public Recepie(string name, Guid nutritionGuid, Guid UserGuid) {
            this.Name = name;
            this.UserGuid = UserGuid;
            this.NutritionGuid = nutritionGuid;
            this.Guid = new Guid();
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
