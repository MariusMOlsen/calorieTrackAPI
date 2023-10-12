using CalorieTrack.Constants;
using CalorieTrack.Model;
using System;
using static CalorieTrack.Constants.Enums;

namespace CalorieTrack.DTO
{
    public class RecepieDTO
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }

        public Guid NutritionGuid { get; set; }
        public Guid UserGuid { get; set; }
        public InstanceDefinition InstanceDefinition { get; set; }

        public RecepieDTO(Guid guid, string name, Guid nutritionGuid, Guid UserGuid)
        {
            this.Name = name;
            this.UserGuid = UserGuid;
            this.NutritionGuid = nutritionGuid;
            this.Guid = guid;
            this.InstanceDefinition = Enums.InstanceDefinition.Recepie;
        }

        public static List<RecepieDTO> convertFromEntityListToDTOList(List<Recepie> recepieList)
        {
            List<RecepieDTO> DTOList = new List<RecepieDTO>();
            foreach (Recepie recepie in recepieList)
            {

                DTOList.Add(new RecepieDTO(recepie.Guid, recepie.Name, recepie.NutritionGuid, recepie.UserGuid));

            }
            return DTOList;
        }

        public static RecepieDTO convertFromEntityToDTO(Recepie recepie)
        {
            return new RecepieDTO(recepie.Guid, recepie.Name, recepie.NutritionGuid, recepie.UserGuid);

        }

    }
}
