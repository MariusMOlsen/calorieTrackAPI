using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Application.Common.Models;
using Google.Apis.Auth;

namespace CalorieTrack.Infrastructure.Authentication;

using ErrorOr;

public record UserInfo(
    string Email,
    string Name,
    string Id);
public class GoogleAuthentication: IGoogleAuthentication
{
    private ErrorOr<string?> UserId {get; set; }
    private ErrorOr<RegisterUser?> RegisterUser {get; set; }
    
    public  GoogleAuthentication()
    {}
    
    
    public async Task<ErrorOr<string?>>  AuthenticateGoogleCredentialLogin(string credential)
    {
        var settings = new GoogleJsonWebSignature.ValidationSettings()
        {
            Audience = new List<string> { "151956450176-959hvmecmpsjd8iit98m9lpo994k15bh.apps.googleusercontent.com" }
        };
        
        try
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(credential, settings);
            // Proceed with the validated token payload
            UserId = payload.Subject;
        }
        catch (InvalidJwtException ex)
        {
            UserId = Error.Conflict("Invalid JWT token");

        }
        catch (Exception ex)
        {
            UserId = Error.Conflict("Unexpected Error");
        }
     

        return UserId;

    }
    
    public async Task<ErrorOr<RegisterUser?>>  AuthenticateGoogleCredentialRegister(string credential)
    {
        string Email = "";
        string FirstName = "";
        string LastName = "";
        var settings = new GoogleJsonWebSignature.ValidationSettings()
        {
            Audience = new List<string> { "151956450176-959hvmecmpsjd8iit98m9lpo994k15bh.apps.googleusercontent.com" }
        };
        
        try
        {
            var payload = await GoogleJsonWebSignature.ValidateAsync(credential, settings);
            // Proceed with the validated token payload
            UserId = payload.Subject;
            Email = payload.Email;
            FirstName = payload.Name;
            LastName = payload.FamilyName;
        }
        catch (InvalidJwtException ex)
        {
          return  Error.Conflict("Invalid JWT token");

        }
        catch (Exception ex)
        {
          return Error.Conflict("Unexpected Error");
        }
    
        if(UserId.Value is null)
        {
            return Error.Conflict("Invalid Identity Token");
        }
        RegisterUser = new RegisterUser(Email, FirstName, LastName, UserId.Value);
        
        return RegisterUser;

    }
}