using Domain.Enums;

namespace Application.Dtos;

public record TerminateContractRequest(ContractTerminateType TerminateType, DateTime TerminateDate);