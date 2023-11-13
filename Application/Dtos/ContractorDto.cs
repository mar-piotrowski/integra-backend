namespace Application.Dtos;

public record ContractorDto(
    string FullName,
    string ShortName,
    string Representative,
    string Nip,
    LocationDto Location
);