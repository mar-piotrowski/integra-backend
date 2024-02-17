using Application.Abstractions.Messaging;
using Application.Dtos;

namespace Application.Features.Contractor.GetAll; 

public record GetContractorsQuery : IQuery<ContractorsResponse>;