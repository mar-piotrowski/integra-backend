using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Contractor.Queries; 

public record GetContractorsQuery : IQuery<ContractorsResponse>;