using Domain.Enums;

namespace Application.Dtos;

public record ContractDto(
    int Id,
    ContractStatus Status,
    decimal SalaryWithTax,
    decimal SalaryWithoutTax,
    int WorkingHours1,
    int WorkingHours2,
    DateTime SignedOnDate,
    DateTime? StartDate,
    DateTime? EndDate,
    bool JobFund,
    bool Fgsp,
    bool PitExemption,
    ContractType ContractType,
    bool TaxRelief,
    int? InsuranceCodeId,
    UserDto User,
    string? JobPosition,
    decimal? DeductibleCost
);