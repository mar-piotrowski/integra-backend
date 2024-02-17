namespace Application.Dtos;

public record LocationDto(
    int Id,
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