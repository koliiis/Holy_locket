using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Holy_locket.BLL.Services;
using Holy_locket.BLL.Services.Abstraction;
using Holy_locket.DAL.Models;
using Holy_locket.BLL.DTO;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Holy_locket.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        IPatientService _patientService;
        IConfiguration _config;
        public PatientController(IPatientService patientService, IConfiguration config)
        {
            _patientService = patientService;
            _config = config;
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPatientByID(int id)
        {
            try
            {
                var patient = await _patientService.GetPatientById(id).ConfigureAwait(false);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost()]
        [Route("login")]
        public async Task<IActionResult> Login(string phone, string password)
        {
            try
            {
                var result = await _patientService.CheckLogin(phone, password).ConfigureAwait(false);
                return result == null ? Unauthorized() : Ok(result);
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
                await _patientService.CreatePatient(patient).ConfigureAwait(false);
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
                await _patientService.UpdatePatient(patient).ConfigureAwait(false);
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
                await _patientService.DeletePatient(id).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
