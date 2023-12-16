using Domain.Entities;
using Domain.Models;
using Domain.ValueObjects.Ids;

namespace Application.Abstractions;

public interface IJwtService {
    public string GenerateAccessToken(User user);
    public string GenerateRefreshToken(User user);
    public TokenInfo VerifyToken(string token);
    public bool IsValid(string token);
    public UserId? DecodeJToken(string token);
}