using Holy_locket.BLL.DTO;
using Holy_locket.BLL.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holy_locket.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HospitalController : ControllerBase
    {
        IHospitalService _hospitalService;
        public HospitalController(IHospitalService hospitalService)
        {
            _hospitalService = hospitalService;
        }
        [HttpGet]
        public async Task<IActionResult> GetHospitals()
        {
            try
            {
                var hospitals = await _hospitalService.GetAll().ConfigureAwait(false);
                return Ok(hospitals);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientByID(int id)
        {
            try
            {
                var patient = await _hospitalService.GetHospitalById(id);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostPatient(HospitalDTO hospital)
        {
            try
            {
                await _hospitalService.CreateHospital(hospital);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPut]
        public async Task<IActionResult> PutPatient(HospitalDTO hospital)
        {
            try
            {
                await _hospitalService.UpdateHospital(hospital);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteHospital(int id)
        {
            try
            {
                await _hospitalService.DeleteHospital(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
