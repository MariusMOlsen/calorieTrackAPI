using CalorieTrack.Application.Authentication.Common;
using CalorieTrack.Application.Authentication.Queries.Login;
using CalorieTrack.Application.Common.Interfaces;
using CalorieTrack.Application.Common.Models;
using CalorieTrack.Domain.Model;
using MediatR;
using ErrorOr;
namespace CalorieTrack.Application.Authentication.Commands.Register;

public class RegisterCommandHandler(  IGoogleAuthentication googleAuthentication,
    IJwtTokenGenerator jwtTokenGenerator,
    IUnitOfWork unitOfWork,
    IUserRepository userRepository): IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
private readonly IGoogleAuthentication _googleAuthentication = googleAuthentication;
private readonly IJwtTokenGenerator _jwtTokenGenerator = jwtTokenGenerator;
private readonly IUserRepository _userRepository = userRepository;
private readonly IUnitOfWork _unitOfWork = unitOfWork;

public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
{
        
    ErrorOr<RegisterUser?> userInfo = await _googleAuthentication.AuthenticateGoogleCredentialRegister(command.credential);
    if (userInfo.IsError)
    {
        return userInfo.Errors;
    }
        
    if(userInfo.Value is null)
    {
        return AuthenticationErrors.InvalidCredentials;
    }
   User? existingUser = await _userRepository.GetByGoogleUserIdAsync(userInfo.Value.Id);
   if (existingUser is not null)
   {
       return new AuthenticationResult(existingUser, jwtTokenGenerator.GenerateToken(existingUser));
   }
      
    User newUser = new User(userInfo.Value.FirstName, userInfo.Value.LastName,  userInfo.Value.Email,userInfo.Value.Id);
    string  jwtToken= _jwtTokenGenerator.GenerateToken(newUser);

    await _userRepository.AddUserASync(newUser);
    await _unitOfWork.CommitChangesAsync();
 
    return new AuthenticationResult(newUser, jwtToken);
    
}
}