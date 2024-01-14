namespace Application.Dtos;

public record UpdateContractRequest(
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
    int InsuranceCodeId,
    int UserId,
    string JobPosition,
    int DeductibleCostId
);