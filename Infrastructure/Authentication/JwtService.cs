using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Application.Abstractions;
using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TokenInfo = Domain.Common.Models.TokenInfo;

namespace Infrastructure.Authentication;

public class JwtService : IJwtService {
    private readonly JwtSettings _jwtOptions;

    public JwtService(IOptions<JwtSettings> jwtOptions) {
        _jwtOptions = jwtOptions.Value;
    }

    public string GenerateAccessToken(User user) {
        var expiry = DateTime.UtcNow.AddHours(20);
        var claims = GetUserClaims(user);
        return CreateToken(expiry, claims);
    }

    public string GenerateRefreshToken(User user) {
        var expiry = DateTime.UtcNow.AddYears(1);
        var claims = GetUserClaims(user);
        return CreateToken(expiry, claims);
    }

    public bool IsValid(string token) {
        try {
            var jwtSecurity = new JwtSecurityToken(token);
            return jwtSecurity.ValidTo > DateTime.UtcNow;
        }
        catch {
            return false;
        }
    }

    public TokenInfo VerifyToken(string token) {
        try {
            var tokenHandler = new JwtSecurityTokenHandler();
            var parameters = GetValidationParameters();
            tokenHandler.ValidateToken(token, parameters, out var securityToken);
            return new TokenInfo(true, securityToken.ValidTo);
        }
        catch {
            return new TokenInfo(false, null);
        }
    }

    public UserId? DecodeJToken(string token) {
        if (string.IsNullOrWhiteSpace(token))
            return null;
        var tokenDetails = new JwtSecurityToken(token);
        var userId = tokenDetails.Claims.FirstOrDefault(claim => claim.Type == "userId");
        return userId is null ? null : UserId.Create(int.Parse(userId.Value));
    }

    private string CreateToken(DateTime expiry, IEnumerable<Claim> claims) {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var securityToken = new JwtSecurityToken(
            expires: expiry,
            claims: claims,
            audience: _jwtOptions.Audience,
            issuer: _jwtOptions.Issuer,
            signingCredentials: credentials
        );
        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    private TokenValidationParameters GetValidationParameters() =>
        new TokenValidationParameters() {
            ValidateAudience = false,
            ValidateIssuer = false,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret))
        };

    private IEnumerable<Claim> GetUserClaims(User user) => new[] {
        new Claim("guid", Guid.NewGuid().ToString()),
        new Claim("userId", user.Id.Value.ToString()),
        new Claim(
            "permissions",
            JsonSerializer.Serialize(user.Permissions.Select(permission => permission.Permission.Code.Value)),
            JsonClaimValueTypes.JsonArray
        )
    };
}