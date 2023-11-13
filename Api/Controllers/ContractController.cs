using Application.Features.Contract.Command;
using Domain.Result;
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
    public ActionResult GetAll(int userId) {
        throw new NotImplementedException();
    }

    [HttpGet("{documentId:int}")]
    public ActionResult Get(int userId, [FromRoute] int documentId, [FromQuery] int documentType) {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] CreateContractCommand command) {
        var result = await _sender.Send(command);
        return result.MapResult();
    }

    [HttpPut("{documentId:int}")]
    public ActionResult Update(int userId, int documentId) {
        throw new NotImplementedException();
    }
    
    [HttpDelete("{documentId:int}")]
    public ActionResult Delete(int userId, int documentId) {
        throw new NotImplementedException();
    }
}