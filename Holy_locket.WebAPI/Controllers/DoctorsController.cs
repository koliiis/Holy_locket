
using Holy_locket.BLL.Services;
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


        public DoctorsController(IDoctorService doctorService)
        {
            _doctorService= doctorService;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            try {
                var doctors = _doctorService.GetAll();
                return Ok(doctors);
            }
            catch (Exception ex) {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetDoctorsId(int id)
        {
            try
            {
                
                var doctor = _doctorService.GetById(id);
                return Ok(doctor);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost]
        public IActionResult PostDoctors(Doctors doctor)
        {
            try
            {
                _doctorService.Add(doctor);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
            
        }
        [HttpPut("{id}")]
        public IActionResult PutDoctors(Doctors doctor, int id)
        {
            try
            {
                _doctorService.Update(doctor, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
            
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteDoctors(int id)
        {
            try
            {   
                _doctorService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
           
            
        }
    }
}
