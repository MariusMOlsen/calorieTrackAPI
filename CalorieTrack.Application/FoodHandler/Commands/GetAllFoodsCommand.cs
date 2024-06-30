using CalorieTrack.Application.DTO;
using CalorieTrack.DTO;
using MediatR;
using ErrorOr;

namespace CalorieTrack.Application.FoodHandler.Commands;

public record GetAllFoodsCommand
(Guid userGuid) :  IRequest<ErrorOr<List<FoodDto>>>;
