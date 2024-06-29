using CalorieTrack.Application.Common.Models;
using ErrorOr;
namespace CalorieTrack.Application.Common.Interfaces;

public interface IGoogleAuthentication
{
    Task<ErrorOr<string?>> AuthenticateGoogleCredentialLogin(string credential);
    Task<ErrorOr<RegisterUser?>> AuthenticateGoogleCredentialRegister(string credential);
}