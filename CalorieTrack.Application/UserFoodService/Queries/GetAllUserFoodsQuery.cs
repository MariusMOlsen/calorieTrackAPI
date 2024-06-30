using CalorieTrack.Application.DTO;
using ErrorOr;
using MediatR;

namespace CalorieTrack.Application.FoodHandler.Queries;

public record GetAllUserFoodsQuery

    (Guid userGuid) :  IRequest<ErrorOr<List<UserFoodDto>>>;

