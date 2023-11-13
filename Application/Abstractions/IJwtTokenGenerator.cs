namespace Application.Abstractions;

public interface IJwtTokenGenerator {
    string GenerateToken(string firstname, string lastname);
}