using Application.Abstractions.Messaging;

namespace Application.Features.Contract.UpdateContract;
public record UpdateContractCommand(
    int ContractId,
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
    int InsuranceCodeId,
    int UserId,
    int JobPositionId,
    int DeductibleCostId
) : ICommand;
