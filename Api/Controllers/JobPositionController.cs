using Application.Dtos;
using Application.Features.JobPosition.CreateJobPosition;
using Application.Features.JobPosition.GetJobPosition;
using Application.Features.JobPosition.GetJobPositions;
using Application.Features.JobPosition.GetJobPositionWithStatus;
using Application.Features.JobPosition.UpdateJobPosition;
using Domain.Common.Result;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("integra/job-positions")]
public class JobPositionController : ControllerBase {
    private readonly ISender _sender;

    public JobPositionController(ISender sender) {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] JobPositionQueries queries) {
        var result = await _sender.Send(new GetJobPositionsQuery(""));
        return result.MapResult();
    }

    [HttpGet("{jobPositionId:int}")]
    public async Task<ActionResult> Get(int jobPositionId) {
        var result = await _sender.Send(new GetJobPositionQuery(JobPositionId.Create(jobPositionId)));
        return result.MapResult();
    }

    [HttpGet("statistics")]
    public async Task<ActionResult> GetAllWithStatistics() {
        var result = await _sender.Send(new GetJobPositionWithStatusQuery());
        return result.MapResult();
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateJobPositionCommand command) {
        var result = await _sender.Send(command);
        return result.MapResult();
    }

    [HttpPut("{jobPositionId:int}")]
    public async Task<ActionResult> Update(int jobPositionId, [FromBody] UpdateJobPositionRequest request) {
        var result = await _sender.Send(new UpdateJobPositionCommand(
            JobPositionId.Create(jobPositionId),
            request.Title
        ));
        return result.MapResult();
    }

    
    [HttpDelete]
    public async Task<ActionResult> Delete() {
        throw new NotImplementedException();
    }
}