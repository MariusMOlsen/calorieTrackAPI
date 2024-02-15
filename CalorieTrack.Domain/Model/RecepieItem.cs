using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CalorieTrack.Domain.Model
{
    public class RecepieItem
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Guid { get; set; }

        public Guid RecepieGuid { get; set; }
        public Guid FoodGuid { get; set; }
        public int Amount { get; set; }

        public RecepieItem (Guid recepieGuid, Guid foodGuid, int amount)
        {
            this.Guid = new Guid();
            this.FoodGuid = foodGuid;
            this.RecepieGuid= recepieGuid;
            this.Amount = amount;
        }

    }
}
