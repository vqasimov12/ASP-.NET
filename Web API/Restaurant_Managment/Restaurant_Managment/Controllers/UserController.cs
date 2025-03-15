using Application.CQRS.Users.Handlers;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using static Application.CQRS.Users.Handlers.GetById;
using static Application.CQRS.Users.Handlers.RefreshToken;
using static Application.CQRS.Users.Handlers.Register;

namespace RestaurantManagement.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UserController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery] int id)
    {
        var request = new Query() { Id = id };
        return Ok(await _sender.Send(request));
    }

    [HttpPost]
    //[Authorize(Roles = "Admin")]
    [AllowAnonymous]

    public async Task<IActionResult> Register([FromBody] Command request) => Ok(await _sender.Send(request));

    [HttpDelete]
    public async Task<IActionResult> Delete([FromQuery] int id)
    {
        var request = new Delete.Command() { Id = id };
        return Ok(await _sender.Send(request));
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromQuery] Update.Command request) => Ok(await _sender.Send(request));

    [HttpPost("Login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] Login.LoginRequest request) => Ok(await _sender.Send(request));

    [HttpPost("RefreshToken")]
    public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request) =>
        Ok(await _sender.Send(request));
}