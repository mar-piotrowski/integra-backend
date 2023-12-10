using Application.Abstractions.Messaging;
using Domain.Enums;

namespace Application.Features.Contract.Command;

public record CreateContractCommand(
    decimal Salary,
    int WorkingHours1,
    int WorkingHours2,
    DateTime? SignedOnDate,
    DateTime StartDate,
    DateTime? EndDate,
    bool JobFound,
    bool Fgsp,
    bool PitExemption,
    bool TaxRelief,
    ContractType ContractType,
    int InsuranceCodeId,
    int UserId,
    int JobPositionId,
    int DeductibleCostId
) : ICommand;