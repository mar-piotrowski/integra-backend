using Domain.Enums;

namespace Application.Dtos;

public record ContractDto(
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
);