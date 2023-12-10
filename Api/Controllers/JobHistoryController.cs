using Application.Dtos;
using Application.Features.JobHistory.Command;
using Application.Features.JobHistory.Queries;
using Application.Features.User.Commands;
using Application.Features.User.Queries;
using Domain.Result;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("integra/job-histories")]
public class JobHistoryController : ControllerBase {
    private readonly ISender _sender;

    public JobHistoryController(ISender sender) => _sender = sender;

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] int userId = -1) {
        var result = await _sender.Send(new GetUserJobHistoriesQuery(UserId.Create(userId)));
        return result.MapResult();
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateJobHistoryRequest request) {
        var result = await _sender.Send(new CreateUserJobHistoryCommand(
            UserId.Create(request.UserId),
            request.CompanyName,
            request.Position,
            request.StartDate,
            request.EndDate
        ));
        return result.MapResult();
    }

    [HttpPut("{jobHistoryId:int}")]
    public async Task<ActionResult> Update(int jobHistoryId, [FromBody] UpdateJobHistoryRequest request) {
        var result = await _sender.Send(new UpdateJobHistoryCommand(
            JobHistoryId.Create(jobHistoryId),
            request.CompanyName,
            request.Position,
            request.StartDate,
            request.EndDate
        ));
        return result.MapResult();
    }

    [HttpDelete("{jobHistoryId:int}")]
    public async Task<ActionResult> Delete(int jobHistoryId) {
        var result = await _sender.Send(new DeleteJobHistoryCommand(JobHistoryId.Create(jobHistoryId)));
        return result.MapResult();
    }
}