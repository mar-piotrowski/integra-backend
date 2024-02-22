using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.Contractor.Delete;

public record DeleteContractorCommand(ContractorId ContractorId) : ICommand;