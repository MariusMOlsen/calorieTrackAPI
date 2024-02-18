using CalorieTrack.Domain.Model;
namespace CalorieTrack.Model
{
    public class NutritionDTO
    {


        public Guid Guid { get; set; }
        public int Protein { get; set; }
        public int Carbohydrates { get; set; }
        public int Fat { get; set; }
        public int Calories { get; set; }

        public Guid? UnitDefinitionGuid { get; set; }
        public NutritionDTO(Guid guid, int protein, int carbohydrates, int fat, int calories)
        {
            this.Guid = guid;
            this.Protein = protein;
            this.Carbohydrates = carbohydrates;
            this.Fat = fat;
            this.UnitDefinitionGuid = Guid.Empty;
            this.Calories = calories;
        }

        public NutritionDTO(Guid guid, int protein, int carbohydrates, int fat, int calories, Guid unitDefinitionGuid)
        {
            this.Guid = guid;
            this.Protein = protein;
            this.Carbohydrates = carbohydrates;
            this.Fat = fat;
            this.Calories = calories;
            this.UnitDefinitionGuid = unitDefinitionGuid;
        }

        public static List<NutritionDTO> convertFromEntityListToDTOList(List<Nutrition> nutritonList)
        {
            List<NutritionDTO> nutritionDTOList = new List<NutritionDTO>();
            foreach (Nutrition nutrition in nutritonList)
            {
                if (nutrition.UnitDefinitionGuid != Guid.Empty)
                {
                    nutritionDTOList.Add(new NutritionDTO(nutrition.Guid, nutrition.Protein, nutrition.Carbohydrates, nutrition.Fat, nutrition.Calories, nutrition.UnitDefinitionGuid));

                }
                else
                {
                    nutritionDTOList.Add(new NutritionDTO(nutrition.Guid, nutrition.Protein, nutrition.Carbohydrates, nutrition.Fat, nutrition.Calories));
                }

            }
            return nutritionDTOList;
        }

        public static NutritionDTO convertFromEntityToDTO(Nutrition nutrition)
        {
            if (nutrition.UnitDefinitionGuid != Guid.Empty)
            {
                return new NutritionDTO(nutrition.Guid, nutrition.Protein, nutrition.Carbohydrates, nutrition.Fat, nutrition.Calories, nutrition.UnitDefinitionGuid);

            }
            else
            {
                return new NutritionDTO(nutrition.Guid, nutrition.Protein, nutrition.Carbohydrates, nutrition.Fat, nutrition.Calories);
            }

        }
    }
}
