using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Contractor.GetContractors; 

public record GetContractorsQuery : IQuery<ContractorsResponse>;