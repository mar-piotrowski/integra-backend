using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using Application.Abstractions;
using Domain.Entities;
using Domain.ValueObjects.Ids;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Authentication;

public class JwtService : IJwtService {
    private readonly IDateTimeProvider _dateTimeProvider;
    private readonly JwtSettings _jwtOptions;

    public JwtService(IDateTimeProvider dateTimeProvider, IOptions<JwtSettings> jwtOptions) {
        _dateTimeProvider = dateTimeProvider;
        _jwtOptions = jwtOptions.Value;
    }

    public string GenerateAccessToken(User user) {
        var expiry = _dateTimeProvider.UtcNow.AddSeconds(20);
        var claims = GetUserClaims(user);
        return CreateToken(expiry, claims);
    }

    public string GenerateRefreshToken(User user) {
        var expiry = _dateTimeProvider.UtcNow.AddMinutes(15);
        var claims = GetUserClaims(user);
        return CreateToken(expiry, claims);
    }

    public bool VerifyToken(string token) {
        try {
            var tokenHandler = new JwtSecurityTokenHandler();
            var parameters = GetValidationParameters();
            tokenHandler.ValidateToken(token, parameters, out var securityToken);
            return true;
        }
        catch {
            return false;
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
        new Claim("guid",Guid.NewGuid().ToString()),
        new Claim("userId", user.Id.Value.ToString()),
        new Claim(
            "permission",
            JsonSerializer.Serialize(user.Credential.Permissions.Select(permission => permission.Type)),
            JsonClaimValueTypes.JsonArray
        ),
        new Claim(
            "modulePermissions",
            JsonSerializer.Serialize(user.Credential.ModulePermissions ),
            JsonClaimValueTypes.JsonArray
        )
    };
}