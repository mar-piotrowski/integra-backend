using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Contract.GetContracts;

public record GetContractsQuery(ContractQueries Queries) : IQuery<ContractsResponse>;