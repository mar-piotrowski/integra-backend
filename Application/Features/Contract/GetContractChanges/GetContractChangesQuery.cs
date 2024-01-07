using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects.Ids;

namespace Application.Features.Contract.GetContractChanges;

public record GetContractChangesQuery(ContractId ContractId) : IQuery<ContractChangesResponse>;