using Application.Abstractions.Messaging;
using Domain.Enums;

namespace Application.Features.Contract.CreateContract;

public record CreateContractCommand(
    decimal SalaryWithTax,
    decimal SalaryWithoutTax,
    int WorkingHours1,
    int WorkingHours2,
    DateTime? SignedOnDate,
    DateTime StartDate,
    DateTime? EndDate,
    bool JobFound,
    bool VoluntaryContribution,
    bool PensionFund ,
    bool ProfitableFund, 
    bool Fgsp,
    bool PitExemption,
    bool TaxRelief,
    ContractType ContractType,
    int InsuranceCodeId,
    int UserId,
    int JobPositionId,
    int DeductibleCostId,
    bool Accept = false
) : ICommand;