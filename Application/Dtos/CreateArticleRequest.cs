namespace Application.Dtos; 

public class CreateArticleRequest {
    public string Name { get; set; }
    public string Code { get; set; }
    public string Gtin { get; set; }
    public string MeasureUnit { get; set; }
    public string Pkwiu { get; set; }
    // public decimal BuyPriceWithoutTax { get; set; }
    // public decimal SellPriceWithoutTax { get; set; }
    // public decimal Tax { get; set; } 
    public string Description { get; set; }
    public int StockId { get; set; }
}