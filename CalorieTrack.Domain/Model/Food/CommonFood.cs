using CalorieTrack.Constants;

namespace CalorieTrack.Domain.Model.Food;

public class CommonFood : Food
{
    public long credibility { get; set; }
    public Enums.InstanceDefinition InstanceDefinition { get; set; }
    
    public CommonFood( string name, Guid nutritionGuid, int amountOfUnit, string barcode) : base(name, nutritionGuid, amountOfUnit, barcode)
    {
        this.credibility = 0;
        this.InstanceDefinition = Enums.InstanceDefinition.CommonFood;
    }
}