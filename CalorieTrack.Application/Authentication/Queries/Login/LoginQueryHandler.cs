
using CalorieTrack.Application.Authentication.Common;
using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Domain.Model.Common.Interfaces;
using MediatR;
using ErrorOr;
namespace CalorieTrack.Application.Authentication.Queries.Login;

public class LoginQueryHandler(
    IGoogleAuthentication googleAuthentication,
    IJwtTokenGenerator jwtTokenGenerator,
    IUserRepository userRepository)
    : IRequestHandler<LoginWithGoogleQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IGoogleAuthentication _googleAuthentication = googleAuthentication;
    private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
    private readonly IUserRepository _userRepository = userRepository;

    
    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginWithGoogleQuery query, CancellationToken cancellationToken)
    {
        
        ErrorOr<string?> userId = await _googleAuthentication.AuthenticateGoogleCredentialLogin(query.credential);
        if (userId.IsError)
        {
            return userId.Errors;
        }
        
        if(userId.Value is null)
        {
            return AuthenticationErrors.InvalidCredentials;
        }
        
      
        
      var user = await _userRepository.GetByIdAsync(userId.Value);
      if (user is null)
      {
          return AuthenticationErrors.UserNotExist;
      }
     string  jwtToken= _jwtTokenGenerator.GenerateToken(user);
     return new AuthenticationResult(user, jwtToken);
    
    }
}