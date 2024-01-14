using Application.Abstractions.Repositories;
using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class ContractMapper {
    private readonly IJobPositionRepository _jobPositionRepository;
    private readonly UserMapper _userMapper;
    private readonly JobPositionMapper _jobPositionMapper;

    public ContractMapper(
        IJobPositionRepository jobPositionRepository,
        UserMapper userMapper,
        JobPositionMapper jobPositionMapper
    ) {
        _jobPositionRepository = jobPositionRepository;
        _userMapper = userMapper;
        _jobPositionMapper = jobPositionMapper;
    }

    public ContractDto MapToDto(Contract contract) {
        JobPosition? jobPosition = null;
        if (contract.JobPositionId is not null)
            jobPosition = _jobPositionRepository.GetById(contract.JobPositionId);
        return new ContractDto(
            contract.Id.Value,
            contract.Status,
            contract.SalaryWithTax,
            contract.SalaryWithoutTax,
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
            contract.InsuranceCodeId?.Value,
            _userMapper.MapToDto(contract.User),
            jobPosition is not null ? _jobPositionMapper.MapToDto(jobPosition).Title : null,
            contract.DeductibleCostId?.Value
        );
    }

    public IEnumerable<ContractDto> MapToDtos(IEnumerable<Contract> contracts) => contracts.Select(MapToDto);
}