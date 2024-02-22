using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Contractor.Update;

public record UpdateContractorCommand(
    string FullName,
    string ShortName,
    string Nip,
    string Email, 
    string Phone,
    LocationDto Location,
    BankAccountDto BankAccount 
) : ICommand;