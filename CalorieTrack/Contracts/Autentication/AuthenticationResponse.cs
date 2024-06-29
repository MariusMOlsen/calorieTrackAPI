namespace CalorieTrack.Api.Contracts.Autentication;

public record AuthenticationResponse(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Token);