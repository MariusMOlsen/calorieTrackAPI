using CalorieTrack.Domain.Model;

namespace CalorieTrack.DTO
{
    public class MealDTO
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public Guid NutritionGuid { get; set; }
        public Guid UserGuid { get; set; }

        public MealDTO(string Name, Guid NutritionGuid, Guid UserGuid, Guid guid)
        {
            this.UserGuid = UserGuid;
            this.Name = Name;
            this.NutritionGuid = NutritionGuid;
            this.Guid = guid;
        }


        public static List<MealDTO> convertFromEntityListToDTOList(List<Meal> mealList)
        {
            List<MealDTO> DTOList = new List<MealDTO>();
            foreach (Meal meal in mealList)
            {
                DTOList.Add( new MealDTO(meal.Name, meal.NutritionGuid, meal.UserGuid, meal.Guid));
            }

            return DTOList;
        }

        public static MealDTO? convertFromEntityToDTO(Meal meal)
        {
            return new MealDTO(meal.Name, meal.NutritionGuid, meal.UserGuid,meal.Guid);
        }
    }
}
