using Application.Abstractions;
using Application.Abstractions.Messaging;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Application.Features.Article.Command;

public record UpdateArticleCommand(
    ArticleId Id,
    string Name,
    string Code,
    string Gtin,
    string MeasureUnit,
    string Pkwiu,
    // decimal BuyPriceWithoutTax,
    // decimal BuyPriceWithTax,
    // decimal SellPriceWithoutTax,
    // decimal SellPriceWithTax,
    // decimal Tax,
    string Description,
    int StockId
) : ICommand;