using System.Net;
using Domain.Common.Models;

namespace Domain.Common.Errors;

public static class StockErrors {
    public static Error NotFound => new Error(HttpStatusCode.NotFound, "", "Nie znaleziono magazynu");
    public static Error NotFoundMany => new Error(HttpStatusCode.NotFound, "", "Nie znaleziono magazynow");
    public static Error NameExists => new Error(HttpStatusCode.Conflict, "", "Magazyn o podanej nazwie istnieje");

    public static Error CanNotDeleteWithProducts =>
        new Error(HttpStatusCode.BadRequest, "", "Nie można usunąć magazynu z który posiada produkty");

    public static Error NoArticleOnStock =>
        new Error(HttpStatusCode.NotFound, "", "Brak artykułu na magazynie");

    public static Error CanNotDeleteArticleWhenAmountIsNotZero =>
        new Error(HttpStatusCode.NotFound, "", "Nie można uzunąć artykułu z magazynu gdy stan nie jest równy 0");

    public static Error NoProductsOnStock =>
        new Error(HttpStatusCode.NotFound, "", "Nie znaleziono produktów na magazynie");

    public static Error NotEnoughAmountOnStock(string article, decimal amount) =>
        new Error(HttpStatusCode.Conflict, "",
            $"Nie wystraczająca ilość produktu {article} na magazynie. Dostępne: {amount}");

    public static Error SourceStockIsRequired =>
        new Error(HttpStatusCode.BadRequest, "", "Nie podano magazynu źródłowego");

    public static Error TargetStockIsRequired =>
        new Error(HttpStatusCode.BadRequest, "", "Nie podano magazynu docelowego");

    public static Error SourceStockNotFound =>
        new Error(HttpStatusCode.NotFound, "", "Nie podano magazynu źródłowego");

    public static Error TargetStockNotFound =>
        new Error(HttpStatusCode.NotFound, "", "Nie podano magazynu docelowego");
}