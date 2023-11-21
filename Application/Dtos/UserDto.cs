namespace Application.Dtos;

public class UserDto {
    public int Id { get; set; }
    public string Firstname { get; init; }
    public string Lastname { get; init; }
    public string Email { get; init; }
    public List<LocationDto> Locations { get; set; } = new List<LocationDto>();
}
