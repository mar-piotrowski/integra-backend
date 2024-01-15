using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Dtos;

public record UpdateContractorRequest(
    string FullName,
    string ShortName,
    LocationDto Location,
    BankAccountDto BankAccount
);