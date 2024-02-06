using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.Stock.RemoveProduct;

public record RemoveArticleFromStockCommand(StockId StockId, string ArticleCode) : ICommand;