using CalorieTrack.Api.Contracts.Autentication;
using CalorieTrack.Application.Authentication.Commands.Register;
using CalorieTrack.Application.Authentication.Common;
using CalorieTrack.Application.Authentication.Queries.Login;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace CalorieTrack.Controllers;
[Route("api/[controller]")]
[AllowAnonymous]
public class AuthenticationController( ISender _mediator): ApiController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] string credential)
    {
        var command = new RegisterCommand(
            credential);

        var authResult = await _mediator.Send(command);

        return authResult.Match(
            authResult => base.Ok(MapToAuthResponse(authResult)),
            Problem);
    }
    
    // [HttpPost("login")]
    // public async Task<IActionResult> Login(LoginRequest request)
    // {
    //     var query = new LoginQuery(request.Email, request.Password);
    //
    //     var authResult = await _mediator.Send(query);
    //
    //     if (authResult.IsError && authResult.FirstError == AuthenticationErrors.InvalidCredentials)
    //     {
    //         return Problem(
    //             detail: authResult.FirstError.Description,
    //             statusCode: StatusCodes.Status401Unauthorized);
    //     }
    //
    //     return authResult.Match(
    //         authResult => Ok(MapToAuthResponse(authResult)),
    //         Problem);
    // }
    //
    //
    
    
    [HttpPost("loginwithgoogle")]
    public async Task<IActionResult> Login([FromBody] string credential)
    {
        var query = new LoginWithGoogleQuery(credential);

        var authResult = await _mediator.Send(query);

        if (authResult.IsError && authResult.FirstError == AuthenticationErrors.InvalidCredentials)
        {
            return Problem(
                detail: authResult.FirstError.Description,
                statusCode: StatusCodes.Status401Unauthorized);
        }

        return authResult.Match(
            authResult => Ok(MapToAuthResponse(authResult)),
            Problem);
    }

    
    [HttpPost("logout")]
    public async Task<IActionResult> LogOut()
    {
        
        await HttpContext.SignOutAsync();
        return Ok();
    }
    private static AuthenticationResponse MapToAuthResponse(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
            authResult.User.Guid,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Email,
            authResult.Token);
    }


}