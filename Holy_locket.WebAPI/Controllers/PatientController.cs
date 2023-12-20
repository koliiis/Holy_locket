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
        [HttpGet("UserPatient/{patientToken}")]
        public async Task<IActionResult> GetPatient(string patientToken)
        {
            try
            {
                var patient = await _patientService.GetPatientById(patientToken).ConfigureAwait(false);
                return Ok(patient);
            }
            catch (UnauthorizedAccessException)
            {
                return StatusCode(401, "Unauthorized");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostPatient(PatientDTO patient)
        {
            try
            {
                var tokenInfo = await _patientService.CreatePatient(patient).ConfigureAwait(false);
                return Ok(tokenInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
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
            catch (Exception ex) 
            { 
                return StatusCode(500, ex.Message); 
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
            catch (Exception ex) 
            { 
                return StatusCode(500, ex.Message); 
            }
        }
    }
}
