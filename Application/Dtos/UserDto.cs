using Domain.Entities;
using Domain.Enums;

namespace Application.Dtos;

public class UserDto {
    public int Id { get; set; }
    public required string Firstname { get; init; }
    public required string Lastname { get; init; }
    public string? SecondName { get; init; }
    public string? Email { get; init; }
    public string? Phone { get; init; } 
    public required string IdentityNumber { get; init; } 
    public string? DocumentNumber { get; init; }
    public DateTimeOffset? DateOfBirth { get; init; }
    public string? PlaceOfBirth { get; init; }
    public Sex Sex { get; init; }
    public bool IsStudent { get; init; }
    public string? JobPosition { get; init; }
    public BankAccountDto? BankAccount { get; init; }
    public List<LocationDto> Locations { get; init; } = new List<LocationDto>();
    public List<PermissionDto> Permissions { get; init; } = new List<PermissionDto>();
}