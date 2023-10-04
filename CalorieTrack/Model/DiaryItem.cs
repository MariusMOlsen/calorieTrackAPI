using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using static CalorieTrack.Constants.Enums;

namespace CalorieTrack.Model
{

    
    public class DiaryItem
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Guid { get; set; }
        public Guid DiaryGuid { get; set; }

        // ALL OF THEESE ARE XOR

        public InstanceDefinition InstanceDefinition { get; set; }
        public Guid ItemGuid { get; set; }

    }
}
