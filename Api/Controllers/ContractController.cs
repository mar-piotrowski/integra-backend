using Application.Features.Contract.Command;
using Application.Features.Contract.Query;
using Domain.Enums;
using Domain.Result;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("/api/v1/contracts")]
public class ContractController : ControllerBase {
    private readonly ISender _sender;

    public ContractController(ISender sender) {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromRoute] ContractType contractType, [FromRoute] int userId) {
        var result = await _sender.Send(new GetContractsQuery(contractType, UserId.Create(userId)));
        return result.MapResult();
    }

    [HttpGet("{contractId:int}")]
    public async Task<ActionResult> Get([FromQuery] int contractId) {
        var result = await _sender.Send(new GetContractQuery(ContractId.Create(contractId)));
        return result.MapResult();
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] CreateContractCommand command) {
        var result = await _sender.Send(command);
        return result.MapResult();
    }

    [HttpPut("{documentId:int}")]
    public async Task<ActionResult> Update(int userId, int documentId) {
        throw new NotImplementedException();
    }

    [HttpDelete("{documentId:int}")]
    public ActionResult Delete(int userId, int documentId) {
        throw new NotImplementedException();
    }
}