using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.Stock.AddProduct;

public record AddProductToStockCommand(StockId StockId, string ArticleCode, decimal Amount) : ICommand;