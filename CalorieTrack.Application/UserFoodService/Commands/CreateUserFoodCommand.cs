using CalorieTrack.Application.DTO;
using CalorieTrack.Domain.Model;
using CalorieTrack.Domain.Model.Food;
using CalorieTrack.DTO;
using MediatR;
using ErrorOr;

namespace CalorieTrack.Application.FoodHandler.Commands;

public record CreateUserFoodCommand
(Guid UserGuid, Food Food, Nutrition Nutrition, UnitDefinition UnitDefinition, int servingsPrContainer) :  IRequest<ErrorOr<Success>>;
