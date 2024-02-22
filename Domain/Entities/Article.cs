using Domain.Common.Models;
using Domain.ValueObjects.Ids;

namespace Domain.Entities;

public sealed class Article : Entity<ArticleId> {
    public string Name { get; private set; }
    public string Code { get; private set; }
    public string? Gtin { get; private set; }
    public string MeasureUnit { get; private set; }
    public string? Pkwiu { get; private set; }
    public decimal BuyPriceWithoutTax { get; private set; }
    public decimal BuyPriceWithTax { get; private set; }
    public decimal SellPriceWithoutTax { get; private set; }
    public decimal SellPriceWithTax { get; private set; }
    public decimal Tax { get; private set; }
    public string? Description { get; private set; }
    public bool Historical { get; private set; } 
    public bool Active { get; private set; } = true;

    public List<DocumentArticles> Documents { get; private set; } = new List<DocumentArticles>();

    public List<StockArticles> Stocks { get; private set; } = new List<StockArticles>();

    public Article() { }

    public Article(
        string name,
        string code,
        string? gtin,
        string measureUnit,
        string? pkwiu,
        decimal buyPriceWithoutTax,
        decimal buyPriceWithTax,
        decimal sellPriceWithoutTax,
        decimal sellPriceWithTax,
        decimal tax,
        string? description
    ) {
        Name = name;
        Code = code;
        Gtin = gtin;
        MeasureUnit = measureUnit;
        Pkwiu = pkwiu;
        BuyPriceWithoutTax = buyPriceWithoutTax;
        BuyPriceWithTax = buyPriceWithTax;
        SellPriceWithoutTax = sellPriceWithoutTax;
        SellPriceWithTax = sellPriceWithTax;
        Tax = tax;
        Description = description;
    }

    public void Disable() {
        Active = false;
        Historical = true;
    }
}