using Application.Abstractions.Messaging;
using Domain.Enums;

namespace Application.Features.Contract.Command;

public record CreateContractCommand(
    decimal Salary,
    DateTime SignedOnDate,
    DateTime StartDate,
    DateTime? EndDate,
    bool JobFund,
    bool Fgsp,
    bool PitExemption,
    ContractType ContractType,
    int InsuranceCodeId,
    int UserId,
    int JobPositionId
) : ICommand;