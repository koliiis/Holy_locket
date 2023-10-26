using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holy_locket.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetDoctorsController : ControllerBase
    {
        public GetDoctorsController() 
        { 
        }

        [HttpGet]
        public IActionResult GetDoctors() 
        {
            try {
                //ToDo: add getting data logic from DoctorsService

                return Ok(/*doctors*/);
            }
            catch(Exception ex) {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
