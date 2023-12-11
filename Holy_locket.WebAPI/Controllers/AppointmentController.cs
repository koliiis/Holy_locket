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
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentByID(int id)
        {
            try
            {
                var hospital = await _appointmentService.GetAppointmentById(id).ConfigureAwait(false);
                return Ok(hospital);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet()]
        [Route("InfoPatient")]
        public async Task<IActionResult> GetInfo(int id)
        {
            try
            {
                return Ok(await _appointmentService.GetAppointmentInfo(id).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet()]
        [Route("TimeSlots")]
        public async Task<IActionResult> GetTimeAppointmentsSlots(int DoctorId)
        {
            //try
            //{
                return Ok(await _appointmentService.GetTimeSlots(DoctorId).ConfigureAwait(false));
            //}
            //catch (Exception ex)
            //{
            //    return StatusCode(500, ex.Message);
            //}
        }
        [HttpPost]
        public async Task<IActionResult> PostAppointment(AppointmentDTO appointment)
        {
            try
            {
                await _appointmentService.AddAppointment(appointment).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> PutAppointment(AppointmentDTO appointment)
        {
            try
            {
                await _appointmentService.UpdateAppointment(appointment).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAppointment(int id)
        {
            try
            {
                await _appointmentService.DeleteAppointment(id).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete]
        [Route("SoftDelete")]
        public async Task<IActionResult> SoftDeleteAppointment(int id)
        {
            try
            {
                await _appointmentService.SoftDeleteAppointment(id).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
