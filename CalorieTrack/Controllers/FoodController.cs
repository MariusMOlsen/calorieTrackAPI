using CalorieTrack.Domain.Model;
using CalorieTrack.DTO;
using CalorieTrack.Model;
using CalorieTrack.Services.interfaces;
using Microsoft.AspNetCore.Connections.Features;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Application.DTO;
using CalorieTrack.Application.FoodHandler.Commands;
using CalorieTrack.Application.FoodHandler.Queries;
using CalorieTrack.Domain.Model.Food;
using Castle.Core.Internal;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace CalorieTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FoodController : ApiController

    {
        private readonly ICurrentUserProvider _currentUserProvider;
        private readonly IUserFoodService _foodService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private  readonly ISender _mediator;


        public FoodController(ISender mediator, IUserFoodService foodService, IHttpContextAccessor httpContextAccessor,  ICurrentUserProvider currentUserProvider)
        {
            _foodService = foodService; 
            _currentUserProvider = currentUserProvider;
            _httpContextAccessor = httpContextAccessor;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddFood([FromBody] CreateUserFoodCommand request)
        {
            
            Debug.WriteLine(request.Food.Name);
            var command = new CreateUserFoodCommand(_currentUserProvider.GetCurrentUser().Value.Id, request.Food, request.Nutrition, request.UnitDefinition, request.servingsPrContainer);
            // var command = new CreateUserFoodCommand(_currentUserProvider.GetCurrentUser().Id, food, nutrition, unitDefinition, servingsPrContainer);
            var createUserFoodResult = await _mediator.Send(command);
            
            if(createUserFoodResult.Errors.Any())
            {
                return Problem(createUserFoodResult.Errors);
            }
        
            return Created();
        
        }

        [HttpPut]
        public async Task<ActionResult<List<UserFoodDto>>> EditFood([FromBody] Food food)
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
        public async Task<ActionResult<List<UserFoodDto>>> DeleteFood(Guid guid)
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
        [AuthorizeAttribute]
        public async Task<ActionResult<List<UserFoodDto>>> GetAllFoods()
        {
            var test = _httpContextAccessor.HttpContext;
           var testUer =  _currentUserProvider.GetCurrentUser();
           try
           {
               var test5 = testUer.Value;
               var query = new GetAllUserFoodsQuery(testUer.Value.Id);
               var result = await _mediator.Send(query);
               return Ok(result.Value);

           }
           catch (Exception e)
           {
               Debug.WriteLine(e.Message);
               return NotFound(e.Message); 
           }
      
           
       
           
        }
        
        [HttpGet("{guid}")]
        public async Task<ActionResult<List<UserFoodDto>>> GetSingleFood(Guid guid)
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
