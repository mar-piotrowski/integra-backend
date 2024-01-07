using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects.Ids;

namespace Application.Features.Contract.GetContract; 

public record GetContractQuery(ContractId ContractId) : IQuery<ContractDto>;