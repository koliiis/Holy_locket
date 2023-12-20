using Holy_locket.BLL.DTO;
using Holy_locket.BLL.Services;
using Holy_locket.BLL.Services.Abstraction;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Holy_locket.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;
        public UserController(IUserService specialityService)
        {
            _userService = specialityService;
        }
        [HttpPost()]
        [Route("login")]
        public async Task<IActionResult> Login(LoginInfoDTO login)
        {
            try
            {
                var tokenInfo = await _userService.Login(login.phone, login.password).ConfigureAwait(false);
                return tokenInfo == null ? Unauthorized() : Ok(tokenInfo);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
