using CalorieTrack.Domain.Model;
using CalorieTrack.DTO;
using CalorieTrack.Model;
using CalorieTrack.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;

namespace CalorieTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecepieItemController : ControllerBase
    {
        private readonly IRecepieItemService _recepieItemService;

        public RecepieItemController(IRecepieItemService recepieItemService)
        {
            _recepieItemService = recepieItemService;
        }

        [HttpPost]
        public async Task<ActionResult<RecepieItemDTO>> AddRecepieItem([FromBody] RecepieItem recepieItem)
        {
            var result = await _recepieItemService.AddRecepieItem(recepieItem);
            if (result == null)
            {
                return BadRequest();
            }
            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<RecepieItemDTO>> EditRecepieItem([FromBody] RecepieItem recepieItem)
        {
            var result = await _recepieItemService.EditRecepieItem(recepieItem);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpDelete("{guid}")]
        public async Task<ActionResult<RecepieItemDTO>> DeleteRecepieItem(Guid guid)
        {
            var result = await _recepieItemService.DeleteRecepieItem(guid);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<List<RecepieItemDTO>>> GetRecepieItemListByRecepieGuid(Guid guid)
        {

            var result = await _recepieItemService.GetAllRecepieItemsByRecepieGuid(guid);
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}
