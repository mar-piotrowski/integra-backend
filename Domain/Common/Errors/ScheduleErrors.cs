using System.Net;
using Domain.Common.Models;

namespace Domain.Common.Errors;

public static class ScheduleErrors {
    public static Error NameExists =>
        new Error(HttpStatusCode.Conflict, "", "Grafik o podanej nazwie istnieje");

    public static Error DatesNotValid =>
        new Error(HttpStatusCode.BadRequest, "", "Podane niepoprawny zakres dat");

    public static Error NotValidDay =>
        new Error(HttpStatusCode.BadRequest, "", "Podano nieprawidlowy dzien");

    public static Error NotFoundAny =>
        new Error(HttpStatusCode.NotFound, "", "Nie znaleziono zadnych grafikow");

    public static Error NotFound =>
        new Error(HttpStatusCode.NotFound, "", "Nie znaleziono grafiku o podanym id");
    
    public static Error NotValidDaysAmount =>
        new Error(HttpStatusCode.BadRequest, "", "Nie podano wszystkich dni tygodnia");
    
    public static Error HourIsZeroOrLess=>
        new Error(HttpStatusCode.BadRequest, "", "Podano nie poprawną godzinę");
}