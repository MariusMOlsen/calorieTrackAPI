using CalorieTrack.Data;
using CalorieTrack.Model;
using CalorieTrack.Services;
using CalorieTrack.Services.interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CalorieTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitDefinitionController : ControllerBase
    {
        private readonly IUnitDefinitionService _unitDefinitionService;



        public UnitDefinitionController(IUnitDefinitionService unitDefinitionService)
        {
            _unitDefinitionService = unitDefinitionService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UnitDefinitionDTO>>> GetAllUnitDefinitions()
        {
            var result = await _unitDefinitionService.GetUnitDefinitions();
            if( result == null)
            {
                return NotFound("Something went wrong");
            } 
            return Ok(result);
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<UnitDefinitionDTO>> GetSingleUnitDefinition(Guid guid)
        {
            var result = await _unitDefinitionService.GetSingleUnitDefiniton(guid);
            if (result == null)
            {
                return NotFound("This unitdefiniton doesn't exist.");
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<UnitDefinitionDTO>> DeleteUnitDefiniton(Guid guid)
        {
            var result = await _unitDefinitionService.DeleteUnitDefinition(guid);
            return NoContent();
            
        }

        [HttpPost]
        public async Task<ActionResult<List<UnitDefinitionDTO>>> CreateUnitDefinition(string name, int defaultAmount)
        {
            try
            {
               
                var result = await _unitDefinitionService.AddUnitDefition(name, defaultAmount);
                return Ok(result);
            }
            catch(Exception ex) {
                Console.WriteLine(ex.Message);
                return BadRequest();
            }

        }
    }
}
