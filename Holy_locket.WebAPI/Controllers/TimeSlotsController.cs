using Holy_locket.BLL.DTO;
using Holy_locket.BLL.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holy_locket.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeSlotsController : ControllerBase
    {
        ITimeSlotsService _timeSlotsService;
        public TimeSlotsController(ITimeSlotsService timeSlotsService) 
        {
            _timeSlotsService = timeSlotsService;
        }
        [HttpGet("{patientToken}")]
        public async Task<IActionResult> GetTimeSlots(int doctorId, string patientToken)
        {
            try
            {
                var list = await _timeSlotsService.GetTimeSlots(doctorId, patientToken).ConfigureAwait(false);
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("{doctorToken}")]
        public async Task<IActionResult> PostTimeSlots(List<List<string>> times, string doctorToken)
        {
            try
            {
                await _timeSlotsService.PostTimeSlots(times, doctorToken).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
