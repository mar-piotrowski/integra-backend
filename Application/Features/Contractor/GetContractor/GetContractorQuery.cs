using Application.Abstractions.Messaging;
using Application.Dtos;
using Domain.ValueObjects;

namespace Application.Features.Contractor.GetContractor; 

public record GetContractorQuery(Nip Nip) : IQuery<ContractorDto>;