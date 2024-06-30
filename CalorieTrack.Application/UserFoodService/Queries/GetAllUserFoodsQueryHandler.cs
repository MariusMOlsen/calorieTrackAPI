using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Application.DTO;
using CalorieTrack.Application.FoodHandler.Queries;
using CalorieTrack.Domain.Model.Food;
using ErrorOr;
using MediatR;

namespace CalorieTrack.Application.UserFoodService.Queries;


public class GetAllUserFoodsQueryHandler(
    IUserFoodRepository foodRepository,
    IUnitOfWork unitOfWork)

    : IRequestHandler<GetAllUserFoodsQuery, ErrorOr<List<UserFoodDto>>>
{
    private readonly IUserFoodRepository _userFoodRepository;
    private readonly IUnitOfWork _unitOfWork;

    public async Task<ErrorOr<List<UserFoodDto>>> Handle(GetAllUserFoodsQuery query, CancellationToken cancellationToken)
    {
        List<UserFood> foodList = await _userFoodRepository.GetAll();
        return UserFoodDto.convertFromEntityListToDTOList(foodList);

    }
}