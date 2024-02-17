using Application.Dtos;
using Domain.Entities;
using Domain.ValueObjects;

namespace Application.Mappers;

public static class LocationMapper {
    public static LocationDto MapToDto(this Location location) =>
        new LocationDto(
            location.Id.Value,
            location.Street,
            location.HouseNo,
            location.ApartmentNo,
            location.PostalCode,
            location.City,
            location.Country,
            location.Province,
            location.Commune,
            location.District,
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
            location.Province,
            location.Commune,
            location.District,
            location.IsPrivate,
            location.IsCompany
        );

    public static IEnumerable<Location> MapToEntities(this IEnumerable<LocationDto> locations) =>
        locations.Select(location => location.MapToEntity());
    
    public static IEnumerable<LocationDto> MapToDtos(this IEnumerable<Location> locations) =>
        locations.Select(location => location.MapToDto());
}