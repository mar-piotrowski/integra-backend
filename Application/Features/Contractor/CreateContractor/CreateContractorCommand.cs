using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Contractor.CreateContractor;

public record CreateContractorCommand(
    string FullName,
    string ShortName,
    string Representative,
    string Nip,
    string Email,
    string Phone,
    LocationDto Location,
    BankAccountDto BankAccount
) : ICommand;