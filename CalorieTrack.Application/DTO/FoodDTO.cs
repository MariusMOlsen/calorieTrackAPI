using CalorieTrack.Constants;
using CalorieTrack.Domain.Model;
using CalorieTrack.Model;
using static CalorieTrack.Constants.Enums;

namespace CalorieTrack.DTO
{
    public class FoodDTO
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public Guid NutritionGuid { get; set; }

        public int AmountOfUnit { get; set; }

        public string Barcode { get; set; }
        public InstanceDefinition InstanceDefinition { get; set; }

        public FoodDTO(Guid guid, string name, Guid nutritionGuid, int amountOfUnit, string barcode)
        {
            this.Guid = guid;
            this.Name = name;
            this.NutritionGuid = nutritionGuid;
            this.AmountOfUnit = amountOfUnit;
            this.Barcode = barcode;
            this.InstanceDefinition = Enums.InstanceDefinition.Food;
        }



        public static List<FoodDTO> convertFromEntityListToDTOList(List<Food> foodList)
        {
            List<FoodDTO> DTOList = new List<FoodDTO>();
            foreach (Food food in foodList)
            {
                DTOList.Add(new FoodDTO(food.Guid, food.Name, food.NutritionGuid, food.AmountOfUnit, food.Barcode));
            }

            return DTOList;
        }

        public static FoodDTO convertFromEntityToDTO(Food food)
        {
            return new FoodDTO(food.Guid, food.Name, food.NutritionGuid, food.AmountOfUnit, food.Barcode);
        }
    }


}
