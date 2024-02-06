using Application.Dtos;
using Application.Features.User.AddPermissions;
using Application.Features.User.AddSchedule;
using Application.Features.User.CreateUser;
using Application.Features.User.DeleteSchedule;
using Application.Features.User.DeleteUser;
using Application.Features.User.GetSchedule;
using Application.Features.User.GetUser;
using Application.Features.User.GetUsers;
using Application.Features.User.RemovePermissions;
using Application.Features.User.UpdateUser;
using Domain.Common.Result;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("integra/users")]
public class UserController : ControllerBase {
    private readonly ISender _sender;

    public UserController(ISender sender) => _sender = sender;

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] UserQueryParams filters) {
        var command = new GetUsersQuery(filters.Sort);
        var result = await _sender.Send(command);
        return result.MapToResult();
    }

    [HttpGet("{userId:int}")]
    public async Task<ActionResult> Get(int userId) {
        var command = new GetUserQuery(UserId.Create(userId));
        var result = await _sender.Send(command);
        return result.MapToResult();
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateUserCommand command) {
        var result = await _sender.Send(command);
        return result.MapToResult();
    }

    [HttpPost("{userId:int}/add-permissions")]
    public async Task<ActionResult> AddPermissions(int userId, [FromBody] AddUserPermissionsRequest request) {
        var result = await _sender.Send(new AddUserPermissionsCommand(
            UserId.Create(userId),
            request.Permissions.Select(PermissionCode.Create)
        ));
        return result.MapToResult();
    }

    [HttpPost("{userId:int}/remove-permissions")]
    public async Task<ActionResult> RemovePermissions(int userId, [FromBody] RemoveUserPermissionRequest request) {
        var result = await _sender.Send(new RemoveUserPermissionsCommand(
            UserId.Create(userId),
            request.Permissions.Select(PermissionCode.Create)
        ));
        return result.MapToResult();
    }

    [HttpPost("{userId:int}/schedules/add-schedule")]
    public async Task<ActionResult> AddSchedule(int userId, [FromBody] AddUserScheduleRequest request) {
        var result = await _sender.Send(new AddUserScheduleCommand(
            UserId.Create(userId),
            ScheduleSchemaId.Create(request.ScheduleSchemaId)
        ));
        return result.MapToResult();
    }

    [HttpDelete("{userId:int}/schedules/{scheduleId:int}/remove-schedule")]
    public async Task<ActionResult> RemoveSchedule(int userId, int scheduleId) {
        var result = await _sender.Send(new DeleteUserScheduleCommand(
            UserId.Create(userId),
            ScheduleSchemaId.Create(scheduleId)
        ));
        return result.MapToResult();
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
        return result.MapToResult();
    }

    [HttpDelete("{userId:int}")]
    public async Task<ActionResult> Delete(int userId) {
        var command = new DeleteUserCommand(UserId.Create(userId));
        var result = await _sender.Send(command);
        return result.MapToResult();
    }
}