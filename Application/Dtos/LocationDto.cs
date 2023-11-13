namespace Application.Dtos;

public record LocationDto(
    string Street,
    string HouseNo,
    string ApartmentNo,
    string PostalCode,
    string City,
    string Country,
    bool IsPrivate,
    bool IsCompany
);