using Domain.Entities;

namespace Application.Dtos;

public class ArticleResponse {
    public string Name { get; set; }
    public string Code { get; set; }
    public string Gtin { get; set; }
    public string MeasureUnit { get; set; }
    public string Pkwiu { get; set; }
    public string Description { get; set; }
    public Stock Stock { get; set; }
}