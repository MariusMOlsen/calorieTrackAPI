using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Data;
using CalorieTrack.Domain.Model.Food;
using Microsoft.EntityFrameworkCore;

namespace CalorieTrack.Infrastructure.CommonFoodRepo;
  

public class CommonFoodRepository : ICommonFoodRepository
{
    private readonly DataContext _context;
    public CommonFoodRepository(DataContext context)
    {
        _context = context;
    }

    public void Add(CommonFood food)
    {
        _context.Add(food); 
    }

    public async Task<CommonFood?> Find(Guid id)
    {
        return await _context.CommonFoods.FindAsync(id);
    }

    public async Task<List<CommonFood>> GetAll()
    {
        return await _context.CommonFoods.ToListAsync();
    }
    public void Delete(CommonFood food)
    {
        _context.CommonFoods.Remove(food);
    }
        
    public async Task<List<CommonFood>?> GetFoodListByGuidList(List<Guid> guidList)
    {
        List<CommonFood> foodList = await _context.CommonFoods.Where(food => guidList.Contains(food.Guid)).ToListAsync();
        return foodList;
    }
}