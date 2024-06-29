using System.Net;
using CalorieTrack.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace CalorieTrack.Application.Authentication.Queries.Login;

public record LoginWithGoogleQuery(
    string credential) : IRequest<ErrorOr<AuthenticationResult>>;
