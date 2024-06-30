using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Application.DTO;
using CalorieTrack.Application.FoodHandler.Commands;
using CalorieTrack.Domain.Model;
using MediatR;
using ErrorOr;

namespace CalorieTrack.Application.FoodHandler.Queries;


public class GetAllFoodsQueryHandler(
    IFoodRepository foodRepository,

    IUnitOfWork unitOfWork)

    : IRequestHandler<GetAllFoodsQuery, ErrorOr<List<FoodDto>>>
{
    private readonly IFoodRepository _foodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public async Task<ErrorOr<List<FoodDto>>> Handle(GetAllFoodsQuery query, CancellationToken cancellationToken)
    {

        List<Food> foodList = await _foodRepository.GetAll();
        return FoodDto.convertFromEntityListToDTOList(foodList);

    }
}