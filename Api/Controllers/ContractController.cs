using Application.Dtos;
using Application.Features.Contract.CreateContract;
using Application.Features.Contract.GetContract;
using Application.Features.Contract.GetContractChanges;
using Application.Features.Contract.GetContracts;
using Application.Features.Contract.TerminateContract;
using Application.Features.Contract.UpdateContract;
using Domain.Common.Result;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("integra/contracts")]
public class ContractController : ControllerBase {
    private readonly ISender _sender;

    public ContractController(ISender sender) => _sender = sender;

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] ContractQueries queries) {
        var result = await _sender.Send(new GetContractsQuery(queries));
        return result.MapResult();
    }

    [HttpGet("{contractId:int}")]
    public async Task<ActionResult> Get(int contractId) {
        var result = await _sender.Send(new GetContractQuery(ContractId.Create(contractId)));
        return result.MapResult();
    }

    [HttpGet("{contractId:int}/changes")]
    public async Task<ActionResult> Changes(int contractId) {
        var result = await _sender.Send(new GetContractChangesQuery(ContractId.Create(contractId)));
        return result.MapResult();
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] CreateContractCommand command) {
        var result = await _sender.Send(command);
        return result.MapResult();
    }

    [HttpPut("{contractId:int}")]
    public async Task<ActionResult> Update([FromBody] UpdateContractCommand command) {
        throw new NotImplementedException();
    }

    [HttpPost("{contractId:int}/terminate")]
    public async Task<ActionResult> Termination(int contractId, [FromBody] TerminateContractRequest request) {
        var result = await _sender.Send(new TerminateContractCommand(
            ContractId.Create(contractId),
            request.TerminateType,
            request.TerminateDate
        ));
        return result.MapResult();
    }
}