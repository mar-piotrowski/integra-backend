using Application.Dtos;
using Application.Features.User.Commands;
using Application.Features.User.Queries;
using Domain.Result;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("integra/users")]
public class UserController : ControllerBase {
    private readonly ISender _sender;

    public UserController(ISender sender) {
        _sender = sender;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult> GetAll([FromQuery] GetUsersFromQuery queryParams) {
        var command = new GetUsersQuery(queryParams.Sort);
        var result = await _sender.Send(command);
        return result.MapResult();
    }

    [HttpGet("{userId:int}")]
    public async Task<ActionResult> Get(int userId) {
        var command = new GetUserQuery(UserId.Create(userId));
        var result = await _sender.Send(command);
        return result.MapResult();
    }
    
    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateUserCommand command) {
        var result = await _sender.Send(command);
        return result.MapResult();
    }
    
    [HttpPost("startWork")]
    public async Task<ActionResult> StartWork() {
        throw new NotImplementedException();
    }

    [HttpPost("endWork")]
    public async Task<ActionResult> EndWork() {
        throw new NotImplementedException();
    }

    [HttpPut("{userId:int}")]
    public async Task<ActionResult> Update([FromBody] UpdateUserRequest user, int userId) {
        var command = new UpdateUserCommand(
            userId,
            user.Firstname,
            user.Lastname,
            user.SecondName,
            user.Email,
            user.Phone,
            user.DateOfBirth,
            user.PlaceOfBirth,
            user.Sex,
            user.IsStudent,
            user.Locations
        );
        var result = await _sender.Send(command);
        return result.MapResult();
    }

    [HttpDelete("{userId:int}")]
    public async Task<ActionResult> Delete(int userId) {
        var command = new DeleteUserCommand(UserId.Create(userId));
        var result = await _sender.Send(command);
        return result.MapResult();
    }
}