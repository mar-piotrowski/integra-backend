using System.Net;
using Domain.Common.Models;

namespace Domain.Common.Errors;

public static class HolidayLimitErrors {
    public static Error YearExists => new Error(HttpStatusCode.Conflict, "", "Dodano juz limit za podany rok");
    public static Error WrongYear => new Error(HttpStatusCode.BadRequest, "", "Podane bledne daty");
    public static Error NotFoundAny => new Error(HttpStatusCode.NotFound, "", "Nie znaleziono limitow");
    public static Error NotFound => new Error(HttpStatusCode.NotFound, "", "Nie znaleziono limitu");
}