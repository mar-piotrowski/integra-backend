using Application.Dtos;
using Application.Features.Authentication.Commands;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("/api/v1/auth")]
public class AuthenticationController : ControllerBase {
    private readonly ISender _sender;

    public AuthenticationController(ISender sender) {
        _sender = sender;
    }
    
    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginCommand command) {
        var result = await _sender.Send(command);
        return result.MapResult();
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterCommand command) {
        var result = await _sender.Send(command);
        return result.MapResult();
    }

    [HttpPost("reset-password")]
    public ActionResult ForgotPassword([FromBody] ForgotPasswordRequest resetPassword) {
        throw new NotImplementedException();
    }
}
