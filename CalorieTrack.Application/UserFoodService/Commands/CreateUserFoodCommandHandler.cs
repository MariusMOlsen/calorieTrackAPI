using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Application.DTO;
using ErrorOr;
using MediatR;
using CalorieTrack.Domain.Model;
using CalorieTrack.Domain.Model.Food;

namespace CalorieTrack.Application.FoodHandler.Commands;



public class CreateUserFoodCommandHandler(
    IUserFoodRepository foodRepository,
    IUnitDefinitionRepository unitDefinitionRepository,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork)

    : IRequestHandler<CreateUserFoodCommand, ErrorOr<Success>>
{
    private readonly IUserFoodRepository _userFoodRepository;
    private readonly IUnitDefinitionRepository _unitDefinitionRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public async Task<ErrorOr<Success>> Handle(CreateUserFoodCommand command, CancellationToken cancellationToken)
    {
        User user = await _userRepository.GetByIdAsync(command.UserGuid);
        if (user is null)
        {
            return Error.NotFound("User not found");
        }

        var food = command.Food;
        UnitDefinition unitDefinition = command.UnitDefinition;
        Nutrition nutrition = command.Nutrition;
        int servingsPrContainer = command.servingsPrContainer;
        int defaultAmount = unitDefinition.defaultAmount;

        // Calculate the nutrition values for a UnitDefinition of 1
        double caloriesPerUnit = nutrition.Calories / (double)defaultAmount;
        double proteinPerUnit = nutrition.Protein / (double)defaultAmount;
        double carbsPerUnit = nutrition.Carbohydrates / (double)defaultAmount;
        double fatPerUnit = nutrition.Fat / (double)defaultAmount;
        
        Nutrition newNutrition = new Nutrition(proteinPerUnit,  carbsPerUnit, fatPerUnit,caloriesPerUnit);

        // Create the UnitDefinition objects
        UnitDefinition unitDefinition1 = new UnitDefinition(unitDefinition.Name, 1,newNutrition);
        UnitDefinition unitDefinition100 = new UnitDefinition(unitDefinition.Name, 100,newNutrition);
        UnitDefinition unitDefinitonContainer = new UnitDefinition("Pr container" + "(" +defaultAmount/servingsPrContainer+" "+unitDefinition.Name +")",defaultAmount/servingsPrContainer , newNutrition);
        List<UnitDefinition> newUnitDefinitions = new List<UnitDefinition> { unitDefinition1, unitDefinition100, unitDefinitonContainer };
        
        if (defaultAmount != 1 && defaultAmount != 100)
        {
        UnitDefinition unitDefinitionDefault = new UnitDefinition(unitDefinition.Name, defaultAmount,newNutrition);
        newUnitDefinitions.Add(unitDefinitionDefault);
        }
        
        UserFood userFood = new UserFood(user, food.Name, food.NutritionGuid, food.AmountOfUnit, food.Barcode);

        foreach (UnitDefinition newUnitDefinition in newUnitDefinitions)
        {
            _unitDefinitionRepository.Add(newUnitDefinition);
        }
        
        _userFoodRepository.Add(userFood);
        await _unitOfWork.CommitChangesAsync();
        
        return Result.Success;

    }
}