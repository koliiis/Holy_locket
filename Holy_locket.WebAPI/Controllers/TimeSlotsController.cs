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
        [HttpGet]
        public async Task<IActionResult> GetDoctors(int doctorId)
        {
            //try
            //{
                var list = await _timeSlotsService.GetTimeSlots(doctorId).ConfigureAwait(false);
                return Ok(list);
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, ex.Message);
            //}
        }
        [HttpPost]
        public async Task<IActionResult> PostDoctors(List<List<string>> times, int doctorId)
        {
            //try
            //{
                await _timeSlotsService.PostTimeSlots(times, doctorId).ConfigureAwait(false);
                return Ok();
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, ex.Message);
            //}
        }
    }
}
