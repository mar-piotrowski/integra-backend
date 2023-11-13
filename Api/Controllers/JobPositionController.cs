using Application.Dtos;
using Application.Features.JobPosition.Command;
using Domain.Result;
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
    public async Task<ActionResult> GetAll() {
        throw new NotImplementedException();
    }

    [HttpGet("{jobPositionId:int}")]
    public async Task<ActionResult> Get(int jobPositionId) {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateJobPositionCommand command) {
        var result = await _sender.Send(command);
        return result.MapResult();
    }

    [HttpPut("{jobPositionId:int}")]
    public async Task<ActionResult> Update(int jobPositionId, [FromBody] UpdateJobPositionRequest request) {
        var result = await _sender.Send(new UpdateJobPositionCommand(jobPositionId, request.Title));
        return result.MapResult();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete() {
        throw new NotImplementedException();
    }
}