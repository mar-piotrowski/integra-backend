using Domain.Enums;

namespace Application.Dtos;

public record ContractDto(
    decimal Salary,
    int WorkingHours1,
    int WorkingHours2,
    DateTime? SignedOnDate,
    DateTime StartDate,
    DateTime? EndDate,
    bool JobFund,
    bool Fgsp,
    bool PitExemption,
    ContractType ContractType,
    bool TaxRelief,
    int InsuranceCodeId,
    int UserId,
    int JobPositionId,
    int DeductibleCostId
);