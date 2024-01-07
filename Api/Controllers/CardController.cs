using Application.Dtos;
using Application.Features.Card.ActiveCard;
using Application.Features.Card.CreateCard;
using Application.Features.Card.DeActiveCard;
using Application.Features.Card.GetCard;
using Application.Features.Card.GetCards;
using Domain.Common.Result;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace IntegraBackend.Controllers;

[Route("integra/cards")]
public class CardController {
    private readonly ISender _sender;
    public CardController(ISender sender) {
        _sender = sender;
    }

    [HttpGet]
    public async Task<ActionResult> GetAll() {
        var result = await _sender.Send(new GetCardsQuery());
        return result.MapResult();
    }

    [HttpGet("{cardNumber}")]
    public async Task<ActionResult> Get(string cardNumber) {
        var result = await _sender.Send(new GetCardQuery(CardNumber.Create(cardNumber)));
        return result.MapResult();
    }

    [HttpPost]
    public async Task<ActionResult> Create([FromBody] CreateCardRequest request) {
        var result = await _sender.Send(new CreateCardCommand(
            UserId.Create(request.UserId),
            CardNumber.Create(request.CardNumber)
        ));
        return result.MapResult();
    }
    
    [HttpPost("{cardNumber}/active")]
    public async Task<ActionResult> Active(string cardNumber) {
        var result = await _sender.Send(new ActiveCardCommand(CardNumber.Create(cardNumber)));
        return result.MapResult();
    }
    
    [HttpPost("{cardNumber}/deactive")]
    public async Task<ActionResult> DeActive(string cardNumber) {
        var result = await _sender.Send(new DeActiveCardCommand(CardNumber.Create(cardNumber)));
        return result.MapResult();
    }
}