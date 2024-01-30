using System.Net;
using Domain.Common.Models;

namespace Domain.Common.Errors;

public static class AbsenceErrors {
    public static Error NotFound =>
        new Error(HttpStatusCode.NotFound, "Absence.NotFound", "Nie znaleziono nieobecnosci");

    public static Error NotFoundMany =>
        new Error(HttpStatusCode.NotFound, "Absence.NotFoundMany", "Nie znaleziono zadnych nieobesnosci");

    public static Error AlreadyAccepted =>
        new Error(HttpStatusCode.BadRequest, "Absence.AlreadyAccepted", "Nieobecność zostałaj już zaakceptowana");

    public static Error AlreadyRejected =>
        new Error(HttpStatusCode.BadRequest, "Absence.AlreadyRejected", "Nieobecność została już odrzucona");
    
    public static Error InvalidDates =>
        new Error(HttpStatusCode.BadRequest, "", "Wprowadzono błędną datę urlopu");
    
    public static Error LimitReached=>
        new Error(HttpStatusCode.BadRequest, "", "Osiągnięto już limit urlopu");

    public static Error NoAvailableDays =>
        new Error(HttpStatusCode.BadRequest, "", "Podany urlop jest dłuższy niż dostępne dni");
}