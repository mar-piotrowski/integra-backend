namespace Application.Dtos;

public record CreateCardRequest(int UserId, string Number, bool Active);