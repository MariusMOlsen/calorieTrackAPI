using CalorieTrack.Domain.Model;
using CalorieTrack.DTO;
using CalorieTrack.Model;
using CalorieTrack.Services.interfaces;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;

namespace CalorieTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ControllerBase

    {
        private readonly IFoodService _foodService;

        public FoodController(IFoodService foodService) { _foodService = foodService; }

        [HttpPost]
        public async Task<ActionResult<List<FoodDTO>>> AddFood([FromBody] Food food)
        {

            try
            {
                var result = await _foodService.AddFood(food);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<FoodDTO>>> EditFood([FromBody] Food food)
        {
            try
            {
                var result = await _foodService.EditFood(food);
                if(result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{guid}")]
        public async Task<ActionResult<List<FoodDTO>>> DeleteFood(Guid guid)
        {
            try
            {
                var result = await _foodService.DeleteFood(guid);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Authorize] 
        public async Task<ActionResult<List<FoodDTO>>> GetAllFoods()
        {
            try
            {
                var result = await _foodService.GetAllFoods();
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{guid}")]
        public async Task<ActionResult<List<FoodDTO>>> GetSingleFood(Guid guid)
        {
            try
            {
                var result = await _foodService.GetSingleFood(guid);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
