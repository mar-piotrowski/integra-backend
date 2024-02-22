using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects;

namespace Application.Features.Contractor.Get; 

public record GetContractorQuery(Nip Nip) : IQuery<ContractorDto>;