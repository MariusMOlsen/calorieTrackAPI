using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Application.DTO;
using ErrorOr;
using MediatR;
using CalorieTrack.Domain.Model;

namespace CalorieTrack.Application.FoodHandler.Commands;


public class GetAllFoodsCommandHandler(
    IFoodRepository foodRepository,

    IUnitOfWork unitOfWork)

    : IRequestHandler<GetAllFoodsCommand, ErrorOr<List<FoodDto>>>
{
    private readonly IFoodRepository _foodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public async Task<ErrorOr<List<FoodDto>>> Handle(GetAllFoodsCommand command, CancellationToken cancellationToken)
    {

        List<Food> foodList = await _foodRepository.GetAll();
        return FoodDto.convertFromEntityListToDTOList(foodList);

    }
}