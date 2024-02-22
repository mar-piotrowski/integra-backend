using System.Net;
using Domain.Common.Models;

namespace Domain.Common.Errors {
    public static class UserErrors {
        public static Error NotFound =>
            new Error(HttpStatusCode.NotFound, "User.NotFound", "Nie znaleziono użytkownika o podanym id");

        public static Error IdentityNumberExists =>
            new Error(HttpStatusCode.Conflict, "User.IdentityExists",
                "Istnieje już użytkownik z podanym numerem pesel");

        public static Error EmailExists =>
            new Error(HttpStatusCode.Conflict, "User.EmailExists", "Podany email juz jest zarejestrowany");

        public static Error NotFoundMany =>
            new Error(HttpStatusCode.NotFound, "User.NotFound", "Nie znaleziono użytkowników");

        public static Error EmailNotFound =>
            new Error(HttpStatusCode.NotFound, "User.LoginCredentialProblem", "Podane dane są nie poprawne");

        public static Error PasswordWrong =>
            new Error(HttpStatusCode.BadRequest, "User.LoginCredentialProblem", "Podane dane są nie poprawne");

        public static Error UserDoesNotExists =>
            new Error(HttpStatusCode.NotFound, "User.NotFound", "Użytkownik o podanym id nie istnieje");

        public static Error NoPermission =>
            new Error(HttpStatusCode.NotFound, "", "Użytkownik nie posiada tego uprawnienia");

        public static Error NoPermissions =>
            new Error(HttpStatusCode.NotFound, "", "Użytkownik nie posiada żadnych uprawnień");

        public static Error NoLocations =>
            new Error(HttpStatusCode.BadRequest, "", "Nie podano danych adresowych");

        public static Error NoScheduleForYear =>
            new Error(HttpStatusCode.NotFound, "", "Użytkownik nie posiada grafiku na podany rok");

        public static Error AlreadyHasSchedule =>
            new Error(HttpStatusCode.BadRequest, "", "Użytkownik juz posiada przypisany grafik");

        public static Error NoHolidayLimit =>
            new Error(HttpStatusCode.BadRequest, "", "Użytkownik nie posiada limitu urlopowego");

        public static Error PasswordIsTooShort =>
            new Error(HttpStatusCode.BadRequest, "", "Hasło jest za krótkie");

        public static Error NoCredentials =>
            new Error(HttpStatusCode.NotFound, "", "Użytkownik nie ma przypisanego hasła");

        public static Error CurrentPasswordDifferent =>
            new Error(HttpStatusCode.NotFound, "", "Podane hasło nie jest poprawne");
        
        public static Error NoResolvedContracts =>
            new Error(HttpStatusCode.Conflict, "", "Użytkownik ma nie rozwiązane lub nie zatwierdzone umowy");
        
        public static Error CurrentAbsence =>
            new Error(HttpStatusCode.Conflict, "", "Użytkownik ma trwający urlop");
        
        public static Error PendingAbsence =>
            new Error(HttpStatusCode.Conflict, "", "Użytkownik ma nie zaakceptowany urlop");
    }
}