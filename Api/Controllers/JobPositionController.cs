using Application.Dtos;
using Application.Features.JobPosition.Command;
using Application.Features.JobPosition.Query;
using Domain.Result;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("/api/v1/job-positions")]
public class JobPositionController : ControllerBase {
    private readonly ISender _sender;

    public JobPositionController(ISender sender) {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromRoute] string name) {
        var result = await _sender.Send(new GetJobPositionsQuery(name));
        return result.MapResult();
    }

    [HttpGet("{jobPositionId:int}")]
    public async Task<ActionResult> Get(int jobPositionId) {
        var result = await _sender.Send(new GetJobPositionQuery(JobPositionId.Create(jobPositionId)));
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