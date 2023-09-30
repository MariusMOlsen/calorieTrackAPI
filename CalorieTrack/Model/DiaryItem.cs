using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CalorieTrack.Model
{

    public enum DiaryItemType
    {
        Meal,
        Food,
        Recipe
    }

    public class DiaryItem
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Guid { get; set; }
        public Guid DiaryGuid { get; set; }

        // ALL OF THEESE ARE XOR

        public DiaryItemType ItemType { get; set; }
        public Guid ItemGuid { get; set; }
    }
}
