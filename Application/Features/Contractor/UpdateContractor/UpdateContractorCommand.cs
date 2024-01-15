using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects;

namespace Application.Features.Contractor.UpdateContractor;

public record UpdateContractorCommand(
    string FullName,
    string ShortName,
    string Nip,
    string Email, 
    string Phone,
    LocationDto Location,
    BankAccountDto BankAccount 
) : ICommand;