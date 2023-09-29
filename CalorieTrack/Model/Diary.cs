using CalorieTrack.Interfaces.Model;

namespace CalorieTrack.Model
{
    public class Diary: INutritionObject
    {
        public int Id { get; set; }
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
