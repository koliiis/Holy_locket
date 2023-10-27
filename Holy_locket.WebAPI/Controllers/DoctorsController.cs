using Holy_locket.WebAPI.TestModels;
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
    //[Route("Doctors")]
    public class DoctorsController : ControllerBase
    {
        List<Doctor> doctors = new List<Doctor>();


        public DoctorsController()
        {

            string fileName = "Doctors.json";


            string jsonString;
            using (StreamReader reader = new StreamReader(fileName))
            {
                jsonString = reader.ReadToEnd();
            }


            doctors = JsonSerializer.Deserialize<List<Doctor>>(jsonString);


            for (int id = 0; id < doctors.Count; id++)
            {
                doctors[id].Id = id;
            }



        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            try {
                string fileName = "Doctors.json";
                string jsonString = JsonSerializer.Serialize(doctors);
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.Write(jsonString);
                }
                //ToDo: add getting data logic from DoctorsService

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
                //ToDo: add getting data logic from DoctorsService

                return Ok(doctors[id]);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost]
        public IActionResult PostDoctors(Doctor doc)
        {
            try
            {
                doctors.Add(doc);
                string fileName = "Doctors.json";
                string jsonString = JsonSerializer.Serialize(doctors);
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.Write(jsonString);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
            
        }
        [HttpPut("{id}")]
        public IActionResult PutDoctors(Doctor doc, int id)
        {
            try
            {
                doctors[id] = doc;
                string fileName = "Doctors.json";
                string jsonString = JsonSerializer.Serialize(doctors);
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.Write(jsonString);
                }
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
                doctors.RemoveAt(id);
                string fileName = "Doctors.json";
                string jsonString = JsonSerializer.Serialize(doctors);
                using (StreamWriter writer = new StreamWriter(fileName))
                {
                    writer.Write(jsonString);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
           
            
        }
    }
}
