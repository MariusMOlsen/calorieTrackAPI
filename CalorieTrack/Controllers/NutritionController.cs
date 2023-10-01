using CalorieTrack.Model;
using CalorieTrack.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.AccessControl;

namespace CalorieTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NutritionController : ControllerBase
    {
        private readonly INutritionService _nutritionService;

        public NutritionController(INutritionService nutritionService)
        {
            _nutritionService = nutritionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<NutritionDTO>>> GetAllNutritions()
        {
            List<NutritionDTO> nutritionList = await _nutritionService.GetAllNutrition();
            return Ok(nutritionList);
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<NutritionDTO>> GetSingleNutrition(Guid guid)
        {
            var result = await _nutritionService.GetSingleNutrition(guid);
            if (result == null)
            {
                return NotFound("This nutrition object does not exist.");
            }
            return Ok(result);
        }

        [HttpGet("by-guids")]
        public async Task<ActionResult<List<NutritionDTO>>> GetNutritionListByGuidList([FromQuery] List<Guid> guidList)
        {
            var result = await _nutritionService.GetNutritionListByGuidList(guidList);
            return Ok(result);
        }

        [HttpDelete("{guid}")]
        public async Task<ActionResult<NutritionDTO>> DeleteNutrition(Guid guid)
        {
            var result = await _nutritionService.DeleteNutrition(guid);
            if (result == null)
            {
                return NotFound("Nutritioobject does not exist.");
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<List<NutritionDTO>>> PutNutrition(Nutrition nutrition)
        {
            var result = await _nutritionService.EditNutrition(nutrition);
            if (result == null)
            {
                return NotFound("Nutritioobject does not exist.");
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<NutritionDTO>>> CreateNutrition([FromBody]  Nutrition nutrition)
        {
            try
            {
                // var result = await _nutritionService.AddNutrition(protein, carbohydrates,fat, calories, unitDefinitonGuid);
                var result = await _nutritionService.AddNutrition(nutrition.Protein, nutrition.Carbohydrates, nutrition.Fat, nutrition.Calories, nutrition.UnitDefinitionGuid);
                return Ok(result);

            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }
    }
}
