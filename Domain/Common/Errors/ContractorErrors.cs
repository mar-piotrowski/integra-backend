using System.Net;
using Domain.Common.Models;

namespace Domain.Common.Errors {
    public static class ContractorErrors {
        public static Error NipExists => new Error(
            HttpStatusCode.BadRequest,
            "Contractor.NipExists",
            "Podany nip jest już zarejestrowany"
        );

        public static Error NotFound => new Error(
            HttpStatusCode.BadRequest,
            "",
            "Nie znaleziono kontrahenata"
        );

        public static Error NipNotExists => new Error(
            HttpStatusCode.NotFound,
            "Contractor.NipDoesNotExist",
            "Kontrahent z podanym nipem nie istnieje"
        );

        public static Error NotFoundMany => new Error(
            HttpStatusCode.NotFound,
            "Contractor.NotFoundMany",
            "Nie znaleziono żadnych kontrahentów"
        );
    }
}