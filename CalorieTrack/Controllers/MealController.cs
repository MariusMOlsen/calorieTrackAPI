using CalorieTrack.DTO;
using CalorieTrack.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CalorieTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealController : Controller
    {

        private readonly IMealService _mealService;

        public MealController(IMealService mealService) { _mealService = mealService; }

        [HttpPost]
        public async Task<ActionResult<List<MealDTO>>> AddMeal([FromBody] string name)
        {
            try
            {
                Guid userGuid = Guid.Empty;
                MealDTO meal = await _mealService.AddMeal(name, userGuid);
                return Ok(meal);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<MealDTO>>> ChangeName([FromBody]  Guid guid, string name)
        {
            try
            {
                List<MealDTO> meal = await _mealService.ChangeName(guid, name);
                if (meal == null)
                {
                    return NotFound();
                }
                return Ok(meal);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete]
        [Route("{guid}")]
        public async Task<ActionResult<List<MealDTO>>> DeleteMeal( Guid guid)
        {

            try
            {
                List<MealDTO> meal = await _mealService.DeleteMeal(guid);
                if (meal == null)
                {
                    return NotFound();
                }
                return Ok(meal);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpGet]
        [Route("{guid}")]
        public async Task<ActionResult<MealDTO>> GetSingleMeal(Guid guid)
        {

            try
            {
                MealDTO meal = await _mealService.GetSingleMeal(guid);
                if (meal == null)
                {
                    return NotFound();
                }
                return Ok(meal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("by-user/{guid}")]
        public async Task<ActionResult<List<MealDTO>>> GetMealsByUserGuid(Guid userGuid)
        {

            try
            {
                List<MealDTO> meal = await _mealService.GetAllMealsByUser(userGuid);
                if (meal == null)
                {
                    return NotFound();
                }
                return Ok(meal);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}

