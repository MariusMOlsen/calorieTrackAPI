﻿using CalorieTrack.Constants;
using CalorieTrack.Domain.Model;
using CalorieTrack.Domain.Model.Food;
using static CalorieTrack.Constants.Enums;

namespace CalorieTrack.Application.DTO
{
    public class UserFoodDto
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }
        public Guid NutritionGuid { get; set; }

        public int AmountOfUnit { get; set; }

        public string Barcode { get; set; }
        public InstanceDefinition InstanceDefinition { get; set; }

        public UserFoodDto(Guid guid, string name, Guid nutritionGuid, int amountOfUnit, string barcode)
        {
            this.Guid = guid;
            this.Name = name;
            this.NutritionGuid = nutritionGuid;
            this.AmountOfUnit = amountOfUnit;
            this.Barcode = barcode;
            this.InstanceDefinition = Enums.InstanceDefinition.UserFood;
        }



        public static List<UserFoodDto> convertFromEntityListToDTOList(IEnumerable<UserFood> foodList)
        {
            List<UserFoodDto> DTOList = new List<UserFoodDto>();
            foreach (UserFood food in foodList)
            {
                DTOList.Add(new UserFoodDto(food.Guid, food.Name, food.NutritionGuid, food.AmountOfUnit, food.Barcode));
            }

            return DTOList;
        }

        public static UserFoodDto convertFromEntityToDTO(UserFood food)
        {
            return new UserFoodDto(food.Guid, food.Name, food.NutritionGuid, food.AmountOfUnit, food.Barcode);
        }
    }


}
