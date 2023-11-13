using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects;

namespace Application.Features.Contractor.Commands;

public record CreateContractorCommand(
    string FullName,
    string ShortName,
    string Representative,
    string Nip,
    LocationDto Location,
    BankDetailsDto BankDetails
) : ICommand;