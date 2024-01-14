using Application.Abstractions.Messaging;
using Domain.ValueObjects.Ids;

namespace Application.Features.Contract.UpdateContract;
public record UpdateContractCommand(
    ContractId ContractId,
    decimal SalaryWithTax,
    decimal SalaryWithoutTax,
    int WorkingHours1,
    int WorkingHours2,
    DateTime SignedOnDate,
    bool JobFound,
    bool VoluntaryContribution,
    bool PensionFund ,
    bool ProfitableFund, 
    bool Fgsp,
    bool PitExemption,
    bool TaxRelief,
    string JobPositionId,
    InsuranceCodeId InsuranceCodeId,
    UserId UserId,
    DeductibleCostId DeductibleCostId
) : ICommand;
