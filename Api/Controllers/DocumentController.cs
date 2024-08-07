using Application.Dtos;
using Application.Features.Document.Create;
using Application.Features.Document.Delete;
using Application.Features.Document.Edit;
using Application.Features.Document.Get;
using Application.Features.Document.GetAll;
using Domain.Common.Result;
using Domain.Entities;
using Domain.Enums;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("integra/documents")]
[ApiController]
public class DocumentController : ControllerBase {
    private readonly ISender _sender;

    public DocumentController(ISender sender) {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll([FromQuery] List<DocumentType> documentType) {
        var result = await _sender.Send(new GetDocumentsQuery(documentType));
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
            request.ReceptionDate,
            request.PaymentDate,
            request.PaymentMethod,
            request.Discount,
            request.TotalAmountWithoutTax,
            request.TotalAmountWithTax,
            request.Description,
            request.Locked,
            request.Articles,
            request.ContractorId is not null && request.ContractorId != 0
                ? ContractorId.Create(request.ContractorId.Value)
                : null,
            request.SourceStockId is not null && request.SourceStockId != 0
                ? new StockId(request.SourceStockId.Value)
                : null,
            request.TargetStockId is not null && request.TargetStockId != 0
                ? new StockId(request.TargetStockId.Value)
                : null
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
            request.PaymentMethod,
            request.Discount,
            request.TotalAmountWithoutTax,
            request.TotalAmountWithTax,
            request.Description,
            request.Locked,
            request.Articles,
            request.ContractorId is not null && request.ContractorId != 0
                ? ContractorId.Create(request.ContractorId.Value)
                : null,
            request.SourceStockId is not null && request.SourceStockId != 0
                ? new StockId(request.SourceStockId.Value)
                : null,
            request.TargetStockId is not null && request.TargetStockId != 0
                ? new StockId(request.TargetStockId.Value)
                : null
        ));
        return result.MapToResult();
    }

    [HttpDelete("{documentId:int}")]
    public async Task<ActionResult> Delete(int documentId) {
        var result = await _sender.Send(new DeleteDocumentCommand(documentId));
        return result.MapToResult();
    }
}