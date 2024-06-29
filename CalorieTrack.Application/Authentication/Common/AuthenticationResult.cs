using CalorieTrack.Domain.Model;

namespace CalorieTrack.Application.Authentication.Common;

public record AuthenticationResult(
    User User,
    string Token);