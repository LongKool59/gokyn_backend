using Application.Interfaces;
using Domain.Identity;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Infrastructure.Constants.Authorization;

namespace WebApi.Controllers.v1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class UsersController : VersionApiController
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegisterModel model)
        {
            var result = await _userService.RegisterAsync(model);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(TokenRequestModel model)
        {
            var result = await _userService.LoginAsync(model);
            JWTHelper.SetRefreshTokenInCookie(Response, result.RefreshToken);
            return Ok(result);
        }

        [HttpPost("add-role")]
        [Authorize(Roles = "Administrator")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<string> AddRoleAsync(AddRoleModel model)
        {
            return await _userService.AddRoleAsync(model);
        }

        [HttpGet("refresh-token")]
        public async Task<IActionResult> RefreshTokenAsync()
        {
            string? refreshToken = Request.Cookies["refreshToken"];
            AuthenticationModel response = await _userService.RefreshTokenAsync(refreshToken);
            if (!string.IsNullOrEmpty(response.RefreshToken))
                JWTHelper.SetRefreshTokenInCookie(Response, response.RefreshToken);
            return Ok(response);
        }

        [Authorize]
        [HttpGet("user-tokens/{id}")]
        public async Task<IActionResult> GetUserRefreshTokens(string id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user.RefreshTokens);
        }

        [HttpPost("revoke-token")]
        public async Task<IActionResult> RevokeToken(RevokeTokenModel model)
        {
            // accept token from request body or cookie
            var token = model.Token == null ? Request.Cookies["refreshToken"] : model.Token;
            if (string.IsNullOrEmpty(token))
                return BadRequest(new { message = "Token is required" });
            var response = await _userService.RevokeToken(token);
            if (!response)
                return NotFound(new { message = "Token not found" });
            return Ok(new { message = "Token revoked" });
        }
    }
}
