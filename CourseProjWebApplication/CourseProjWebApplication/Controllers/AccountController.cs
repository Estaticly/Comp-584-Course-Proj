using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using ShoeExplorerModel;
using System.IdentityModel.Tokens.Jwt;
using CourseProjWebApplication;

namespace CourseProjWebApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<ShoeExplorerUser> _userManager;
        private readonly JwtHandler _jwtHandler;

        public AccountController(UserManager<ShoeExplorerUser> userManager, JwtHandler jwtHandler)
        {
            _userManager = userManager;
            _jwtHandler = jwtHandler;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginRequest loginRequest)
        {
            ShoeExplorerUser? user = await _userManager.FindByNameAsync(loginRequest.UserName);
            if (user == null||!await _userManager.CheckPasswordAsync(user, loginRequest.Password))
            {
                return Unauthorized(new LoginResult
                {
                    Success = false,
                    Message = "Invalid Username or Password"
                });
            }

            JwtSecurityToken secToken = await _jwtHandler.GetTokenAsync(user);
            string? jwt = new JwtSecurityTokenHandler().WriteToken(secToken);
            return Ok(new LoginResult
            {
                Success = true,
                Message = "Login successful",
                Token = jwt
            });
        }
    }
}
