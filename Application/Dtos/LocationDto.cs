namespace Application.Dtos;

public record LocationDto(
    string Street,
    string HouseNo,
    string ApartmentNo,
    string PostalCode,
    string City,
    string Country,
    string Province,
    string Commune,
    string? District,
    bool IsPrivate,
    bool IsCompany
);