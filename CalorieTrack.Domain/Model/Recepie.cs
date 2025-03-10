﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CalorieTrack.Model.Interfaces;
using static CalorieTrack.Constants.Enums;
using CalorieTrack.Constants;

namespace CalorieTrack.Domain.Model
{
    public class Recepie: INutritionObject
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Guid { get; set; }  
        public string Name { get; set; }

        public Guid NutritionGuid { get; set; }
        public Guid UserGuid { get; set; }
        public InstanceDefinition InstanceDefinition { get; set; }

        public Recepie(string name, Guid UserGuid) {
            this.Name = name;
            this.UserGuid = UserGuid;
            this.NutritionGuid = Guid.Empty;
            this.Guid = new Guid();
            this.InstanceDefinition = Enums.InstanceDefinition.Recepie;
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
