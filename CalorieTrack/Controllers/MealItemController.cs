using CalorieTrack.DTO;
using CalorieTrack.Services;
using CalorieTrack.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using static CalorieTrack.Constants.Enums;

namespace CalorieTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealItemController : Controller


    {
        private readonly MealItemService _mealItemService;

        public MealItemController(MealItemService mealItemService) { _mealItemService = mealItemService; }

        [HttpPost]

        public async Task<ActionResult<List<MealItemDTO>>> AddMealItem(Guid mealGuid, Guid itemGuid,int amount, InstanceDefinition instanceDefinition)
        {
            try
            {
                var result = await _mealItemService.AddMealItem(mealGuid, itemGuid, amount, instanceDefinition);
                if (result == null)
                {
                    return BadRequest();
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("by-meal-guid/{guid}")]
        public async Task<ActionResult<List<MealItemDTO>>> GetMealListByMealGuid(Guid guid)
        {
            var result = await _mealItemService.GetMealItemListByMealGuid(guid);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet]
        [Route("{guid}")]
        public async Task<ActionResult<MealItemDTO>> GetMealItemByGuid(Guid guid)
        {
            var result = await _mealItemService.GetSingleMealItemByGuid(guid);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);

        }

        [HttpDelete]
        [Route("{guid}")]
        public async Task<ActionResult<List<MealItemDTO>>> DeleteMealItem(Guid guid)
        {
            var result = await _mealItemService.DeleteMealItem(guid);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
