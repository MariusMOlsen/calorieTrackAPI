using ErrorOr;

namespace CalorieTrack.Application.Authentication.Common;

public static class AuthenticationErrors
{
    public static readonly Error InvalidCredentials = Error.Validation(
        code: "Authentication.InvalidCredentials",
        description: "Invalid credentials");
    
    public static readonly Error UserNotExist = Error.Validation(
        code: "Authentication.UserNotExist",
        description: "User does not exist");
}