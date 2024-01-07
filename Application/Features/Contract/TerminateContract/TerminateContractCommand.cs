using Application.Abstractions.Messaging;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Application.Features.Contract.TerminateContract;

public record TerminateContractCommand(
    ContractId ContractId,
    ContractTerminateType TerminateType,
    DateTime TerminateDate
) : ICommand;