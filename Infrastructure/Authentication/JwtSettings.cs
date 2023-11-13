namespace Infrastructure.Authentication;

public class JwtSettings {
    public string Issuer { get; init; }
    public string Audience { get; init; }
    public int DateTime { get; init; }
    public string Secret { get; init; }
}