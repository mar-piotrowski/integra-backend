using System.Net;
using Domain.Common.Models;

namespace Domain.Common.Errors;

public static class JobHistoryErrors {
    public static Error NotFound =>
        new Error(HttpStatusCode.NotFound, "JobHistory.NotFound", "Nie znaleziono historii pracy o podanym ID");

    public static Error NotAny =>
        new Error(HttpStatusCode.NotFound, "JobHistory.Any", "Nie znaleziono żadnych history zatrudnienias");
    public static Error WrongDates =>
        new Error(HttpStatusCode.BadRequest, "JobHistory.WrongDates", "Data rozpoczęcia nie moze być większa niż data zakończenia!");
}