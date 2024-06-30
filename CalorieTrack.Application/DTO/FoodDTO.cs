using CalorieTrack.Constants;
using CalorieTrack.Domain.Model;
using static CalorieTrack.Constants.Enums;

namespace CalorieTrack.Application.DTO
{
    public class FoodDto
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public Guid NutritionGuid { get; set; }

        public int AmountOfUnit { get; set; }

        public string Barcode { get; set; }
        public InstanceDefinition InstanceDefinition { get; set; }

        public FoodDto(Guid guid, string name, Guid nutritionGuid, int amountOfUnit, string barcode)
        {
            this.Guid = guid;
            this.Name = name;
            this.NutritionGuid = nutritionGuid;
            this.AmountOfUnit = amountOfUnit;
            this.Barcode = barcode;
            this.InstanceDefinition = Enums.InstanceDefinition.Food;
        }



        public static List<FoodDto> convertFromEntityListToDTOList(List<Food> foodList)
        {
            List<FoodDto> DTOList = new List<FoodDto>();
            foreach (Food food in foodList)
            {
                DTOList.Add(new FoodDto(food.Guid, food.Name, food.NutritionGuid, food.AmountOfUnit, food.Barcode));
            }

            return DTOList;
        }

        public static FoodDto convertFromEntityToDTO(Food food)
        {
            return new FoodDto(food.Guid, food.Name, food.NutritionGuid, food.AmountOfUnit, food.Barcode);
        }
    }


}
