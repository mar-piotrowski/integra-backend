using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.Enums;
using Domain.ValueObjects.Ids;

namespace Application.Features.Contract.Query;

public record GetContractsQuery(ContractType? ContractType, UserId? UserId)  : IQuery<ContractsResponse>;