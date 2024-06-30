using CalorieTrack.Application.DTO;
using ErrorOr;
using MediatR;

namespace CalorieTrack.Application.FoodHandler.Queries;

public record GetAllFoodsQuery

    (Guid userGuid) :  IRequest<ErrorOr<List<FoodDto>>>;

