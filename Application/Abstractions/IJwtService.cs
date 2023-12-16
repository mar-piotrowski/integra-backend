using Domain.Entities;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions;

public interface IJwtService {
    public string GenerateAccessToken(User user);
    public string GenerateRefreshToken(User user);
    public bool VerifyToken(string token);
    public UserId? DecodeJToken(string token);
}