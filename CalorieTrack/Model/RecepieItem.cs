using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CalorieTrack.Model
{
    public class RecepieItem
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Guid { get; set; }

        public Guid RecepieGuid { get; set; }
        public Guid FoodGuid { get; set; }

        public RecepieItem (Guid recepieGuid, Guid foodGuid)
        {
            this.Guid = new Guid();
            this.FoodGuid = foodGuid;
            this.RecepieGuid= recepieGuid;
        }

    }
}
