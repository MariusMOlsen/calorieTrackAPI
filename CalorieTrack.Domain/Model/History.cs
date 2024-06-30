using CalorieTrack.Constants;
using CalorieTrack.Domain.Model.Common;

namespace CalorieTrack.Domain.Model;

public class History: Entity
{
    public Guid ItemGuid { get; private set; }
    public DateTime LastAdded { get; private set; }
    public Enums.InstanceDefinition InstanceDefinition { get; private set; }
    
    public History(Guid itemGuid, Enums.InstanceDefinition instanceDefinition):base(new Guid())
    {
          this.ItemGuid = itemGuid;
          this.InstanceDefinition = instanceDefinition;
          this.LastAdded = DateTime.Now;    
    }
    
    public void UpdateLastAdded(){
        this.LastAdded = DateTime.Now;
    }
}