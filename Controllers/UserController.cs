using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JWTAuthenticationDotNETCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        [HttpGet, Authorize]
        public IEnumerable<string> Get()
        {
            return new string[] { "Rick", "Harry" };
        }
    }
}
