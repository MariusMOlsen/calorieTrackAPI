using CalorieTrack.Constants;

namespace CalorieTrack.Domain.Model.Food;

public class UserFood: Food
{
    Enums.InstanceDefinition InstanceDefinition { get; set; }
    public User? User { get; private set; }
    public Guid UserId { get; private set; }

    public UserFood(){}
    public UserFood( User user,string name, Guid nutritionGuid, int amountOfUnit, string barcode) : base(name, nutritionGuid, amountOfUnit, barcode)
    {
        
        this.InstanceDefinition = Enums.InstanceDefinition.UserFood;
        SetUser( user);
    }
    
    private void SetUser(User user){
        this.User = user;
        this.UserId = user.Guid;
    }
}