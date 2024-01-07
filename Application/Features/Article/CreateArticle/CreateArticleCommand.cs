using Application.Abstractions.Messaging;

namespace Application.Features.Article.CreateArticle;

public record CreateArticleCommand(
    string Name,
    string Code,
    string Gtin,
    string MeasureUnit,
    string Pkwiu,
    decimal BuyPriceWithoutTax,
    decimal BuyPriceWithTax,
    decimal SellPriceWithoutTax,
    decimal SellPriceWithTax,
    int TaxId,
    string Description
) : ICommand;