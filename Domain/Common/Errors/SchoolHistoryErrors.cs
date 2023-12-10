using System.Net;
using Domain.Common.Models;

namespace Domain.Common.Errors; 

public static class SchoolHistoryErrors {
    public static Error NotFound =>
        new Error(HttpStatusCode.NotFound, "SchoolHistory.NotFound", "Nie znaleziono historii o podanym ID");
}