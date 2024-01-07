using Domain.Enums;

namespace Application.Dtos;

public class ContractQueries {
    public ContractType ContractType { get; init; } = ContractType.None;
    public int UserId { get; init; } = -1;
}