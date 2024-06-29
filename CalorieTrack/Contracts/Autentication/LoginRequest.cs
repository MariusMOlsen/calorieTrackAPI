namespace CalorieTrack.Api.Contracts.Autentication;

public record LoginRequest(
    string Email,
    string Password);