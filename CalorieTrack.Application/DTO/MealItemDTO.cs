﻿using CalorieTrack.Domain.Model;
using static CalorieTrack.Constants.Enums;

namespace CalorieTrack.DTO
{
    public class MealItemDTO
    {
        public Guid Guid { get; set; }

        public Guid MealGuid { get; set; }

        public Guid ItemGuid { get; set; }
        public InstanceDefinition InstanceDefinition { get; set; }

        public int Amount { get; set; }
        public MealItemDTO(Guid guid, Guid MealGuid, Guid itemGuid, InstanceDefinition instanceDefinition, int amount)
        {
            this.Guid = guid;
            this.MealGuid = MealGuid;
            this.ItemGuid = itemGuid;
            this.InstanceDefinition = instanceDefinition;
            this.Amount = amount;
        }

        public static List<MealItemDTO> convertFromEntityListToDTOList(List<MealItem> mealList)
        {
            List<MealItemDTO> DTOList = new List<MealItemDTO>();
            foreach (MealItem meal in mealList)
            {
                DTOList.Add(new MealItemDTO(meal.Guid, meal.MealGuid, meal.ItemGuid, meal.InstanceDefinition, meal.Amount));
            }

            return DTOList;
        }

        public static MealItemDTO convertFromEntityToDTO(MealItem meal)
        {
            return new MealItemDTO(meal.Guid, meal.MealGuid, meal.ItemGuid, meal.InstanceDefinition, meal.Amount);
        }
    }
}
