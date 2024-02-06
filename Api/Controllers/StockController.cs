using Application.Dtos;
using Application.Features.Stock.Create;
using Application.Features.Stock.Delete;
using Application.Features.Stock.Get;
using Application.Features.Stock.GetAll;
using Application.Features.Stock.Update;
using Domain.Common.Result;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("integra/stocks")]
public class StockController {
   private readonly ISender _sender;
   
   public StockController(ISender sender) {
      _sender = sender;
   }

   [HttpGet]
   public async Task<ActionResult> GetAll() {
      var result = await _sender.Send(new GetStocksQuery());
      return result.MapToResult();
   }

   [HttpGet("{stockId:int}")]
   public async Task<ActionResult> Get(int stockId) {
      var result = await _sender.Send(new GetStockQuery(new StockId(stockId)));
      return result.MapToResult();
   }

   [HttpPost]
   public async Task<ActionResult> Create([FromBody] CreateStockRequest request) {
      var result = await _sender.Send(new CreateStockCommand(
         request.Name,
         request.IsMain,
         request.Description
      ));
      return result.MapToResult();
   }
   
   [HttpPut("{stockId:int}")]
   public async Task<ActionResult> Edit(int stockId, [FromBody] EditStockRequest request) {
      var result = await _sender.Send(new EditStockCommand(
         new StockId(stockId),
         request.Name,
         request.IsMain,
         request.Description
      ));
      return result.MapToResult();
   }

   [HttpDelete("{stockId:int}")]
   public async Task<ActionResult> Delete(int stockId) {
      var result = await _sender.Send(new DeleteStockCommand(new StockId(stockId)));
      return result.MapToResult();
   }
}