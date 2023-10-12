using CalorieTrack.DTO;
using CalorieTrack.Model;
using CalorieTrack.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;

namespace CalorieTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepieController : ControllerBase
    {
       private readonly IRecepieService _recepieService;
        public RecepieController(IRecepieService recepieService) { _recepieService = recepieService; }

        [HttpPost]
       public async Task<ActionResult<RecepieDTO>>  AddRecepie([FromBody]Recepie recepie)

        {
            Guid userGuid = Guid.Empty;
            var result = _recepieService.AddRecepie(recepie.Name, userGuid);
            if(result == null) {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("{guid}")]
        public async Task<ActionResult<RecepieDTO>> UpdateRecepieNutrition(Guid guid)
        {
            var result = await _recepieService.UpdateRecepieNutrition(guid);
            if(result == null)
            {
                return NotFound();
            }

            return Ok(result); 
        }

        [HttpDelete("{guid}")]
        public async Task<ActionResult<List<RecepieDTO>>> DeleteRecepie(Guid guid)
        {
            var result = await _recepieService.DeleteRecepie(guid);
            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }


        [HttpGet("{guid}")]
        public async Task<ActionResult<List<RecepieDTO>>> GetRecepieList(Guid guid)
        {
            var result = await _recepieService.GetRecepieListByUserGuid(guid);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


    }
}
