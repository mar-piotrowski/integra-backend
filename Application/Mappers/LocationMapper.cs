using Application.Dtos;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Mappers;

public static class LocationMapper {
    public static LocationDto MapToDto(this Location location) =>
        new LocationDto(
            location.Street,
            location.HouseNo,
            location.ApartmentNo,
            location.PostalCode,
            location.City,
            location.Country,
            location.IsPrivate,
            location.IsCompany
        );

    public static Location MapToEntity(this LocationDto location) =>
        Location.Create(
            location.Street,
            location.HouseNo,
            location.ApartmentNo,
            location.PostalCode,
            location.City,
            location.Country,
            location.IsPrivate,
            location.IsCompany
        );

    public static IEnumerable<Location> MapToEntities(this IEnumerable<LocationDto> locations) =>
        locations.Select(location => location.MapToEntity());
}