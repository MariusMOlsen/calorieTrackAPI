namespace CalorieTrack.Infrastructure.Authentication.TokenGenerator;

public class JwtSettings
{
    public const string Section = "JwtSettings";

    public string? Audience { get; set; } = "webApp";
    public string? Issuer { get; set; } = "webApi";
    public string Secret { get; set; } = "dwd4g6552131244qqq331321321321cedsacdzxvfhmnio8f8h8d5b6j6j75s44s1m1bf1ddf4gf5t6y7ytdfhht6dht";
    public int TokenExpirationInMinutes { get; set; }
}