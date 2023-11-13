using Application.Features.Stock.Command;
using Domain.Result;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("/api/v1/stocks")]
public class StockController : ControllerBase {
    private readonly ISender _sender;

    public StockController(ISender sender) {
        _sender = sender;
    }

    [HttpGet]
    public ActionResult GetAll() {
        throw new NotImplementedException();
    }

    [HttpGet("{stockId:int}")]
    public ActionResult Get(int stockId) {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<ActionResult> Add([FromBody] CreateStockCommand command) {
        var result = await _sender.Send(command);
        return result.MapResult();
    }

    [HttpPut("{stockId:int}")]
    public ActionResult Update(int stockId) {
        throw new NotImplementedException();
    }

    [HttpDelete("{stockId:int}")]
    public ActionResult Delete(int stockId) {
        throw new NotImplementedException();
    }
}