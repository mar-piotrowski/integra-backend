using System.Net;
using Domain.Common.Models;

namespace Domain.Common.Errors;

public static class WorkingTimeErrors {
    public static Error JobAlreadyStarted => new Error(HttpStatusCode.Conflict, "", "Już rozpoczęto zmianę");
    public static Error JobHasNotStarted => new Error(HttpStatusCode.Conflict, "", "Nie rozpoczęto zmiany");
    public static Error NotFound => new Error(HttpStatusCode.NotFound, "", "Nie znaleziono czasu pracy");
    public static Error NotFoundMany => new Error(HttpStatusCode.NotFound, "", "Nie znaleziono czasów pracy");

    public static Error WrongDates => new Error(HttpStatusCode.BadRequest, "",
        "Daata zakończenie nie może być większa od daty rozpoczęcia");
}