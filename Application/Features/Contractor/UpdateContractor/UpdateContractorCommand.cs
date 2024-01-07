using Application.Abstractions.Messaging;
using Domain.ValueObjects;
using Domain.ValueObjects.Ids;

namespace Application.Features.Contractor.UpdateContractor;

public record UpdateContractorCommand(
    string FullName,
    string ShortName,
    string Nip,
    string Email, 
    Location Location,
    BankDetails BankDetails 
) : ICommand;