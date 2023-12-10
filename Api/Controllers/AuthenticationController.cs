using Application.Dtos;
using Application.Features.Authentication.Commands;
using Domain.Result;
using Domain.ValueObjects;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("integra/auth")]
public class AuthenticationController : ControllerBase {
    private readonly ISender _sender;

    public AuthenticationController(ISender sender) {
        _sender = sender;
    }

    [HttpPost("login")]
    public async Task<ActionResult> Login([FromBody] LoginRequest request) {
        var result =
            await _sender.Send(new LoginCommand(Email.Create(request.Email), Password.Create(request.Password)));
        return result.MapResult();
    }

    [HttpPost("register")]
    public async Task<ActionResult> Register([FromBody] RegisterRequest request) {
        var result = await _sender.Send(new RegisterCommand(
            request.Firstname,
            request.Lastname,
            Email.Create(request.Email),
            Password.Create(request.Password),
            Password.Create(request.ConfirmPassword)
        ));
        return result.MapResult();
    }

    [HttpPost("reset-password")]
    public ActionResult ForgotPassword([FromBody] ForgotPasswordRequest resetPassword) {
        throw new NotImplementedException();
    }
}