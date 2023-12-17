namespace Application.Dtos;

public record JobPositionDto(
    int Id,
    string Title,
    decimal? AvgSalary = null,
    int? CountUsers = null
);