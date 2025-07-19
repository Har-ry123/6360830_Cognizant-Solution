using JwtAuthMicroservice.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JwtAuthMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Step 1: Validate user (for demo, use hardcoded user)
            if (IsValidUser(model))
            {
                // Step 2: Generate JWT token
                var token = GenerateJwtToken(model.Username);
                return Ok(new { Token = token });
            }

            return Unauthorized("Invalid username or password.");
        }

        // Hardcoded validation (replace with database check in real app)
        private bool IsValidUser(LoginModel model)
        {
            return model.Username == "test" && model.Password == "123";
        }

        // Step 3: Generate the JWT token
        private string GenerateJwtToken(string username)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, username),
                // Adding Admin role by default (used in Exercise 3)
                new Claim(ClaimTypes.Role, "Admin")
            };

            // Secret key (same as in appsettings.json)
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASecretKeyForJwtToken"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "MyAuthServer",
                audience: "MyApiUsers",
                claims: claims,
                expires: DateTime.Now.AddMinutes(30),  // Token valid for 60 minutes
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}

