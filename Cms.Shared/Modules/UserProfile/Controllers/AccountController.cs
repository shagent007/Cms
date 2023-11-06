using System.Text.Json;
using Cms.Shared.Modules.UserProfile.Models;
using Cms.Shared.Modules.UserProfile.Services;
using Cms.Shared.Shared.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cms.Shared.Modules.UserProfile.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
public class AccountController : ControllerBase
{
    private readonly UserService _userService;

    public AccountController(UserService userService)
    {
        _userService = userService;
    }
    
    /*
     *[
     * 
     */
    [HttpPatch("{id:long}")]
    public virtual async Task<IActionResult> sad(long id, [FromBody] List<JsonDocument> updateItems)
    {
        DateTime dateTime = DateTime.Now; // Ваш объект DateTime
        string formattedDate = dateTime.ToString("dd/MM/yyyy");
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterModel model)
    {
        try
        {
            var result = await _userService.RegisterUserAsync(model);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorResponse(e));
        }
    }
    
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> RegisterUser([FromBody] LoginModel model)
    {
        try
        {
            var result = await _userService.LoginUserAsync(model);
            return Ok(result);
        }
        catch (Exception e)
        {
            return BadRequest(new ErrorResponse(e));
        }
    }
    
    [HttpPost("test")]
    public IActionResult Test()
    {
        return Ok("Всё получилось");
    }
}