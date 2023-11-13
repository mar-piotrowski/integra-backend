namespace Application.Dtos; 

public class RegisterRequest {
    public required string Firstname { get; init; }
    public required string Surname { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
    public required string ConfirmPassword { get; init; }
}