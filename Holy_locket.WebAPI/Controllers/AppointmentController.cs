using Holy_locket.BLL.DTO;
using Holy_locket.BLL.Services;
using Holy_locket.BLL.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holy_locket.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        IAppointmentService _appointmentService;
        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAppointments()
        {
            try
            {
                var appointments = await _appointmentService.GetAllAppointments().ConfigureAwait(false);
                return Ok(appointments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentByID(int id)
        {
            try
            {
                var hospital = await _appointmentService.GetAppointmentById(id);
                return Ok(hospital);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet()]
        [Route("InfoPatient")]
        public async Task<IActionResult> GetInfo(int id)
        {
            try
            {
                return Ok(await _appointmentService.GetAppointmentInfo(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet()]
        [Route("TimeSlots")]
        public async Task<IActionResult> GetTimeAppointmentsSlots()
        {
            try
            {
                return Ok(await _appointmentService.GetTimeSlots());
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostAppointment(AppointmentDTO appointment)
        {
            try
            {
                await _appointmentService.AddAppointment(appointment);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPut]
        public async Task<IActionResult> PutAppointment(AppointmentDTO appointment)
        {
            try
            {
                await _appointmentService.UpdateAppointment(appointment);
                return Ok();
            }
            catch (Exception )
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            try
            {
                await _appointmentService.DeleteAppointment(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
