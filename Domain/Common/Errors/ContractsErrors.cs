using System.Net;
using Domain.Common.Models;

namespace Domain.Common.Errors;

public static class ContractsErrors {
    public static Error NotFoundAny =>
        new Error(HttpStatusCode.NotFound, "Contracts.NotFound", "Nie znaleziono żadnych umów");

    public static Error NotFoundChanges =>
        new Error(HttpStatusCode.NotFound, "Contracts.NotFoundChanges", "Nie znaleziono żadnych zmian");
    
    public static Error NonActiveContract =>
        new Error(HttpStatusCode.NotFound, "Contract.NotFound", "Nie znaleziono aktywnego kontraktu");
    
    public static Error NotFound =>
        new Error(HttpStatusCode.NotFound, "Contract.NotFound", "Nie znaleziono kontraktu z podanym id");

    public static Error AlreadyActive =>
        new Error(HttpStatusCode.BadRequest, "Contract.AlreadyAccepted", "Kontrakt jest już zaakceptowany!");

    public static Error AlreadyRejected =>
        new Error(HttpStatusCode.BadRequest, "Contract.AlreadyRejected", "Kontrakt jest juz odrzucony!");

    public static Error AlreadyTerminated =>
        new Error(HttpStatusCode.BadRequest, "Contract.AlreadyTeminated", "Kontrakt jest już zakończony!");
}