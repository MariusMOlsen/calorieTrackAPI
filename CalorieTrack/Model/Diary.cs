using CalorieTrack.Interfaces.Model;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CalorieTrack.Model
{
    public class Diary: INutritionObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]  
        public Guid Guid { get; set; }
        public DateTime Date { get; set; }
        public double Weight { get; set; }
        public Guid NutritionGuid { get; set; }

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
