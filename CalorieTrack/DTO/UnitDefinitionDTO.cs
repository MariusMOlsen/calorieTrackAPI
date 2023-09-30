using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CalorieTrack.Interfaces;

namespace CalorieTrack.Model
{
    public class UnitDefinitionDTO
    {
      
        public Guid Guid { get; set; } 

        public string Name { get; set; }
        public int DefaultAmount { get; set; }

        public UnitDefinitionDTO(Guid guid, string name, int defaultAmount)
        {
            this.Guid = guid;
            this.Name = name;
            this.DefaultAmount = defaultAmount; 
        }

        public static List<UnitDefinitionDTO> convertFromEntityListToDTOList (List<UnitDefinition> entityList)
        {
            List<UnitDefinitionDTO> UnitDefinitionDTO = new List<UnitDefinitionDTO>();
            foreach (UnitDefinition unitDefinition in entityList)
            {
                
                    UnitDefinitionDTO.Add(new UnitDefinitionDTO(unitDefinition.Guid, unitDefinition.Name, unitDefinition.defaultAmount));

            }
            return UnitDefinitionDTO;
        }

        public static UnitDefinitionDTO convertFromEntityToDTO(UnitDefinition unitDefinition)
        {
            return new UnitDefinitionDTO(unitDefinition.Guid, unitDefinition.Name, unitDefinition.defaultAmount);
        }
    }
}
