using Application.Features.Contractor.CreateContractor;
using Application.Features.Contractor.GetContractor;
using Application.Features.Contractor.GetContractors;
using Application.Features.Contractor.UpdateContractor;
using Domain.Common.Result;
using Domain.ValueObjects;
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
        return result.MapResult();
    }

    [HttpGet("{nip}")]
    public async Task<ActionResult> Get(string nip) {
        var result = await _sender.Send(new GetContractorQuery(Nip.Create(nip)));
        return result.MapResult();
    }
    
    [HttpPost]
    public async Task<ActionResult> Add([FromBody] CreateContractorCommand command) {
        var result = await _sender.Send(command);
        return result.MapResult();
    }

    [HttpPut("{nip}")]
    public async Task<ActionResult> Edit(string nip, [FromBody] UpdateContractorCommand command) {
        var result = await _sender.Send(command);
        return result.MapResult();
    }
}