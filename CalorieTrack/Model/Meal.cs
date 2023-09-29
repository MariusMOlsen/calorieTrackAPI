using CalorieTrack.Interfaces.Model;

namespace CalorieTrack.Model
{
    public class Meal: INutritionObject
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public Guid NutritionGuid { get; set; }
        public Guid UserGuid { get; set; }

        public Meal(string Name, Guid NutritionGuid, Guid UserGuid) { 
        this.UserGuid = UserGuid;
            this.Name = Name;
            this.NutritionGuid = NutritionGuid;
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
