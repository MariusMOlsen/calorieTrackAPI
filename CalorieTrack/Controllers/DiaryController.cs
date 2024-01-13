using CalorieTrack.DTO;
using CalorieTrack.Services.interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.InteropServices;

namespace CalorieTrack.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class DiaryController : ControllerBase
    {
        private readonly IDiaryService _diaryService;

        public DiaryController(IDiaryService diaryService) { _diaryService= diaryService; }

        [HttpGet]
        public async Task<ActionResult<List<DiaryDTO>>> GetHundredDiares([FromQuery] DateTime dateTime = new DateTime())
        {
           var result = await _diaryService.GetDiaryList(dateTime);
            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
