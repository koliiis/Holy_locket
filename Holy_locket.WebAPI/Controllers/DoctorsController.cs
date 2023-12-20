using Holy_locket.BLL.DTO;
using Holy_locket.BLL.Services.Abstraction;
using Holy_locket.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Text.Json;

namespace Holy_locket.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        IDoctorService _doctorService;
        ISpecialityService _specialityService;
        ITimeSlotsService _timeSlotsService;
        public DoctorsController(IDoctorService doctorService, ISpecialityService specialityService, ITimeSlotsService timeSlotsService)
        {
            _doctorService = doctorService;
            _specialityService = specialityService;
            _timeSlotsService = timeSlotsService;
        }
        [HttpGet]
        public async Task<IActionResult> GetDoctors(int minimumExpirience, string? specialityName, string? gender, int rating)
        {
            try
            {
                var list = await _doctorService.GetFiltered(minimumExpirience, specialityName, gender, rating);

                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("DoctorsPage")]
        public async Task<IActionResult> GetDoctorsPage(int minimumExpirience, string? specialityName, string? gender, int rating)
        {
            try
            {
                var doctors = await _doctorService.GetFiltered(minimumExpirience, specialityName, gender, rating);
                var specialityNames = (await _specialityService.GetAll()).Select(x => x.Name).ToList();
                var result = new
                {
                    Doctors = doctors,
                    SpecialityNames = specialityNames
                };
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("UserDoctor/{doctorToken}")]
        public async Task<IActionResult> GetDoctor(string doctorToken)
        {
            try
            {
                var doctor = await _doctorService.GetDoctor(doctorToken).ConfigureAwait(false);
                return Ok(doctor);
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
        public async Task<IActionResult> PostDoctors(RegisterDoctorsDTO register)
        {
            try
            {
                var tokenInfo = await _doctorService.AddDoctor(register.Doctor).ConfigureAwait(false);
                await _timeSlotsService.PostTimeSlots(register.Times, tokenInfo.Token);
                return Ok(tokenInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> PutDoctors(DoctorDTO doctor)
        {
            try
            {
                await _doctorService.UpdateDoctor(doctor).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(ex.HResult, ex.Message);
            }

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDoctors(int id)
        {
            try
            {
                await _doctorService.DeleteDoctor(id).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
