using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Berkman_Final_DMV.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly JwtAuthenticationManager jwtAuthenticationManager;


        public LoginController(JwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        [AllowAnonymous]
        [HttpPost("Authorize")]
        public IActionResult AuthUser([FromBody] User user)
        {
            var token = jwtAuthenticationManager.Authenticate(//user.title,
                                                              user.username, user.password);
            if (token == null)
            {
                return Unauthorized();
            }
            return Ok(new { Token = token, Message = "Success" });
        }

        [AllowAnonymous]
        [HttpDelete("Logout")]
        public IActionResult Logout()
        {
            jwtAuthenticationManager.RemoveAuthentication(User.Identity.Name);
            return Ok(new { Message = "Logout successful" });
        }

    }
    public class User
    {
        //public String title { get; set; }
        public String username { get; set; }
        public String password { get; set; }
    }
}
