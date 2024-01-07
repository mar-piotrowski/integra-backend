using System.Net;
using Domain.Common.Models;

namespace Domain.Common.Errors;

public static class CardErrors {
    public static Error NotFound => new Error(HttpStatusCode.NotFound, "", "Nie znaleziono karty");
    public static Error Exists => new Error(HttpStatusCode.Conflict, "", "Podany numer karty już istnieje");
    public static Error AlreadyDeActive => new Error(HttpStatusCode.BadRequest, "", "Karta jest juz nie aktywna");
    public static Error AlreadyActive => new Error(HttpStatusCode.BadRequest, "", "Karta jest juz aktywna");
    public static Error NotFoundAny => new Error(HttpStatusCode.NotFound, "", "Nie znaleziono żadnych kart!");
}