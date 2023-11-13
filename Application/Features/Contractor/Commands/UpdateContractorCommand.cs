using Application.Abstractions.Messaging;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Application.Features.Contractor.Commands;

public record UpdateContractorCommand(
    string FullName,
    string ShortName,
    Nip Nip,
    Location Location,
    BankDetails BankDetails 
) : ICommand;