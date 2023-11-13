using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public static class ContractorMapper {
    public static ContractorDto MapToDto(this Contractor contractor) =>
        new ContractorDto(
            contractor.FullName,
            contractor.ShortName,
            contractor.Representative,
            contractor.Nip.Value,
            contractor.Location.MapToDto()
        );

    public static List<ContractorDto> MapToListDto(this IEnumerable<Contractor> contractors) =>
        contractors.Select(contractor => contractor.MapToDto()).ToList();
}