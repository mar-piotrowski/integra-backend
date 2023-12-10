namespace Application.Dtos;

public record ContractorDto(
    int Id,
    string FullName,
    string ShortName,
    string Representative,
    string Nip,
    string Email,
    LocationDto Location
);