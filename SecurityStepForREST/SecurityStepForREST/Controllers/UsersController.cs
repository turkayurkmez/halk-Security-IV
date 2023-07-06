using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SecurityStepForREST.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SecurityStepForREST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpPost]
        public IActionResult Login(UserLoginModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.UserName == "turkay" && model.Password == "123")
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu cumle onaylama icin cok onemli"));
                    var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var claims = new[] { new Claim(System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames.Email, "a@b.com") };

                    var token = new JwtSecurityToken(
                        issuer: "server.halkbank",
                        audience: "client.halkbank",
                        claims: claims,
                        notBefore: DateTime.Now,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: credential
                        );

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });


                }
                ModelState.AddModelError("", "olmaz bu");

            }
            return BadRequest(ModelState);
        }
    }
}
