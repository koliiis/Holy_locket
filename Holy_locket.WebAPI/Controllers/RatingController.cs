using Holy_locket.BLL.DTO;
using Holy_locket.BLL.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holy_locket.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        IRatingService _ratingService;
        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllRatings()
        {
            try
            {
                var specialities = await _ratingService.GetAll().ConfigureAwait(false);
                return Ok(specialities);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpGet]
        [Route("Average")]
        public async Task<IActionResult> GetCalculatedRating(int doctorId)
        {
            try
            {
                var rating = await _ratingService.GetCalculated(doctorId);
                return Ok(rating);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpPost("{patientToken}")]
        public async Task<IActionResult> AddRating(RatingDTO rating, string patientToken)
        {
            try
            {
                await _ratingService.AddRating(rating, patientToken).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> PutRating(RatingDTO rating)
        {
            try
            {
                await _ratingService.UpdateRating(rating).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteRating(int id)
        {
            try
            {
                await _ratingService.DeleteRating(id).ConfigureAwait(false);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
