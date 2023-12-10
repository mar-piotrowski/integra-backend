using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class ContractMapper {
    public static ContractDto MapToDto(this Contract contract) =>
        new ContractDto(
            contract.Salary,
            contract.WorkingHours1,
            contract.WorkingHours2,
            contract.SignedOnDate,
            contract.StartDate,
            contract.EndDate,
            contract.JobFund,
            contract.Fgsp,
            contract.PitExemption,
            contract.ContractType,
            contract.TaxRelief,
            contract.InsuranceCodeId.Value,
            contract.UserId.Value,
            contract.JobPositionId.Value,
            contract.DeductibleCostId.Value
        );

    public static IEnumerable<ContractDto> MapToDtos(this IEnumerable<Contract> contracts) =>
        contracts.Select(contract => contract.MapToDto());
}