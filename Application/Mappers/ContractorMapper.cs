using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class ContractorMapper {
    public ContractorDto MapToDto(Contractor contractor) =>
        new ContractorDto(
            contractor.Id.Value,
            contractor.FullName,
            contractor.ShortName,
            contractor.Representative,
            contractor.Nip.Value,
            contractor.Email.Value,
            contractor.Phone.Value,
            contractor.Location.MapToDto(),
            contractor.BankAccount.MapToDto()
        );

    public List<ContractorDto> MapToDtos(IEnumerable<Contractor> contractors) =>
        contractors.Select(MapToDto).ToList();
}