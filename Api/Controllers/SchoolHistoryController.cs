using Application.Dtos;
using Application.Features.SchoolHistory.Commands;
using Application.Features.SchoolHistory.Queries;
using Application.Features.User.Commands;
using Application.Features.User.Queries;
using Domain.Result;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("integra/school-histories")]
public class SchoolHistoryController {
    private readonly ISender _sender;

    public SchoolHistoryController(ISender sender) {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] int userId = -1) {
        var result = await _sender.Send(new GetUserSchoolHistoriesQuery(UserId.Create(userId)));
        return result.MapResult();
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateSchoolHistoryRequest request) {
        var result = await _sender.Send(new CreateUserSchoolHistoryCommand(
            UserId.Create(request.UserId),
            request.SchoolName,
            request.Degree,
            request.Specialization,
            request.Title,
            request.StartDate,
            request.EndDate
        ));
        return result.MapResult();
    }

    [HttpPut("{schoolHistoryId:int}")]
    public async Task<ActionResult> Update(int schoolHistoryId, [FromBody] UpdateSchoolHistoryRequest request) {
        var result = await _sender.Send(new UpdateSchoolHistoryCommand(
            SchoolHistoryId.Create(schoolHistoryId),
            request.SchoolName,
            request.Degree,
            request.Specialization,
            request.Title,
            request.StartDate,
            request.EndDate
        ));
        return result.MapResult();
    }

    [HttpDelete("{schoolHistoryId:int}")]
    public async Task<ActionResult> Delete(int schoolHistoryId) {
        var result = await _sender.Send(new DeleteSchoolHistoryCommand(SchoolHistoryId.Create(schoolHistoryId)));
        return result.MapResult();
    }
}