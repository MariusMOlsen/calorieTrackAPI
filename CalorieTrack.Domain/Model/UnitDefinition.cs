using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace CalorieTrack.Domain.Model
{
    public class UnitDefinition
    {
        
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid Guid { get; set; } 

        public string Name { get; set; }
        public int defaultAmount { get; set; }

       public UnitDefinition(string Name, int defaultAmount) {
            this.Name = Name;
            this.defaultAmount = defaultAmount;
            this.Guid =  Guid.NewGuid();
        }

    }
}
