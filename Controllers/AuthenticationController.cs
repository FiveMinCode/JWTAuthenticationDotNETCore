using JWTAuthenticationDotNETCore.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTAuthenticationDotNETCore.Controllers
{
    public class AuthenticationController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginUser user)
        {
            if (user.UserName== "test" && user.Password == "test")
            {
                var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("a1b2c3d4e5f67890abcdef1234567890a1b2c3d4e5f67890abcdef1234567890"));
                var signinCredentials = new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256);
                var tokenOption = new JwtSecurityToken(
                    issuer: "https://localhost:7143",
                    audience: "https://localhost:7143",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                    );
                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokenOption);
                return Ok(new Authentication() { AuthToken = tokenString });
            }

            return Unauthorized();
        }
    }
}
