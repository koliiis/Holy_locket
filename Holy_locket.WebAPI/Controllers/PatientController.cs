using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Holy_locket.BLL.Services;
using Holy_locket.BLL.Services.Abstraction;
using Holy_locket.DAL.Models;
using Holy_locket.BLL.DTO;

namespace Holy_locket.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientByID(int id) 
        {
            try
            {
                var patient =await _patientService.GetPatientById(id);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet()]
        [Route("login")]
        public async Task<IActionResult> Login(string phone, string password)
        {
            try
            {
                return Ok(_patientService.CheckLogin(phone, password));
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostPatient(PatientDTO patient)
        {
            try
            {
               await _patientService.CreatePatient(patient);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPut]
        public async Task<IActionResult> PutPatient(PatientDTO patient)
        {
            try
            {
               await _patientService.UpdatePatient(patient);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeletePatient(int id)
        {
            try
            {
                await _patientService.DeletePatient(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
