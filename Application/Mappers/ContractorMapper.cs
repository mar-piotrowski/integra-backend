using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class ContractorMapper {
    public static ContractorDto MapToDto(this Contractor contractor) =>
        new ContractorDto(
            contractor.Id.Value,
            contractor.FullName,
            contractor.ShortName,
            contractor.Representative,
            contractor.Nip.Value,
            contractor.Email.Value,
            contractor.Location.MapToDto()
        );

    public static List<ContractorDto> MapToDtos(this IEnumerable<Contractor> contractors) =>
        contractors.Select(contractor => contractor.MapToDto()).ToList();
    
}