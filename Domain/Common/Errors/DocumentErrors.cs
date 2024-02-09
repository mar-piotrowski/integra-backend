using System.Net;
using Domain.Common.Models;

namespace Domain.Common.Errors;

public static class DocumentErrors {
    public static Error NotFound => new Error(HttpStatusCode.NotFound, "", "Nie znaleziono dokumentu");
    public static Error Exists => new Error(HttpStatusCode.Conflict, "", "Dokument istnieje");
    public static Error IsLocked => new Error(HttpStatusCode.BadRequest, "", "Dokument został już zatwierdzony");
    public static Error NotFoundMany => new Error(HttpStatusCode.NotFound, "", "Nie znaleziono dokumentow");
    public static Error ContractorIsRequired => new Error(HttpStatusCode.BadRequest, "", "Kontrahent jest wymagany");
    public static Error AdmissionDateRequired => new Error(HttpStatusCode.BadRequest, "", "Dostawca jest wymagany");
    public static Error PaymentMethodIsRequired =>
        new Error(HttpStatusCode.BadRequest, "", "Metoda płatności jest wymagana");
    public static Error WrongDocumentType => new Error(HttpStatusCode.BadRequest, "", "Podano błędny typ dokumentu");
}