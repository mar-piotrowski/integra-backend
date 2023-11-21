using System.Net;
using Domain.Common.Models;

namespace Domain.Common.Errors; 

public static class ContractsErrors {
    public static Error NotFoundAny =>
        new Error(HttpStatusCode.NotFound, "Contracts.NotFound", "Nie znaleziono żadnych umów");

    public static Error NotFound =>
        new Error(HttpStatusCode.NotFound, "Contract.NotFound", "Nie znaleziono kontraktu z podanym id");
}