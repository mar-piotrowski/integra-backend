using System.Net;
using Domain.Common.Models;

namespace Domain.Common.Errors;

public static class PermissionErrors {
    public static Error NameExists => 
        new Error(HttpStatusCode.Conflict, "", "Podana nazwa uprawnienia już istnieje");
    public static Error CodeExists => 
        new Error(HttpStatusCode.Conflict, "", "Podany kod uprawnienia już istnieje");
    public static Error NameNotExists =>
        new Error(HttpStatusCode.BadRequest, "", "Podana nazwa uprawnienia nie istnieje");
    public static Error CodeNotExists =>
        new Error(HttpStatusCode.BadRequest, "", "Podany kod uprawnienia nie istnieje");
    public static Error NotFoundAny =>
        new Error(HttpStatusCode.NotFound, "", "Nie znaleziono żadnych uprawnień");
    public static Error NotFound => 
        new Error(HttpStatusCode.NotFound, "", "Nie znaleziono żadnych uprawnienia");
    public static Error CanNotAddOwner=> 
        new Error(HttpStatusCode.NotFound, "", "Nie mozna zmienic rangi wlasciciela");
}