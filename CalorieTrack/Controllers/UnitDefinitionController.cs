using CalorieTrack.Data;
using CalorieTrack.Interfaces.Services;
using CalorieTrack.Model;
using CalorieTrack.Services;
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
        public async Task<ActionResult<List<UnitDefinition>>> GetAllUnitDefinitions()
        {
            var result = await _unitDefinitionService.GetUnitDefinitions();
            if( result == null)
            {
                return NotFound("Something went wrong");
            } 
            return Ok(result);
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<UnitDefinition>> GetSingleUnitDefinition(Guid guid)
        {
            var result = await _unitDefinitionService.GetSingleUnitDefiniton(guid);
            if (result == null)
            {
                return NotFound("This unitdefiniton doesn't exist.");
            }
            return Ok(result);
        }

        [HttpDelete]
        public async Task<ActionResult<UnitDefinition>> DeleteUnitDefiniton(Guid guid)
        {
            var result = await _unitDefinitionService.DeleteUnitDefinition(guid);
            return NoContent();
            
        }

        [HttpPost]
        public async Task<ActionResult<List<UnitDefinition>>> CreateUnitDefinition(string name, int defaultAmount)
        {
            try
            {
               
                var result = await _unitDefinitionService.AddUnitDefition(name, defaultAmount);
                return Ok(result);
            }
            catch(Exception ex) {
                return BadRequest();
            }

        }
    }
}
