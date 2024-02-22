using Application.Features.Contractor.Create;
using Application.Features.Contractor.Delete;
using Application.Features.Contractor.Get;
using Application.Features.Contractor.GetAll;
using Application.Features.Contractor.Update;
using Domain.Common.Result;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("integra/contractors")]
public class ContractorController : ControllerBase {
    private readonly ISender _sender;

    public ContractorController(ISender sender) {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll() {
        var result = await _sender.Send(new GetContractorsQuery());
        return result.MapToResult();
    }

    [HttpGet("{nip}")]
    public async Task<ActionResult> Get(string nip) {
        var result = await _sender.Send(new GetContractorQuery(Nip.Create(nip)));
        return result.MapToResult();
    }
    
    [HttpPost]
    public async Task<ActionResult> Add([FromBody] CreateContractorCommand command) {
        var result = await _sender.Send(command);
        return result.MapToResult();
    }

    [HttpPut]
    public async Task<ActionResult> Edit([FromBody] UpdateContractorCommand command) {
        var result = await _sender.Send(command);
        return result.MapToResult();
    }
    
    [HttpDelete("{contractorId:int}")]
    public async Task<ActionResult> Delete(int contractorId) {
        var result = await _sender.Send(new DeleteContractorCommand(ContractorId.Create(contractorId)));
        return result.MapToResult();
    }
}