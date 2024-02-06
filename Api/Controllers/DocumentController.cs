using Application.Dtos;
using Application.Features.Document.Create;
using Application.Features.Document.Delete;
using Application.Features.Document.Edit;
using Application.Features.Document.Get;
using Application.Features.Document.GetAll;
using Domain.Common.Result;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("integra/documents")]
public class DocumentController : ControllerBase {
    private readonly ISender _sender;

    public DocumentController(ISender sender) {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll() {
        var result = await _sender.Send(new GetDocumentsQuery());
        return result.MapToResult();
    }

    [HttpGet("{documentId:int}")]
    public async Task<ActionResult> Get(int documentId) {
        var result = await _sender.Send(new GetDocumentQuery(documentId));
        return result.MapToResult();
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateDocumentRequest request) {
        var result = await _sender.Send(new CreateDocumentCommand(
            request.Type,
            request.Number,
            request.IssueDate,
            request.AdmissionDate,
            request.ReceptionDate,
            request.PaymentDate,
            request.PaymentMethod,
            request.Discount,
            request.TotalAmountWithoutTax,
            request.TotalAmountWithTax,
            request.Description,
            request.Locked,
            request.Articles,
            ContractorId.Create(request.ContractorId),
            new StockId(request.SourceStockId),
            new StockId(request.TargetStockId)
        ));
        return result.MapToResult();
    }

    [HttpPut("{documentId:int}")]
    public async Task<ActionResult> Edit(int documentId, [FromBody] EditDocumentRequest request) {
        var result = await _sender.Send(new EditDocumentCommand(
            DocumentId.Create(documentId),
            request.Number,
            request.IssueDate,
            request.ReceptionDate,
            request.PaymentDate,
            request.Discount,
            request.TotalAmountWithoutTax,
            request.TotalAmountWithTax,
            request.Description,
            request.Locked,
            request.Articles,
            ContractorId.Create(request.ContractorId),
            new StockId(request.SourceStockId),
           new StockId(request.TargetStockId) 
        ));
        return result.MapToResult();
    }

    [HttpDelete("{documentId:int}")]
    public async Task<ActionResult> Delete(int documentId) {
        var result = await _sender.Send(new DeleteDocumentCommand(documentId));
        return result.MapToResult();
    }
}