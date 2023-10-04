using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CalorieTrack.Model.Interfaces;

namespace CalorieTrack.Model
{
    public class Meal : INutritionObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public Guid NutritionGuid { get; set; }
        public Guid UserGuid { get; set; }

        public Meal(string Name, Guid UserGuid)
        {
            this.UserGuid = UserGuid;
            this.Name = Name;
            this.NutritionGuid = Guid.Empty;
            this.Guid = Guid.NewGuid();
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
