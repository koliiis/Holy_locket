using Holy_locket.BLL.DTO;
using Holy_locket.BLL.Services;
using Holy_locket.BLL.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holy_locket.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialityController : ControllerBase
    {
        ISpecialityService _specialityService;
        public SpecialityController(ISpecialityService specialityService)
        {
            _specialityService = specialityService;
        }
        [HttpGet]
        public async Task<IActionResult> GetSpecialities()
        {
            try
            {
                var specialities = await _specialityService.GetAll().ConfigureAwait(false);
                return Ok(specialities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpecialtyByID(int id)
        {
            try
            {
                var patient = await _specialityService.GetSpecialityById(id).ConfigureAwait(false);
                return Ok(patient);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost]
        public async Task<IActionResult> PostSpetiality(SpecialityDTO speciality)
        {
            try
            {
                await _specialityService.CreateSpeciality(speciality).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPut]
        public async Task<IActionResult> PutSpeciality(SpecialityDTO speciality)
        {
            try
            {
                await _specialityService.UpdateSpeciality(speciality).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteSpeciality(int id)
        {
            try
            {
                await _specialityService.DeleteSpeciality(id).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}