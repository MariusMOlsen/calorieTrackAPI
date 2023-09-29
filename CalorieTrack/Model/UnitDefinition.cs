using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using CalorieTrack.Interfaces;

namespace CalorieTrack.Model
{
    public class UnitDefinition
    {
        public int Id { get; set; }
        
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
