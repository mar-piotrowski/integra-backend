using Application.Dtos;
using Application.Features.Authentication.ChangePassword;
using Application.Features.Authentication.Login;
using Application.Features.Authentication.RefreshToken;
using Application.Features.Authentication.Register;
using Domain.Common.Result;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        var result = await _sender.Send(new LoginCommand(
            Email.Create(request.Email),
            Password.Create(request.Password))
        );
        if (!result.IsSuccess)
            return result.MapToResult();
        var cookieOptions = new CookieOptions {
            HttpOnly = true,
            Secure = true,
        };
        HttpContext.Response.Cookies.Append("refreshToken", result.Value.RefreshToken, cookieOptions);
        return result.MapToResult();
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

        return result.MapToResult();
    }

    [HttpPost("logout")]
    public ActionResult Logout() {
        HttpContext.Response.Cookies.Delete("refreshToken");
        return Ok();
    }

    [HttpPost("change-password")]
    public async Task<ActionResult> ChangePassword([FromBody] ChangePasswordRequest request) {
        var result = await _sender.Send(new ChangePasswordCommand(
            UserId.Create(request.UserId),
            request.CurrentPassword,
            request.NewPassword
        ));
        return result.MapToResult();
    }

    [HttpPost("refresh-token")]
    [AllowAnonymous]
    public async Task<ActionResult> RefreshToken() {
        HttpContext.Request.Cookies.TryGetValue("refreshToken", out var refreshToken);
        var result = await _sender.Send(new RefreshTokenCommand(refreshToken ?? ""));
        return result.MapToResult();
    }
}