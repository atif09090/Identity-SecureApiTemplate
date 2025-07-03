using Identity_SecureApiTemplate.Data;
using Identity_SecureApiTemplate.Models;
using Identity_SecureApiTemplate.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Identity_SecureApiTemplate.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly JwtTokenService _jwtService;

        public AuthController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, JwtTokenService jwtService)
        {
            _userManager = userManager;
            _jwtService = jwtService;
            _roleManager = roleManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
                return Unauthorized("Invalid credentials.");

            var roles = await _userManager.GetRolesAsync(user);
            var token = _jwtService.GenerateToken(user, roles);

            return Ok(new { token });
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var validRoles = new[] { "User", "Admin" };

            if (!validRoles.Contains(request.Role))
                return BadRequest("Invalid role. Allowed roles: User, Admin.");

            if (await _userManager.FindByEmailAsync(request.Email) != null)
                return BadRequest("Email already in use.");

            var user = new ApplicationUser
            {
                UserName = request.Email,
                Email = request.Email,
            };

            var result = await _userManager.CreateAsync(user, request.Password);

            if (!result.Succeeded)
                return BadRequest(result.Errors);

            // Ensure the role exists
            if (!await _roleManager.RoleExistsAsync(request.Role))
                await _roleManager.CreateAsync(new IdentityRole(request.Role));

            await _userManager.AddToRoleAsync(user, request.Role);

            return Ok(new { message = $"{request.Role} registered successfully." });
        }

    }
}
